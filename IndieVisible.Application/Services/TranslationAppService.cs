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

                foreach (TranslationTermViewModel term in vm.Terms)
                {
                    UserProfile profile = GetCachedProfileByUserId(term.UserId);
                    if (profile != null)
                    {
                        term.AuthorName = profile.Name;
                        term.AuthorPicture = UrlFormatter.ProfileImage(term.UserId, 84);
                    }
                }

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

                //#region REMOVER

                //if (model.Id == Guid.Empty)
                //{
                //    model.Terms.Add(new TranslationTerm
                //    {
                //        Key = "menu_play",
                //        Value = "Jogar",
                //        Obs = "Menu item"
                //    });

                //    model.Terms.Add(new TranslationTerm
                //    {
                //        Key = "menu_quit",
                //        Value = "Sair",
                //        Obs = "Menu item"
                //    });
                //}

                //if (model.Entries.Count == 0)
                //{
                //    model.Entries.Add(new TranslationEntry
                //    {
                //        TermId = new Guid("0fb7bd45-33d6-466a-8d18-4414e4e01344"),
                //        Language = SupportedLanguage.Portuguese,
                //        Value = "Sair",
                //        CreateDate = DateTime.Now,
                //        UserId = currentUserId
                //    });
                //}

                //#endregion REMOVER

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

        public OperationResultVo SetTranslationEntry(Guid currentUserId, Guid projectId, TranslationEntryViewModel vm)
        {
            try
            {
                TranslationEntry entry = mapper.Map<TranslationEntry>(vm);

                translationDomainService.SetTranslationEntry(projectId, entry);
                vm.Id = entry.Id;

                unitOfWork.Commit();

                UserProfile profile = GetCachedProfileByUserId(entry.UserId);
                vm.AuthorName = profile.Name;

                return new OperationResultVo<TranslationEntryViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public async Task<OperationResultVo> ReadTermsSheet(Guid currentUserId, Guid projectId, IFormFile termsFile)
        {
            try
            {
                List<TranslationTerm> loadedTerms = new List<TranslationTerm>();
                List<TranslationEntry> loadedEntries = new List<TranslationEntry>();

                if (termsFile != null && termsFile.Length > 0)
                {
                    var dataTable = await LoadExcel(termsFile);

                    FillTerms(dataTable, loadedTerms, loadedEntries);

                    TranslationProject model = translationDomainService.GetById(projectId);

                    if (model != null)
                    {
                        foreach (var loadedTerm in loadedTerms)
                        {
                            var modelTerm = model.Terms.FirstOrDefault(x => x.Key.Equals(loadedTerm));
                            if (modelTerm == null)
                            {
                                model.Terms.Add(loadedTerm);
                            }
                            else
                            {
                                loadedTerm.Id = modelTerm.Id;
                                loadedTerm.CreateDate = modelTerm.CreateDate;
                                loadedTerm.UserId = modelTerm.UserId;
                            }
                        }

                        translationDomainService.Update(model);

                        unitOfWork.Commit();
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
                    if (row == null || row.Cells.All(d => d.CellType == CellType.Blank))
                    {
                        continue;
                    }

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

            return dtTable;
        }

        private static void FillTerms(DataTable dataTable, List<TranslationTerm> terms, List<TranslationEntry> entries)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var term = row.ItemArray[0];
                var termValue = row.ItemArray[1];

                if (term == null || string.IsNullOrWhiteSpace(term.ToString()) || termValue == null || string.IsNullOrWhiteSpace(termValue.ToString()))
                {
                    continue;
                }

                var termExists = terms.Any(x => x.Key.Equals(term));
                if (!termExists)
                {
                    var newTerm = new TranslationTerm
                    {
                        Key = term.ToString().Trim(),
                        Value = termValue.ToString().Trim()
                    };

                    terms.Add(newTerm);
                }
            }
        }
    }
}