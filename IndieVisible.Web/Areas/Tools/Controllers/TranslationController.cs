using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Translation;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Tools.Controllers.Base;
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

            return PartialView("_List", model);
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