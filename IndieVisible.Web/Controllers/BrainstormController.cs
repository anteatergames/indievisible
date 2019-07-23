using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using IndieVisible.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Controllers
{
    public class BrainstormController : SecureBaseController
    {
        private readonly IBrainstormAppService brainstormAppService;

        public BrainstormController(IBrainstormAppService brainstormAppService)
        {
            this.brainstormAppService = brainstormAppService;
        }

        [Route("brainstorm/{id:guid}")]
        [Route("brainstorm")]
        public IActionResult Index(Guid? id)
        {
            BrainstormSessionViewModel currentSession;

            OperationResultListVo<BrainstormSessionViewModel> sessions = brainstormAppService.GetSessions(this.CurrentUserId);

            ViewData["Sessions"] = sessions.Value;

            if (id.HasValue)
            {
                currentSession = sessions.Value.FirstOrDefault(x => x.Id == id.Value);
            }
            else
            {
                currentSession = sessions.Value.FirstOrDefault(x => x.Type == BrainstormSessionType.Main);

            }

            return View(currentSession);
        }

        [Route("brainstorm/{sessionId:guid}/newidea")]
        [Route("brainstorm/newidea")]
        public IActionResult NewIdea(Guid sessionId)
        {
            OperationResultVo<BrainstormSessionViewModel> sessionResult;

            if (sessionId == Guid.Empty)
            {
                sessionResult = brainstormAppService.GetMainSession();
            }
            else
            {
                sessionResult = brainstormAppService.GetSession(sessionId);
            }

            if (sessionResult.Success)
            {
                sessionId = sessionResult.Value.Id;

                ViewData["Session"] = sessionResult.Value;
            }

            BrainstormIdeaViewModel vm = new BrainstormIdeaViewModel();
            vm.SessionId = sessionId;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CreateEdit", vm);
            }
            else
            {
                return View("_CreateEdit", vm);
            }
        }

        public PartialViewResult NewSession()
        {
            BrainstormSessionViewModel vm = new BrainstormSessionViewModel();

            return PartialView("_CreateEditSession", vm);
        }

        public IActionResult Details(Guid id)
        {
            OperationResultVo<BrainstormIdeaViewModel> op = this.brainstormAppService.GetById(this.CurrentUserId, id);

            BrainstormIdeaViewModel vm = op.Value;

            this.SetAuthorDetails(vm);

            return View("_Details", vm);
        }

        [Route("brainstorm/list/{sessionId:guid}")]
        [Route("brainstorm/list")]
        public PartialViewResult List(Guid sessionId)
        {
            OperationResultListVo<BrainstormIdeaViewModel> serviceResult = brainstormAppService.GetAllBySessionId(this.CurrentUserId, sessionId);

            IEnumerable<BrainstormIdeaViewModel> items = serviceResult.Value;

            return PartialView("_List", items);
        }


        [HttpPost]
        public IActionResult Save(BrainstormIdeaViewModel vm)
        {
            try
            {
                vm.UserId = this.CurrentUserId;

                brainstormAppService.Save(vm);

                string url = Url.Action("Index", "Brainstorm", new { area = string.Empty, id = vm.SessionId.ToString() });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [HttpPost]
        public IActionResult SaveSession(BrainstormSessionViewModel vm)
        {
            try
            {
                vm.UserId = this.CurrentUserId;

                brainstormAppService.SaveSession(vm);

                string url = Url.Action("Index", "Brainstorm", new { area = string.Empty, id = vm.Id.ToString() });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Vote(BrainstormVoteViewModel vm)
        {
            try
            {
                brainstormAppService.Vote(this.CurrentUserId, vm.VotingItemId, vm.VoteValue);

                string url = Url.Action("Index", "Brainstorm", new { area = string.Empty });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }
    }
}