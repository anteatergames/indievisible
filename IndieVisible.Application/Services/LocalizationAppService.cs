using AutoMapper;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Localization;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Application.Services
{
    public class LocalizationAppService : ProfileBaseAppService, ILocalizationAppService
    {
        private readonly ILocalizationDomainService translationDomainService;
        private readonly IGameDomainService gameDomainService;
        private readonly IGamificationDomainService gamificationDomainService;

        public LocalizationAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IProfileDomainService profileDomainService
            , ILocalizationDomainService translationDomainService
            , IGameDomainService gameDomainService
            , IGamificationDomainService gamificationDomainService) : base(mapper, unitOfWork, cacheService, profileDomainService)
        {
            this.translationDomainService = translationDomainService;
            this.gameDomainService = gameDomainService;
            this.gamificationDomainService = gamificationDomainService;
        }

        #region ICrudAppService

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = translationDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<LocalizationViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<Localization> allModels = translationDomainService.GetAll();

                List<LocalizationViewModel> vms = mapper.Map<IEnumerable<Localization>, IEnumerable<LocalizationViewModel>>(allModels).ToList();

                foreach (LocalizationViewModel item in vms)
                {
                    item.TermCount = item.Terms.Count;

                    SetGameViewModel(item.Game.Id, item);
                    item.Game.Title = string.Empty;

                    SetPermissions(currentUserId, item);

                    int totalTermCount = item.Terms.Count;
                    int distinctEntriesCount = item.Entries.Select(x => new { x.TermId, x.Language }).Distinct().Count();
                    int languageCount = item.Entries.Select(x => x.Language).Distinct().Count();

                    item.TranslationPercentage = translationDomainService.CalculatePercentage(totalTermCount, distinctEntriesCount, languageCount);
                }

                vms = vms.OrderByDescending(x => x.CreateDate).ToList();

                return new OperationResultListVo<LocalizationViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<LocalizationViewModel>(ex.Message);
            }
        }

        public OperationResultVo GetByUserId(Guid currentUserId, Guid userId)
        {
            try
            {
                IEnumerable<Localization> allModels = translationDomainService.GetByUserId(userId);

                List<LocalizationViewModel> vms = mapper.Map<IEnumerable<Localization>, IEnumerable<LocalizationViewModel>>(allModels).ToList();

                foreach (LocalizationViewModel item in vms)
                {
                    item.TermCount = item.Terms.Count;

                    ViewModels.Game.GameViewModel game = GetGameWithCache(gameDomainService, item.Game.Id);
                    item.Game.Title = game.Title;

                    SetPermissions(userId, item);
                }

                vms = vms.OrderByDescending(x => x.CreateDate).ToList();

                return new OperationResultListVo<LocalizationViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<LocalizationViewModel>(ex.Message);
            }
        }

        public OperationResultVo<LocalizationViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                Localization model = translationDomainService.GetById(id);

                if (model == null)
                {
                    return new OperationResultVo<LocalizationViewModel>("Translation Project not found!");
                }

                LocalizationViewModel vm = mapper.Map<LocalizationViewModel>(model);

                SetGameViewModel(model.GameId, vm);

                SetPermissions(currentUserId, vm);

                return new OperationResultVo<LocalizationViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<LocalizationViewModel>(ex.Message);
            }
        }

        public OperationResultVo GetBasicInfoById(Guid currentUserId, Guid id)
        {
            try
            {
                Localization model = translationDomainService.GetBasicInfoById(id);

                if (model == null)
                {
                    return new OperationResultVo<LocalizationViewModel>("Translation Project not found!");
                }

                LocalizationViewModel vm = mapper.Map<LocalizationViewModel>(model);

                SetGameViewModel(model.GameId, vm);

                SetPermissions(currentUserId, vm);

                return new OperationResultVo<LocalizationViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<LocalizationViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                translationDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true, "That Translation Project is gone now!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, LocalizationViewModel viewModel)
        {
            int pointsEarned = 0;

            try
            {
                Localization model;

                Localization existing = translationDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<Localization>(viewModel);
                }

                foreach (LocalizationTerm term in model.Terms)
                {
                    if (term.UserId == Guid.Empty)
                    {
                        term.UserId = currentUserId;
                    }
                }

                if (viewModel.Id == Guid.Empty)
                {
                    translationDomainService.Add(model);
                    viewModel.Id = model.Id;

                    pointsEarned += gamificationDomainService.ProcessAction(currentUserId, PlatformAction.TranslationRequest);
                }
                else
                {
                    translationDomainService.Update(model);
                }

                unitOfWork.Commit();

                viewModel.Id = model.Id;

                return new OperationResultVo<Guid>(model.Id, pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        #endregion ICrudAppService

        public OperationResultVo GetMyUntranslatedGames(Guid currentUserId)
        {
            try
            {
                IEnumerable<Game> myGames = gameDomainService.GetByUserId(currentUserId);

                IEnumerable<Guid> myTranslatedGames = translationDomainService.GetTranslatedGamesByUserId(currentUserId);

                IEnumerable<Game> availableGames = myGames.Where(x => !myTranslatedGames.Contains(x.Id));

                List<SelectListItemVo> vms = mapper.Map<IEnumerable<Game>, IEnumerable<SelectListItemVo>>(availableGames).ToList();

                return new OperationResultListVo<SelectListItemVo>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetTranslations(Guid currentUserId, Guid projectId, SupportedLanguage language)
        {
            try
            {
                IEnumerable<LocalizationEntry> entries = translationDomainService.GetEntries(projectId, language);

                List<LocalizationEntryViewModel> vms = mapper.Map<IEnumerable<LocalizationEntry>, IEnumerable<LocalizationEntryViewModel>>(entries).ToList();

                foreach (LocalizationEntryViewModel entry in vms)
                {
                    UserProfile profile = GetCachedProfileByUserId(entry.UserId);
                    entry.AuthorName = profile.Name;
                    entry.AuthorPicture = UrlFormatter.ProfileImage(entry.UserId);
                }

                return new OperationResultListVo<LocalizationEntryViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo SaveEntry(Guid currentUserId, Guid projectId, LocalizationEntryViewModel vm)
        {
            try
            {
                LocalizationEntry entry = mapper.Map<LocalizationEntry>(vm);

                bool addedOrUpdated = translationDomainService.AddEntry(projectId, entry);

                if (!addedOrUpdated)
                {
                    return new OperationResultVo("Another user already sent that translation!");
                }

                unitOfWork.Commit();
                vm.Id = entry.Id;

                UserProfile profile = GetCachedProfileByUserId(entry.UserId);
                vm.AuthorName = profile.Name;

                return new OperationResultVo<LocalizationEntryViewModel>(vm, "Translation saved!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo SaveEntries(Guid currentUserId, Guid projectId, SupportedLanguage language, IEnumerable<LocalizationEntryViewModel> entries)
        {
            try
            {
                List<LocalizationEntryViewModel> entriesUpdated = entries.ToList();

                foreach (LocalizationEntryViewModel item in entriesUpdated)
                {
                    item.UserId = currentUserId;
                    item.Language = language;
                }

                IEnumerable<LocalizationEntry> vms = mapper.Map<IEnumerable<LocalizationEntryViewModel>, IEnumerable<LocalizationEntry>>(entries);

                translationDomainService.SaveEntries(projectId, vms);

                unitOfWork.Commit();

                return new OperationResultVo(true, "Translations saved!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetTerms(Guid currentUserId, Guid projectId)
        {
            try
            {
                Localization basicData = translationDomainService.GetBasicInfoById(projectId);

                IEnumerable<LocalizationTerm> entries = translationDomainService.GetTerms(projectId);

                List<LocalizationTermViewModel> vms = mapper.Map<IEnumerable<LocalizationTerm>, IEnumerable<LocalizationTermViewModel>>(entries).ToList();

                foreach (LocalizationTermViewModel entry in vms)
                {
                    UserProfile profile = GetCachedProfileByUserId(entry.UserId);
                    entry.AuthorName = profile.Name;
                    entry.AuthorPicture = UrlFormatter.ProfileImage(entry.UserId);
                }

                LocalizationViewModel projectVm = new LocalizationViewModel
                {
                    Id = projectId,
                    PrimaryLanguage = basicData.PrimaryLanguage,
                    Terms = vms
                };

                return new OperationResultVo<LocalizationViewModel>(projectVm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo SetTerms(Guid currentUserId, Guid projectId, IEnumerable<LocalizationTermViewModel> terms)
        {
            try
            {
                List<LocalizationTerm> vms = mapper.Map<IEnumerable<LocalizationTermViewModel>, IEnumerable<LocalizationTerm>>(terms).ToList();

                foreach (LocalizationTerm term in vms)
                {
                    term.UserId = currentUserId;
                }

                translationDomainService.SetTerms(projectId, vms);

                unitOfWork.Commit();

                return new OperationResultVo(true, "Terms Updated!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetStatsById(Guid currentUserId, Guid id)
        {
            try
            {
                Localization model = translationDomainService.GetById(id);

                if (model == null)
                {
                    return new OperationResultVo("Translation Project not found!");
                }

                TranslationStatsViewModel vm = mapper.Map<TranslationStatsViewModel>(model);

                vm.TermCount = model.Terms.Count;

                IEnumerable<IGrouping<SupportedLanguage, LocalizationEntry>> languages = model.Entries.GroupBy(x => x.Language);

                foreach (IGrouping<SupportedLanguage, LocalizationEntry> language in languages)
                {
                    TranslationStatsLanguageViewModel languageEntry = new TranslationStatsLanguageViewModel
                    {
                        Language = language.Key,
                        EntryCount = language.Select(x => x.TermId).Distinct().Count(),
                        Percentage = translationDomainService.CalculatePercentage(vm.TermCount, language.Count(), 1)
                    };

                    vm.Languages.Add(languageEntry);
                }

                SetPercentage(model, vm);

                SetContributors(model, vm);

                SetGameViewModel(model.GameId, vm);

                SetPermissions(currentUserId, vm);

                return new OperationResultVo<TranslationStatsViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetPercentageByGameId(Guid currentUserId, Guid gameId)
        {
            try
            {
                LocalizationStatsVo model = translationDomainService.GetPercentageByGameId(gameId);

                if (model == null)
                {
                    return new OperationResultVo("Localization Project not found!");
                }

                return new OperationResultVo<LocalizationStatsVo>(model);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetXml(Guid currentUserId, Guid projectId, SupportedLanguage? language, bool fillGaps)
        {
            try
            {
                if (language.HasValue)
                {
                    Task<InMemoryFileVo> task = translationDomainService.GetXmlById(projectId, language.Value, fillGaps);

                    task.Wait();

                    return new OperationResultVo<InMemoryFileVo>(task.Result);
                }
                else
                {
                    List<InMemoryFileVo> list = new List<InMemoryFileVo>();

                    Task<List<InMemoryFileVo>> task = translationDomainService.GetXmlById(projectId, fillGaps);

                    task.Wait();

                    foreach (InMemoryFileVo item in task.Result)
                    {
                        list.Add(item);
                    }

                    return new OperationResultVo<List<InMemoryFileVo>>(list);
                }

            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }


        public OperationResultVo GetContributorsFile(Guid currentUserId, Guid projectId, ExportContributorsType type)
        {
            try
            {
                Task<List<Guid>> task = translationDomainService.GetContributors(projectId, type);

                task.Wait();

                List<Guid> contributorsIds = task.Result;

                List<KeyValuePair<Guid, string>> dict = new List<KeyValuePair<Guid, string>>();

                foreach (Guid contributorId in contributorsIds)
                {
                    UserProfile profile = GetCachedProfileByUserId(contributorId);
                    dict.Add(new KeyValuePair<Guid, string>(contributorId, profile.Name));
                }

                return new OperationResultVo<List<KeyValuePair<Guid, string>>>(dict);

            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public async Task<OperationResultVo> ReadTermsSheet(Guid currentUserId, Guid projectId, IEnumerable<KeyValuePair<int, SupportedLanguage>> columns, IFormFile termsFile)
        {
            try
            {
                List<LocalizationTerm> loadedTerms = new List<LocalizationTerm>();
                List<LocalizationEntry> loadedEntries = new List<LocalizationEntry>();

                if (termsFile != null && termsFile.Length > 0)
                {
                    DataTable dataTable = await LoadExcel(termsFile);

                    FillTerms(dataTable, loadedTerms);

                    Localization model = translationDomainService.GetById(projectId);

                    if (model != null)
                    {
                        bool termsUpdated = false;
                        foreach (LocalizationTerm loadedTerm in loadedTerms)
                        {
                            if (loadedTerm.UserId == Guid.Empty)
                            {
                                loadedTerm.UserId = currentUserId;
                            }

                            LocalizationTerm modelTerm = model.Terms.FirstOrDefault(x => x.Key.Equals(loadedTerm.Key.Replace("\n", string.Empty)));
                            if (modelTerm == null)
                            {
                                model.Terms.Add(loadedTerm);
                                termsUpdated = true;
                            }
                            else
                            {
                                loadedTerm.Id = modelTerm.Id;
                                loadedTerm.CreateDate = modelTerm.CreateDate;
                                loadedTerm.UserId = modelTerm.UserId;
                                modelTerm.Value = loadedTerm.Value;
                                termsUpdated = true;
                            }
                        }

                        if (termsUpdated)
                        {
                            translationDomainService.Update(model);

                            await unitOfWork.Commit();

                            FillEntries(dataTable, model.Terms, loadedEntries, columns);

                            bool entriesUpdated = false;
                            foreach (LocalizationEntry loadedEntry in loadedEntries)
                            {
                                if (loadedEntry.UserId == Guid.Empty)
                                {
                                    loadedEntry.UserId = currentUserId;
                                }

                                LocalizationEntry modelEntry = model.Entries.FirstOrDefault(x => x.TermId == loadedEntry.TermId && x.UserId == currentUserId && x.Language == loadedEntry.Language);
                                if (modelEntry == null)
                                {
                                    model.Entries.Add(loadedEntry);
                                    entriesUpdated = true;
                                }
                                else
                                {
                                    loadedEntry.Id = modelEntry.Id;
                                    loadedEntry.CreateDate = modelEntry.CreateDate;
                                    loadedEntry.UserId = modelEntry.UserId;
                                    modelEntry.Value = loadedEntry.Value;
                                    entriesUpdated = true;
                                }
                            }

                            if (entriesUpdated)
                            {
                                translationDomainService.Update(model);

                                await unitOfWork.Commit();
                            }
                        }
                    }
                }

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GenerateNew(Guid currentUserId)
        {
            try
            {
                Localization newJobPosition = translationDomainService.GenerateNewProject(currentUserId);

                LocalizationViewModel newVm = mapper.Map<LocalizationViewModel>(newJobPosition);

                return new OperationResultVo<LocalizationViewModel>(newVm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo EntryReview(Guid currentUserId, Guid projectId, Guid entryId, bool accept)
        {
            try
            {
                if (accept)
                {
                    translationDomainService.AcceptEntry(projectId, entryId);
                }
                else
                {
                    translationDomainService.RejectEntry(projectId, entryId);
                }

                unitOfWork.Commit();

                return new OperationResultVo(true, "Translation Updated!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public void SetPermissions(Guid currentUserId, LocalizationViewModel vm)
        {
            SetBasePermissions(currentUserId, vm);
        }

        private void SetContributors(Localization model, TranslationStatsViewModel vm)
        {
            IEnumerable<IGrouping<Guid, LocalizationEntry>> contributors = model.Entries.GroupBy(x => x.UserId);

            foreach (IGrouping<Guid, LocalizationEntry> contributorGroup in contributors)
            {
                ContributorViewModel contributor = new ContributorViewModel();
                UserProfile profile = GetCachedProfileByUserId(contributorGroup.Key);
                contributor.UserId = contributorGroup.Key;
                contributor.AuthorName = profile.Name;
                contributor.AuthorPicture = UrlFormatter.ProfileImage(contributorGroup.Key);
                contributor.EntryCount = contributorGroup.Count();
                vm.Contributors.Add(contributor);
            }

            vm.Contributors = vm.Contributors.OrderByDescending(x => x.EntryCount).ToList();
        }

        private void SetPercentage(Localization model, TranslationStatsViewModel vm)
        {
            int totalTermCount = model.Terms.Count;
            int distinctEntriesCount = model.Entries.Select(x => new { x.TermId, x.Language }).Distinct().Count();
            int languageCount = model.Entries.Select(x => x.Language).Distinct().Count();

            vm.TranslationPercentage = translationDomainService.CalculatePercentage(totalTermCount, distinctEntriesCount, languageCount);
        }

        private static string SetFeaturedImage(Guid userId, string thumbnailUrl, ImageType imageType)
        {
            if (string.IsNullOrWhiteSpace(thumbnailUrl) || Constants.DefaultGameThumbnail.NoExtension().Contains(thumbnailUrl.NoExtension()))
            {
                return Constants.DefaultGameThumbnail;
            }
            else
            {
                switch (imageType)
                {
                    case ImageType.LowQuality:
                        return UrlFormatter.Image(userId, BlobType.GameThumbnail, thumbnailUrl, 278, 10);

                    case ImageType.Responsive:
                        return UrlFormatter.Image(userId, BlobType.GameThumbnail, thumbnailUrl, 0, 0, true);

                    case ImageType.Full:
                    default:
                        return UrlFormatter.Image(userId, BlobType.GameThumbnail, thumbnailUrl, 278);
                }
            }
        }

        private void SetGameViewModel(Guid gameId, LocalizationViewModel vm)
        {
            GameViewModel game = GetGameWithCache(gameDomainService, gameId);
            vm.Game.Title = game.Title;

            vm.Game.ThumbnailUrl = SetFeaturedImage(game.UserId, game?.ThumbnailUrl, ImageType.Full);
            vm.Game.ThumbnailResponsive = SetFeaturedImage(game.UserId, game?.ThumbnailUrl, ImageType.Responsive);
            vm.Game.ThumbnailLquip = SetFeaturedImage(game.UserId, game?.ThumbnailUrl, ImageType.LowQuality);
        }

        private async Task<DataTable> LoadExcel(IFormFile termsFile)
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;

            using (MemoryStream stream = new MemoryStream())
            {
                await termsFile.CopyToAsync(stream);
                stream.Position = 0;

                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheetAt(0);

                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;

                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    {
                        dtTable.Columns.Add(cell.ToString());
                    }
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    ICell firstCell = row.GetCell(0);
                    ICell secondCell = row.GetCell(1);

                    if (row == null || row.Cells.All(d => d.CellType == CellType.Blank))
                    {
                        continue;
                    }

                    if (firstCell != null && secondCell != null && !string.IsNullOrWhiteSpace(firstCell.ToString()) && !string.IsNullOrWhiteSpace(secondCell.ToString()))
                    {
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                                {
                                    rowList.Add(row.GetCell(j).ToString());
                                }
                            }
                        }

                        if (rowList.Count > 0)
                        {
                            dtTable.Rows.Add(rowList.ToArray());
                        }

                        rowList.Clear();
                    }
                }
            }

            return dtTable;
        }

        private static void FillTerms(DataTable dataTable, List<LocalizationTerm> terms)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                object term = row.ItemArray[0];
                object termValue = row.ItemArray[1];

                if (term == null || string.IsNullOrWhiteSpace(term.ToString()) || termValue == null || string.IsNullOrWhiteSpace(termValue.ToString()))
                {
                    continue;
                }

                bool termExists = terms.Any(x => x.Key.Equals(term));
                if (!termExists)
                {
                    LocalizationTerm newTerm = new LocalizationTerm
                    {
                        Key = term.ToString().Trim().Replace("\n", "_"),
                        Value = termValue.ToString().Trim()
                    };

                    newTerm.Key = SanitizeKey(newTerm.Key);

                    terms.Add(newTerm);
                }
            }
        }
        private static string SanitizeKey(string key)
        {
            if (key.EndsWith("\n") || key.StartsWith("\n"))
            {
                key = key.Replace("\n", string.Empty);
            }
            if (key.EndsWith("_") || key.StartsWith("_"))
            {
                key = key.Replace("_", string.Empty);
            }
            if (key.EndsWith(".") || key.StartsWith("."))
            {
                key = key.Replace(".", string.Empty);
            }

            key = key.Replace("\n", "_");
            key = key.Replace("__", "_");
            key = key.Replace("__", "_");
            key = key.Replace("__", "_");

            return key;
        }

        private static void FillEntries(DataTable dataTable, List<LocalizationTerm> terms, List<LocalizationEntry> entries, IEnumerable<KeyValuePair<int, SupportedLanguage>> columns)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                object term = row.ItemArray[0];

                foreach (KeyValuePair<int, SupportedLanguage> col in columns)
                {
                    int colNumber = col.Key - 1;

                    if (col.Key > row.ItemArray.Length)
                    {
                        break;
                    }

                    object translation = row.ItemArray[colNumber];

                    if (term == null || string.IsNullOrWhiteSpace(term.ToString()) || translation == null || string.IsNullOrWhiteSpace(translation.ToString()))
                    {
                        continue;
                    }

                    LocalizationTerm existingTerm = terms.FirstOrDefault(x => SanitizeKey(x.Key).Equals(SanitizeKey(term.ToString())));
                    if (existingTerm != null)
                    {
                        LocalizationEntry newEntry = new LocalizationEntry
                        {
                            TermId = existingTerm.Id,
                            Value = translation.ToString().Trim(),
                            Language = col.Value
                        };

                        entries.Add(newEntry);
                    }
                }
            }
        }
    }
}