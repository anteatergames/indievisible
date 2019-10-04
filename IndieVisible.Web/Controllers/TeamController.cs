using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Controllers
{
    [Route("team")]
    public class TeamController : SecureBaseController
    {
        private readonly ITeamAppService teamAppService;
        private readonly INotificationAppService notificationAppService;

        public TeamController(ITeamAppService teamAppService
            , INotificationAppService notificationAppService)
        {
            this.teamAppService = teamAppService;
            this.notificationAppService = notificationAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("list")]
        public IActionResult List()
        {
            OperationResultListVo<TeamViewModel> serviceResult = teamAppService.GetAll(this.CurrentUserId);

            List<TeamViewModel> model = serviceResult.Value.ToList();

            return PartialView("_List", model);
        }

        [Route("list/user/{userId:guid}")]
        public IActionResult ListByUser(Guid userId)
        {
            OperationResultListVo<TeamViewModel> serviceResult = (OperationResultListVo<TeamViewModel>)teamAppService.GetByUserId(userId);

            List<TeamViewModel> model = serviceResult.Value.ToList();

            return PartialView("_List", model);
        }

        [Route("list/mine")]
        public IActionResult ListMyTeams()
        {
            OperationResultListVo<TeamViewModel> serviceResult = (OperationResultListVo<TeamViewModel>)teamAppService.GetByUserId(CurrentUserId);

            List<TeamViewModel> model = serviceResult.Value.ToList();

            return PartialView("_ListMine", model);
        }

        [Route("{teamId:guid}")]
        public IActionResult Details(Guid teamId, Guid notificationclicked)
        {
            notificationAppService.MarkAsRead(notificationclicked);

            OperationResultVo<TeamViewModel> serviceResult = teamAppService.GetById(teamId);

            if (!serviceResult.Success)
            {
                TempData["Message"] = SharedLocalizer["Team not found!"].Value;
                return RedirectToAction("Index");
            }

            TeamViewModel model = serviceResult.Value;

            foreach (TeamMemberViewModel member in model.Members)
            {
                member.Permissions.IsMe = member.UserId == CurrentUserId;
            }

            return View(model);
        }

        [Authorize]
        [Route("edit/{teamId:guid}")]
        public IActionResult Edit(Guid teamId)
        {
            OperationResultVo<TeamViewModel> service = teamAppService.GetById(teamId);

            TeamViewModel model = service.Value;

            return PartialView("_CreateEdit", model);
        }

        [Authorize]
        [Route("new")]
        public IActionResult New()
        {
            OperationResultVo<TeamViewModel> service = (OperationResultVo<TeamViewModel>)teamAppService.GenerateNewTeam(CurrentUserId);

            return PartialView("_CreateEdit", service.Value);
        }

        [Authorize]
        [HttpPost("save")]
        public IActionResult Save(TeamViewModel vm)
        {
            try
            {

                vm.UserId = CurrentUserId;

                IEnumerable<Guid> oldMembers = vm.Members.Where(x => x.Id != Guid.Empty).Select(x => x.Id);

                teamAppService.Save(vm);

                Notify(vm, oldMembers);

                string url = Url.Action("Index", "Team", new { area = string.Empty, id = vm.Id.ToString() });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [Route("{teamId:guid}/invitation/accept")]
        public IActionResult AcceptInvitation(Guid teamId, string quote)
        {
            OperationResultVo serviceResult = teamAppService.AcceptInvite(teamId, CurrentUserId, quote);

            return Json(serviceResult);
        }


        [Route("{teamId:guid}/invitation/reject")]
        public IActionResult RejectInvitation(Guid teamId)
        {
            OperationResultVo serviceResult = teamAppService.RejectInvite(teamId, CurrentUserId);

            return Json(serviceResult);
        }


        [HttpDelete("{teamId:guid}")]
        public IActionResult DeleteTeam(Guid teamId)
        {
            OperationResultVo serviceResult = teamAppService.Remove(teamId);

            return Json(serviceResult);
        }

        private void Notify(TeamViewModel vm, IEnumerable<Guid> oldMembers)
        {
            string notificationText = SharedLocalizer["{0} has invited you to join a team!"];
            string notificationUrl = Url.Action("Details", "Team", new { teamId = vm.Id });

            TeamMemberViewModel meAsMember = vm.Members.FirstOrDefault(x => x.UserId == CurrentUserId);

            foreach (TeamMemberViewModel member in vm.Members.Where(x => !x.Leader))
            {
                if (!oldMembers.Contains(member.Id))
                {
                    notificationAppService.Notify(member.UserId, NotificationType.TeamInvitation, vm.Id, String.Format(notificationText, meAsMember?.Name), notificationUrl);
                }
            }
        }
    }
}