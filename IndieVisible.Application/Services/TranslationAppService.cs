using AutoMapper;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Translation;
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
    public class TranslationAppService : ProfileBaseAppService, ITranslationAppService
    {
        private readonly ITranslationDomainService translationDomainService;
        private readonly IGameDomainService gameDomainService;
        private readonly IGamificationDomainService gamificationDomainService;

        public TranslationAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IProfileDomainService profileDomainService
            , ITranslationDomainService translationDomainService
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

        public OperationResultListVo<TranslationProjectViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<TranslationProject> allModels = translationDomainService.GetAll();

                List<TranslationProjectViewModel> vms = mapper.Map<IEnumerable<TranslationProject>, IEnumerable<TranslationProjectViewModel>>(allModels).ToList();

                foreach (TranslationProjectViewModel item in vms)
                {
                    item.TermCount = item.Terms.Count;

                    SetGameViewModel(item.Game.Id, item);
                    item.Game.Title = string.Empty;

                    SetPermissions(currentUserId, item);

                    int totalTermCount = item.Terms.Count;
                    int distinctEntriesCount = item.Entries.Select(x => new { x.TermId, x.Language }).Distinct().Count();
                    int languageCount = item.Entries.Select(x => x.Language).Distinct().Count();

                    item.TranslationPercentage = CalculatePercentage(totalTermCount, distinctEntriesCount, languageCount);
                }

                vms = vms.OrderByDescending(x => x.CreateDate).ToList();

                return new OperationResultListVo<TranslationProjectViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<TranslationProjectViewModel>(ex.Message);
            }
        }

        public OperationResultVo GetByUserId(Guid currentUserId, Guid userId)
        {
            try
            {
                IEnumerable<TranslationProject> allModels = translationDomainService.GetByUserId(userId);

                List<TranslationProjectViewModel> vms = mapper.Map<IEnumerable<TranslationProject>, IEnumerable<TranslationProjectViewModel>>(allModels).ToList();

                foreach (TranslationProjectViewModel item in vms)
                {
                    item.TermCount = item.Terms.Count;

                    ViewModels.Game.GameViewModel game = GetGameWithCache(gameDomainService, item.Game.Id);
                    item.Game.Title = game.Title;

                    SetPermissions(userId, item);
                }

                vms = vms.OrderByDescending(x => x.CreateDate).ToList();

                return new OperationResultListVo<TranslationProjectViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<TranslationProjectViewModel>(ex.Message);
            }
        }

        public OperationResultVo<TranslationProjectViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                TranslationProject model = translationDomainService.GetById(id);

                if (model == null)
                {
                    return new OperationResultVo<TranslationProjectViewModel>("Translation Project not found!");
                }

                TranslationProjectViewModel vm = mapper.Map<TranslationProjectViewModel>(model);

                SetGameViewModel(model.GameId, vm);

                SetPermissions(currentUserId, vm);

                return new OperationResultVo<TranslationProjectViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<TranslationProjectViewModel>(ex.Message);
            }
        }

        public OperationResultVo GetBasicInfoById(Guid currentUserId, Guid id)
        {
            try
            {
                TranslationProject model = translationDomainService.GetBasicInfoById(id);

                if (model == null)
                {
                    return new OperationResultVo<TranslationProjectViewModel>("Translation Project not found!");
                }

                TranslationProjectViewModel vm = mapper.Map<TranslationProjectViewModel>(model);

                SetGameViewModel(model.GameId, vm);

                SetPermissions(currentUserId, vm);

                return new OperationResultVo<TranslationProjectViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<TranslationProjectViewModel>(ex.Message);
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

        public OperationResultVo<Guid> Save(Guid currentUserId, TranslationProjectViewModel viewModel)
        {
            int pointsEarned = 0;

            try
            {
                TranslationProject model;

                TranslationProject existing = translationDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<TranslationProject>(viewModel);
                }

                foreach (TranslationTerm term in model.Terms)
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
                IEnumerable<TranslationEntry> entries = translationDomainService.GetEntries(projectId, language);

                List<TranslationEntryViewModel> vms = mapper.Map<IEnumerable<TranslationEntry>, IEnumerable<TranslationEntryViewModel>>(entries).ToList();

                foreach (TranslationEntryViewModel entry in vms)
                {
                    UserProfile profile = GetCachedProfileByUserId(entry.UserId);
                    entry.AuthorName = profile.Name;
                    entry.AuthorPicture = UrlFormatter.ProfileImage(entry.UserId);
                }

                return new OperationResultListVo<TranslationEntryViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo SaveEntry(Guid currentUserId, Guid projectId, TranslationEntryViewModel vm)
        {
            try
            {
                TranslationEntry entry = mapper.Map<TranslationEntry>(vm);

                translationDomainService.SaveEntry(projectId, entry);
                vm.Id = entry.Id;

                unitOfWork.Commit();

                UserProfile profile = GetCachedProfileByUserId(entry.UserId);
                vm.AuthorName = profile.Name;

                return new OperationResultVo<TranslationEntryViewModel>(vm, "Translation saved!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo SaveEntries(Guid currentUserId, Guid projectId, SupportedLanguage language, IEnumerable<TranslationEntryViewModel> entries)
        {
            try
            {
                List<TranslationEntryViewModel> entriesUpdated = entries.ToList();

                foreach (TranslationEntryViewModel item in entriesUpdated)
                {
                    item.UserId = currentUserId;
                    item.Language = language;
                }

                IEnumerable<TranslationEntry> vms = mapper.Map<IEnumerable<TranslationEntryViewModel>, IEnumerable<TranslationEntry>>(entries);

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
                var basicData = translationDomainService.GetBasicInfoById(projectId);

                IEnumerable<TranslationTerm> entries = translationDomainService.GetTerms(projectId);

                List<TranslationTermViewModel> vms = mapper.Map<IEnumerable<TranslationTerm>, IEnumerable<TranslationTermViewModel>>(entries).ToList();

                foreach (TranslationTermViewModel entry in vms)
                {
                    UserProfile profile = GetCachedProfileByUserId(entry.UserId);
                    entry.AuthorName = profile.Name;
                    entry.AuthorPicture = UrlFormatter.ProfileImage(entry.UserId);
                }

                TranslationProjectViewModel projectVm = new TranslationProjectViewModel
                {
                    Id = projectId,
                    PrimaryLanguage = basicData.PrimaryLanguage,
                    Terms = vms
                };

                return new OperationResultVo<TranslationProjectViewModel>(projectVm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo SetTerms(Guid currentUserId, Guid projectId, IEnumerable<TranslationTermViewModel> terms)
        {
            try
            {
                List<TranslationTerm> vms = mapper.Map<IEnumerable<TranslationTermViewModel>, IEnumerable<TranslationTerm>>(terms).ToList();

                foreach (var term in vms)
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

        public async Task<OperationResultVo> ReadTermsSheet(Guid currentUserId, Guid projectId, IEnumerable<KeyValuePair<int, SupportedLanguage>> columns, IFormFile termsFile)
        {
            try
            {
                List<TranslationTerm> loadedTerms = new List<TranslationTerm>();
                List<TranslationEntry> loadedEntries = new List<TranslationEntry>();

                if (termsFile != null && termsFile.Length > 0)
                {
                    DataTable dataTable = await LoadExcel(termsFile);

                    FillTerms(dataTable, loadedTerms);

                    TranslationProject model = translationDomainService.GetById(projectId);

                    if (model != null)
                    {
                        bool termsUpdated = false;
                        foreach (TranslationTerm loadedTerm in loadedTerms)
                        {
                            if (loadedTerm.UserId == Guid.Empty)
                            {
                                loadedTerm.UserId = currentUserId;
                            }

                            TranslationTerm modelTerm = model.Terms.FirstOrDefault(x => x.Key.Equals(loadedTerm.Key.Replace("\n", string.Empty)));
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
                            foreach (TranslationEntry loadedEntry in loadedEntries)
                            {
                                if (loadedEntry.UserId == Guid.Empty)
                                {
                                    loadedEntry.UserId = currentUserId;
                                }

                                TranslationEntry modelEntry = model.Entries.FirstOrDefault(x => x.TermId == loadedEntry.TermId && x.UserId == currentUserId && x.Language == loadedEntry.Language);
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
                TranslationProject newJobPosition = translationDomainService.GenerateNewProject(currentUserId);

                TranslationProjectViewModel newVm = mapper.Map<TranslationProjectViewModel>(newJobPosition);

                return new OperationResultVo<TranslationProjectViewModel>(newVm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public void SetPermissions(Guid currentUserId, TranslationProjectViewModel vm)
        {
            SetBasePermissions(currentUserId, vm);
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

        private void SetGameViewModel(Guid gameId, TranslationProjectViewModel vm)
        {
            ViewModels.Game.GameViewModel game = GetGameWithCache(gameDomainService, gameId);
            vm.Game.Title = game.Title;

            vm.Game.ThumbnailUrl = SetFeaturedImage(game.UserId, game?.ThumbnailUrl, ImageType.Full);
            vm.Game.ThumbnailResponsive = SetFeaturedImage(game.UserId, game?.ThumbnailUrl, ImageType.Responsive);
            vm.Game.ThumbnailLquip = SetFeaturedImage(game.UserId, game?.ThumbnailUrl, ImageType.LowQuality);
        }

        private double CalculatePercentage(int totalTerms, int translatedCount, int languageCount)
        {
            int totalTranslationsTarget = languageCount * totalTerms;

            double percentage = (100 * translatedCount) / (double)(totalTranslationsTarget == 0 ? 1 : totalTranslationsTarget);

            return percentage;
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

        private static void FillTerms(DataTable dataTable, List<TranslationTerm> terms)
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
                    TranslationTerm newTerm = new TranslationTerm
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

        private static void FillEntries(DataTable dataTable, List<TranslationTerm> terms, List<TranslationEntry> entries, IEnumerable<KeyValuePair<int, SupportedLanguage>> columns)
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

                    TranslationTerm existingTerm = terms.FirstOrDefault(x => SanitizeKey(x.Key).Equals(SanitizeKey(term.ToString())));
                    if (existingTerm != null)
                    {
                        TranslationEntry newEntry = new TranslationEntry
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