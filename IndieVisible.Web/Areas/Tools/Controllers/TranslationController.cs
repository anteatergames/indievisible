using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Translation;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Tools.Controllers.Base;
using IndieVisible.Web.Extensions;
using IndieVisible.Web.Extensions.ViewModelExtensions;
using IndieVisible.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Web.Areas.Tools.Controllers
{
    public class TranslationController : ToolsBaseController
    {
        private readonly ITranslationAppService translationAppService;

        public TranslationController(ITranslationAppService translationAppService)
        {
            this.translationAppService = translationAppService;
        }

        public IActionResult Index()
        {
            OperationResultVo gamesResult = translationAppService.GetMyUntranslatedGames(CurrentUserId);
            if (gamesResult.Success)
            {
                OperationResultListVo<SelectListItemVo> castResultGames = gamesResult as OperationResultListVo<SelectListItemVo>;

                IEnumerable<SelectListItemVo> games = castResultGames.Value;
                ViewData["CanRequest"] = games.Any();
            }
            else
            {
                ViewData["CanRequest"] = false;
            }

            return View();
        }

        [Route("tools/translation/list")]
        public PartialViewResult List()
        {
            IEnumerable<TranslationProjectViewModel> model;
            OperationResultVo serviceResult;

            serviceResult = translationAppService.GetAll(CurrentUserId);

            if (serviceResult != null && serviceResult.Success)
            {
                OperationResultListVo<TranslationProjectViewModel> castResult = serviceResult as OperationResultListVo<TranslationProjectViewModel>;

                model = castResult.Value;
            }
            else
            {
                model = new List<TranslationProjectViewModel>();
            }

            foreach (TranslationProjectViewModel item in model)
            {
                SetLocalization(item);
            }

            ViewData["ListDescription"] = SharedLocalizer["These are translation projects available to help."].ToString();

            return PartialView("_List", model);
        }

        [Route("tools/translation/listmine")]
        public PartialViewResult ListMine()
        {
            IEnumerable<TranslationProjectViewModel> model;
            OperationResultVo serviceResult;

            serviceResult = translationAppService.GetByUserId(CurrentUserId, CurrentUserId);

            if (serviceResult != null && serviceResult.Success)
            {
                OperationResultListVo<TranslationProjectViewModel> castResult = serviceResult as OperationResultListVo<TranslationProjectViewModel>;

                model = castResult.Value;
            }
            else
            {
                model = new List<TranslationProjectViewModel>();
            }

            foreach (TranslationProjectViewModel item in model)
            {
                SetLocalization(item);
            }

            ViewData["ListDescription"] = SharedLocalizer["These are translation projects available to help."].ToString();

            return PartialView("_ListByUser", model);
        }

        [Route("tools/translation/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            OperationResultVo result = translationAppService.GetStatsById(CurrentUserId, id);

            if (result.Success)
            {
                OperationResultVo<TranslationStatsViewModel> castRestult = result as OperationResultVo<TranslationStatsViewModel>;

                TranslationStatsViewModel model = castRestult.Value;

                SetLocalization(model);
                SetAuthorDetails(model);

                return View("Details", model);
            }
            else
            {
                return null;
            }
        }

        [Route("tools/translation/translate/{id:guid}/{language?}")]
        public IActionResult Translate(Guid id, SupportedLanguage language, int? pointsEarned)
        {
            OperationResultVo result = translationAppService.GetById(CurrentUserId, id);

            if (result.Success)
            {
                OperationResultVo<TranslationProjectViewModel> castRestult = result as OperationResultVo<TranslationProjectViewModel>;

                TranslationProjectViewModel model = castRestult.Value;

                SetLocalization(model);
                SetAuthorDetails(model);

                SetGamificationMessage(pointsEarned);

                ViewData["language"] = language.ToString();

                return View("TranslateWrapper", model);
            }
            else
            {
                return null;
            }
        }

        [Route("tools/translation/review/{id:guid}/{language?}")]
        public IActionResult Review(Guid id, SupportedLanguage language, int? pointsEarned)
        {
            OperationResultVo result = translationAppService.GetById(CurrentUserId, id);

            if (result.Success)
            {
                OperationResultVo<TranslationProjectViewModel> castRestult = result as OperationResultVo<TranslationProjectViewModel>;

                TranslationProjectViewModel model = castRestult.Value;

                SetLocalization(model);
                SetAuthorDetails(model);

                SetGamificationMessage(pointsEarned);

                ViewData["language"] = language.ToString();

                return View("ReviewWrapper", model);
            }
            else
            {
                return null;
            }
        }

        [Route("tools/translation/export/{id:guid}")]
        public IActionResult Export(Guid id)
        {
            OperationResultVo result = translationAppService.GetStatsById(CurrentUserId, id);

            if (result.Success)
            {
                OperationResultVo<TranslationStatsViewModel> castRestult = result as OperationResultVo<TranslationStatsViewModel>;

                TranslationStatsViewModel model = castRestult.Value;

                SetLocalization(model);
                SetAuthorDetails(model);

                return View("Export", model);
            }
            else
            {
                return null;
            }
        }

        [Route("tools/translation/exportxml/{projectId:guid}")]
        public IActionResult ExportXml(Guid projectId, SupportedLanguage? language, bool fillGaps)
        {
            OperationResultVo result = translationAppService.GetXml(CurrentUserId, projectId, language, fillGaps);

            if (result.Success)
            {
                if (language.HasValue)
                {
                    OperationResultVo<InMemoryFileVo> castRestult = result as OperationResultVo<InMemoryFileVo>;

                    InMemoryFileVo model = castRestult.Value;

                    return File(model.Contents, "application/xml", model.FileName);
                }
                else
                {
                    OperationResultVo<List<InMemoryFileVo>> castRestult = result as OperationResultVo<List<InMemoryFileVo>>;

                    List<InMemoryFileVo> list = castRestult.Value;

                    byte[] zip = GetZipArchive(list);

                    return File(zip, "application/xml", string.Format("{0}.zip", projectId));
                }
            }
            else
            {
                return null;
            }
        }

        [Route("tools/translation/exportcontributors/{projectId:guid}")]
        public IActionResult ExportContributors(Guid projectId, ExportContributorsType type)
        {
            OperationResultVo result = translationAppService.GetContributorsFile(CurrentUserId, projectId, type);

            if (result.Success)
            {
                OperationResultVo<List<KeyValuePair<Guid, string>>> castRestult = result as OperationResultVo<List<KeyValuePair<Guid, string>>>;

                List<KeyValuePair<Guid, string>> model = castRestult.Value;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("UserId;User Name;Profile URL");


                foreach (var item in model)
                {
                    var url = Url.Action("details", "profile", new { area = string.Empty, id = item.Key }, "https", Request.Host.Value);
                    var newLine = String.Format("{0};{1};{2}", item.Key, item.Value, url);
                    sb.AppendLine(newLine);
                }

                var file = new InMemoryFileVo
                {
                    FileName = String.Format("contributors_{0}.csv", type.ToString().ToLower()),
                    Contents = Encoding.UTF8.GetBytes(sb.ToString())
                };

                return File(file.Contents, "text/csv", file.FileName);
            }
            else
            {
                return null;
            }
        }

        [Authorize]
        [Route("tools/translation/new/")]
        public IActionResult New()
        {
            OperationResultVo serviceResult = translationAppService.GenerateNew(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultVo<TranslationProjectViewModel> castResult = serviceResult as OperationResultVo<TranslationProjectViewModel>;

                TranslationProjectViewModel model = castResult.Value;

                SetLocalization(model, true);

                OperationResultVo gamesResult = translationAppService.GetMyUntranslatedGames(CurrentUserId);
                if (gamesResult.Success)
                {
                    OperationResultListVo<SelectListItemVo> castResultGames = gamesResult as OperationResultListVo<SelectListItemVo>;

                    IEnumerable<SelectListItemVo> games = castResultGames.Value;

                    List<SelectListItem> gamesDropDown = games.ToSelectList();
                    ViewBag.UserGames = gamesDropDown;
                }
                else
                {
                    ViewBag.UserGames = new List<SelectListItem>();
                }

                return View("CreateEditWrapper", model);
            }
            else
            {
                return View("CreateEditWrapper", new TranslationProjectViewModel());
            }
        }

        [Authorize]
        [Route("tools/translation/edit/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            OperationResultVo serviceResult = translationAppService.GetById(CurrentUserId, id);

            if (serviceResult.Success)
            {
                OperationResultVo<TranslationProjectViewModel> castResult = serviceResult as OperationResultVo<TranslationProjectViewModel>;

                TranslationProjectViewModel model = castResult.Value;

                SetLocalization(model, true);

                return View("CreateEditWrapper", model);
            }
            else
            {
                return null;
            }
        }

        [Authorize]
        [HttpPost("tools/translation/save")]
        [RequestFormLimits(ValueCountLimit = int.MaxValue)]
        public IActionResult Save(TranslationProjectViewModel vm)
        {
            bool isNew = vm.Id == Guid.Empty;

            try
            {
                vm.UserId = CurrentUserId;

                OperationResultVo<Guid> saveResult = translationAppService.Save(CurrentUserId, vm);

                if (saveResult.Success)
                {
                    //GenerateFeedPost(vm);

                    string url = Url.Action("Details", "Translation", new { area = "tools", id = vm.Id });

                    if (isNew)
                    {
                        url = Url.Action("Edit", "Translation", new { area = "tools", id = vm.Id, pointsEarned = saveResult.PointsEarned });
                    }

                    return Json(new OperationResultRedirectVo<Guid>(saveResult, url));
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [Authorize]
        [HttpDelete("tools/translation/delete/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                OperationResultVo saveResult = translationAppService.Remove(CurrentUserId, id);

                if (saveResult.Success)
                {
                    string url = Url.Action("Index", "Translation", new { area = "tools" });

                    return Json(new OperationResultRedirectVo(saveResult, url));
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [Authorize]
        [HttpPost("tools/translation/gettranslation/{projectId:guid}")]
        public IActionResult GetTranslation(Guid projectId, SupportedLanguage language)
        {
            try
            {
                OperationResultVo result = translationAppService.GetTranslations(CurrentUserId, projectId, language);

                if (result.Success)
                {
                    OperationResultListVo<TranslationEntryViewModel> castResult = result as OperationResultListVo<TranslationEntryViewModel>;

                    return Json(castResult);
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [Authorize]
        [HttpPost("tools/translation/savetranslation/{projectId:guid}")]
        public IActionResult SaveTranslation(Guid projectId, TranslationEntryViewModel vm)
        {
            try
            {
                vm.UserId = CurrentUserId;

                OperationResultVo result = translationAppService.SaveEntry(CurrentUserId, projectId, vm);

                if (result.Success)
                {

                    OperationResultVo<TranslationEntryViewModel> castResult = result as OperationResultVo<TranslationEntryViewModel>;

                    return Json(result);
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [Authorize]
        [HttpPost("tools/translation/saveentries/{projectId:guid}")]
        [RequestFormLimits(ValueCountLimit = int.MaxValue)]
        public IActionResult SaveEntries(Guid projectId, SupportedLanguage language, IEnumerable<TranslationEntryViewModel> entries)
        {
            try
            {
                OperationResultVo result = translationAppService.SaveEntries(CurrentUserId, projectId, language, entries);

                if (result.Success)
                {
                    return Json(result);
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [Authorize]
        [HttpGet("tools/translation/getterms/{projectId:guid}")]
        public IActionResult GetTerms(Guid projectId)
        {
            try
            {
                OperationResultVo result = translationAppService.GetTerms(CurrentUserId, projectId);

                if (result.Success)
                {
                    OperationResultVo<TranslationProjectViewModel> castResult = result as OperationResultVo<TranslationProjectViewModel>;

                    return PartialView("_Terms", castResult.Value);
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [Authorize]
        [HttpPost("tools/translation/saveterms/{projectId:guid}")]
        [RequestFormLimits(ValueCountLimit = int.MaxValue)]
        [RequestSizeLimit(int.MaxValue)]
        public IActionResult SaveTerms(Guid projectId, IEnumerable<TranslationTermViewModel> terms)
        {
            try
            {
                OperationResultVo result = translationAppService.SetTerms(CurrentUserId, projectId, terms);

                if (result.Success)
                {
                    return Json(result);
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [Authorize]
        [HttpPost("tools/translation/uploadterms/{projectId:guid}")]
        public async Task<IActionResult> UploadTerms(Guid projectId, IEnumerable<ExcelColumnViewModel> columns, IFormFile termsFile)
        {
            try
            {
                IEnumerable<KeyValuePair<int, SupportedLanguage>> kvList = columns.ToKeyValuePairs();

                OperationResultVo result = await translationAppService.ReadTermsSheet(CurrentUserId, projectId, kvList, termsFile);

                if (result.Success)
                {
                    string url = Url.Action("Edit", "Translation", new { area = "tools", id = projectId });

                    return Json(new OperationResultRedirectVo<Guid>(projectId, url));
                }

                return Json(new OperationResultVo(false));
            }
            catch (Exception ex)
            {
                var json = new
                {
                    error = ex.Message
                };

                return Json(json);
            }
        }


        [Authorize]
        [HttpPost("tools/translation/entryreview/{projectId:guid}")]
        public IActionResult EntryReview(Guid projectId, Guid entryId, bool accept)
        {
            try
            {
                OperationResultVo result = translationAppService.EntryReview(CurrentUserId, projectId, entryId, accept);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        private void SetLocalization(TranslationProjectViewModel model)
        {
            SetLocalization(model, false);

            model.SetShareText(SharedLocalizer["Help translate {0}", model.Game.Title]);

            model.SetShareUrl(Url.Action("details", "translation", new { area = "tools", id = model.Id }));
        }

        private void SetLocalization(TranslationProjectViewModel model, bool editing)
        {
            if (model != null)
            {
                if (!editing)
                {
                    if (string.IsNullOrWhiteSpace(model.Introduction))
                    {
                        model.Introduction = SharedLocalizer["No extra information."];
                    }
                }
            }
        }

        public static byte[] GetZipArchive(List<InMemoryFileVo> files)
        {
            byte[] archiveFile;
            using (MemoryStream archiveStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
                {
                    foreach (InMemoryFileVo file in files)
                    {
                        ZipArchiveEntry zipArchiveEntry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
                        using (Stream zipStream = zipArchiveEntry.Open())
                            zipStream.Write(file.Contents, 0, file.Contents.Length);
                    }
                }

                archiveFile = archiveStream.ToArray();
            }

            return archiveFile;
        }
    }
}