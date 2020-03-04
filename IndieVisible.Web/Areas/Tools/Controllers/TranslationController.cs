using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Application.Helpers;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Translation;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Tools.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Route("tools/translation/details/{id:guid}")]
        public IActionResult Details(Guid id, int? pointsEarned)
        {
            OperationResultVo<TranslationProjectViewModel> op = translationAppService.GetById(CurrentUserId, id);

            TranslationProjectViewModel vm = op.Value;

            SetLocalization(vm);
            SetAuthorDetails(vm);

            SetGamificationMessage(pointsEarned);

            return View("_Details", vm);
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

                SetLocalization(model);

                return PartialView("_CreateEdit", model);
            }
            else
            {
                return PartialView("_CreateEdit", new TranslationProjectViewModel());
            }
        }

        [Authorize]
        [HttpPost("tools/translation/save")]
        public IActionResult Save(TranslationProjectViewModel vm)
        {
            try
            {
                vm.UserId = CurrentUserId;

                OperationResultVo<Guid> saveResult = translationAppService.Save(CurrentUserId, vm);

                if (saveResult.Success)
                {
                    //GenerateFeedPost(vm);

                    string url = Url.Action("Details", "Translation", new { area = "tools", id = vm.Id, pointsEarned = saveResult.PointsEarned });

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

        private void SetLocalization(TranslationProjectViewModel item)
        {
            SetLocalization(item, false);
        }

        private void SetLocalization(TranslationProjectViewModel item, bool editing)
        {
            if (item != null)
            {
            }
        }
    }
}