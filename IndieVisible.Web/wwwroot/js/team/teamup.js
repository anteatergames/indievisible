var TEAMUP = (function () {
    "use strict";

    var rootUrl = '/team';
    var avatarBaseUrl = "/storage/userimage/ProfileImage/";
    var propPrefixId = "Members_0__";
    var propPrefixName = "Members[0].";

    var selectors = {};
    var objs = {};
    var isAjax = false;
    var canInteract = false;
    var isList = false;

    function setSelectors() {
        selectors.container = '#teamcontainer';
        selectors.isAjax = '#isajax';
        selectors.caninteract = '#caninteract';
        selectors.Id = '#Id';
        selectors.divListTeams = '#divListTeams';
        selectors.divListMyTeams = '#divListMyTeams';
        selectors.btnTeamNew = '.btn-team-new';
        selectors.teamMemberTemplate = '.team-member.template';
        selectors.formSaveTeam = '#frmTeamSave';
        selectors.btnSaveTeam = '#btnSaveTeam';
        selectors.divteamItem = '.team-item';
        selectors.divMembers = '#divMembers';
        selectors.teamMember = '.team-member';
        selectors.teamMemberUserId = '.team-member:not(.template) .team-member-userid';
        selectors.teamMemberIsLeader = '.team-member-isleader';
        selectors.teamMemberName = '.team-member-name';
        selectors.ddlSearchMembers = '#ddlSearchMembers';
        selectors.divDetails = '.div-details';
        selectors.divInvitation = '#divInvitation';
        selectors.txtMyQuote = '#txtMyQuote';
        selectors.btnAcceptInvitation = '#btnAcceptInvitation';
        selectors.btnRejectInvitation = '#btnRejectInvitation';
        selectors.btnEditTeam = '.btnEditTeam';
        selectors.btnDeleteTeam = '.btnDeleteTeam';
        selectors.btnDeleteMember = '.btnDeleteMember';
        selectors.divGames = '#divGames';
        selectors.divGamesList = '#divGamesList';
        selectors.divApplication = '#divApplication';
        selectors.btnCandidateApply = '#btnCandidateApply';
        selectors.btnAcceptCandidate = '.btnAcceptCandidate';
        selectors.btnRejectCandidate = '.btnRejectCandidate';
    }

    function cacheObjects() {
        objs.container = $(selectors.container);
        objs.Id = $(selectors.Id);
        objs.divListTeams = $(selectors.divListTeams);
        objs.divListMyTeams = $(selectors.divListMyTeams);
        objs.divInvitation = $(selectors.divInvitation);
        objs.divGames = $(selectors.divGames);
        objs.divGamesList = $(selectors.divGamesList);
        objs.divApplication = $(selectors.divApplication);

        if (!isAjax) {
            cacheAjaxObjs();
            objs.txtMyQuote = $(selectors.txtMyQuote);
        }
    }

    function cacheObjectsDetails() {
        objs.btnAcceptCandidate = $(selectors.btnAcceptCandidate);
        objs.btnRejectCandidate = $(selectors.btnRejectCandidate);
    }

    function init() {
        setSelectors();
        cacheObjects();

        isList = objs.Id.val() === undefined;

        bindAll();
        isAjax = $(selectors.container).find(selectors.isAjax).val();
        canInteract = $(selectors.container).find(selectors.caninteract).val();
        objs.container.find(selectors.caninteract).val();

        if (isList) {
            loadTeams();
            loadMyTeams();
        }
        else {
            cacheObjectsDetails();
            if (objs.divGames.length > 0) {
                loadTeamGames();
            }
        }

        bindSelect2();
    }

    function bindAll() {
        bindBtnSave();

        if (isList) {
            bindBtnNew();
            bindEditTeam();
            bindDeleteTeam();
        } else {
            bindAcceptInvitation();
            bindRejectInvitation();
            bindCandidateApply();
            bindAcceptCandidate();
            bindRejectCandidate();
        }
        bindDeleteMember();
    }

    function bindSelect2() {
        $('.members select.select2').each(function (index, element) {
            if ($(this).data('select2') === undefined) {
                $(this).select2({
                    width: 'element'
                });
            }
        });
    }

    function bindSelect2Search() {
        objs.ddlSearchMembers.select2({
            minimumInputLength: 2,
            templateResult: select2FormatResult
        });

        objs.ddlSearchMembers.on('select2:select', function (e) {
            var data = e.params.data;
            $(this).val(null).trigger('change');

            selectNewMemberCallBack(data);
        });
    }

    function bindBtnNew() {
        objs.container.on('click', selectors.btnTeamNew, function () {
            if (canInteract) {
                loadNewForm();
            }
        });
    }

    function bindBtnSave() {
        objs.container.on('click', selectors.btnSaveTeam, function (e) {
            e.preventDefault();
            var btn = $(this);

            var valid = objs.form.valid();
            if (valid && canInteract) {
                MAINMODULE.Common.DisableButton(btn);

                submitForm(btn);
            }

            return false;
        });
    }

    function bindAcceptInvitation() {
        objs.divMembers.on('click', selectors.btnAcceptInvitation, function () {
            var btn = $(this);
            var url = $(this).data('url');
            var myQuote = objs.txtMyQuote.val();

            var data = {
                quote: myQuote
            };

            $.post(url, data)
                .done(function (response) {
                    MAINMODULE.Common.HandlePointsEarned(response);

                    var quote = btn.closest(selectors.divDetails).find('.quote');
                    quote.text(myQuote);
                    quote.removeClass('d-none');
                    objs.divInvitation.remove();
                });
        });
    }

    function bindRejectInvitation() {
        objs.divMembers.on('click', selectors.btnRejectInvitation, function () {
            var btn = $(this);
            var url = $(this).data('url');

            $.post(url)
                .done(function (response) {
                    btn.closest(selectors.teamMember).remove();
                });
        });
    }

    function bindCandidateApply() {
        objs.divApplication.on('click', selectors.btnCandidateApply, function () {
            var btn = $(this);
            var url = btn.data('url');

            var data = objs.divApplication.find(':input').serialize();

            $.post(url, data)
                .done(function (response) {
                    if (!response.success) {
                        ALERTSYSTEM.ShowWarningMessage(response.message);
                    }
                    else {
                        MAINMODULE.Common.HandlePointsEarned(response);

                        if (response.message) {
                            ALERTSYSTEM.ShowSuccessMessage(response.message, function () {
                                if (response.url) {
                                    window.location = response.url;
                                }
                            });
                        }
                    }
                });
        });
    }

    function bindAcceptCandidate() {
        objs.divMembers.on('click', selectors.btnAcceptCandidate, function () {
            var btn = $(this);
            var url = btn.data('url');

            $.post(url)
                .done(function (response) {
                    if (!response.success) {
                        ALERTSYSTEM.ShowWarningMessage(response.message);
                    }
                    else {
                        if (response.message) {
                            ALERTSYSTEM.ShowSuccessMessage(response.message, function () {
                                if (response.url) {
                                    window.location = response.url;
                                }
                            });
                        }
                    }
                });
        });
    }

    function bindRejectCandidate() {
        objs.divMembers.on('click', selectors.btnRejectCandidate, function () {
            var btn = $(this);
            var url = $(this).data('url');

            $.post(url)
                .done(function (response) {
                    btn.closest(selectors.teamMember).remove();
                });
        });
    }

    function bindEditTeam() {
        objs.divListTeams.on('click', selectors.btnEditTeam, function (e) {
            e.preventDefault();
            var url = $(this).data('url');

            if (canInteract) {
                loadEditForm(url);
            }
        });
    }

    function bindDeleteTeam() {
        objs.divListTeams.on('click', selectors.btnDeleteTeam, function (e) {
            e.preventDefault();

            var btn = $(this);
            var url = $(this).data('url');
            var msg = btn.data('confirmationmessage');
            var confirmationTitle = btn.data('confirmationtitle');
            var confirmationButtonText = btn.data('confirmationbuttontext');
            var cancelButtonText = btn.data('cancelbuttontext');

            ALERTSYSTEM.ShowConfirmMessage(confirmationTitle, msg, confirmationButtonText, cancelButtonText, function () {
                $.ajax({
                    url: url,
                    type: 'DELETE'
                }).done(function (response) {
                    if (response.success) {
                        btn.closest(selectors.divteamItem).remove();
                        loadMyTeams();

                        if (response.message) {
                            ALERTSYSTEM.ShowSuccessMessage(response.message, function () {
                                if (response.url) {
                                    window.location = response.url;
                                }
                            });
                        }
                    }
                    else {
                        ALERTSYSTEM.ShowWarningMessage(response.message);
                    }
                });
            });
        });
    }

    function bindDeleteMember() {
        objs.container.on('click', selectors.btnDeleteMember, function (e) {
            console.log('meh');
            e.preventDefault();

            var btn = $(this);
            var url = $(this).data('url');
            var msg = btn.data('confirmationmessage');
            var confirmationTitle = btn.data('confirmationtitle');
            var confirmationButtonText = btn.data('confirmationbuttontext');
            var cancelButtonText = btn.data('cancelbuttontext');

            ALERTSYSTEM.ShowConfirmMessage(confirmationTitle, msg, confirmationButtonText, cancelButtonText, function () {
                $.ajax({
                    url: url,
                    type: 'DELETE'
                }).done(function (response) {
                    if (response.success) {
                        btn.closest(selectors.teamMember).remove();
                        renameInputs();

                        if (response.message) {
                            ALERTSYSTEM.ShowSuccessMessage(response.message);
                        }
                    }
                    else {
                        ALERTSYSTEM.ShowWarningMessage(response.message);
                    }
                });
            });
        });
    }

    function loadTeams() {
        objs.divListTeams.html(MAINMODULE.Default.SpinnerTop);

        $.get('/team/list/', function (data) { objs.divListTeams.html(data); })
            .done(function (response) {
                setPopOvers();
            });
    }

    function loadMyTeams() {
        objs.divListMyTeams.html(MAINMODULE.Default.SpinnerTop);

        $.get('/team/list/mine', function (data) { objs.divListMyTeams.html(data); })
            .done(function (response) {
                console.info('my teams loaded');
            });
    }

    function loadNewForm() {
        objs.container.html(MAINMODULE.Default.Spinner);

        $.get(rootUrl + "/new", function (data) {
            objs.container.html(data);

            cacheAjaxObjs();

            bindSelect2();
            bindSelect2Search();

            $.validator.unobtrusive.parse(objs.form);
        });
    }

    function loadEditForm(url) {
        objs.container.html(MAINMODULE.Default.Spinner);

        $.get(url, function (data) {
            objs.container.html(data);

            renameInputs();

            cacheAjaxObjs();

            bindSelect2();
            bindSelect2Search();

            $.validator.unobtrusive.parse(objs.form);
        });
    }

    function loadTeamGames() {
        objs.divGamesList.html(MAINMODULE.Default.SpinnerTop);

        var id = objs.divGames.data('id');

        $.get('/game/byteam/' + id, function (data) { objs.divGamesList.html(data); });
    }

    function selectNewMemberCallBack(data) {
        var newMemberObj = $(selectors.teamMemberTemplate).first().clone();

        var existingUserIds = [];
        $(selectors.teamMemberUserId).each(function (index, element) {
            existingUserIds.push(element.value);
        });

        var alreadyAdded = existingUserIds.indexOf(data.id) > -1;

        if (alreadyAdded) {
            ALERTSYSTEM.ShowWarningMessage("The user you selected is already added to this team!");
            return;
        }

        var userId = newMemberObj.find('[id$=__UserId]');
        userId.val(data.id);

        var avatar = newMemberObj.find('.avatar');
        avatar.attr('src', avatarBaseUrl + data.id);
        var isleader = newMemberObj.find(selectors.teamMemberIsLeader);
        isleader.remove();
        var name = newMemberObj.find(selectors.teamMemberName);
        name.text(data.text);
        var nameHidden = newMemberObj.find('.team-member-name-hidden');
        nameHidden.val(data.text);

        newMemberObj.removeClass('template');

        newMemberObj.appendTo(selectors.divMembers);

        renameInputs();

        bindSelect2();
    }

    function select2FormatResult(result) {
        if (!result.id) {
            return result.text;
        }
        var resultHtml = $('<span><img class="rounded-circle lazyload avatar" data-src="' + avatarBaseUrl + result.id + '" src="/images/profileimages/developer.png" alt="meh"> ' + result.text + '</span>');
        return resultHtml;
    }

    function cacheAjaxObjs() {
        objs.form = $(selectors.formSaveTeam);
        objs.ddlSearchMembers = $(selectors.ddlSearchMembers);
        objs.divMembers = $(selectors.divMembers);
        objs.teamMember = $(selectors.teamMember);
    }

    function setPopOvers() {
        $("[data-toggle='popover']").each(function (index, element) {
            var data = $(element).data();
            if (data.target) {
                var contentElementId = data.target;
                var contentHtml = $(contentElementId).html();
                data.content = contentHtml;
                data.html = true;
            }
            $(element).popover(data);
        });
    }

    function submitForm(btn) {
        var url = objs.form.attr('action');

        var data = objs.form.serialize();

        $.post(url, data).done(function (response) {
            if (response.success === true) {
                MAINMODULE.Common.PostSaveCallback(response, btn);

                ALERTSYSTEM.ShowSuccessMessage(response.message, function () {
                    window.location = response.url;
                });
            }
            else {
                ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
            }
        });
    }

    function renameInputs() {
        var count = 0;
        objs.divMembers.find(selectors.teamMember).each(function (index, element) {
            $(this).find(':input').each(function (index2, element2) {
                var inputId = $(this).attr('id');
                var inputName = $(this).attr('name');

                if (inputId !== undefined && inputName !== undefined) {
                    var idProp = inputId.split('__')[1];
                    var newId = propPrefixId.replace('0', count) + idProp;
                    $(this).attr('id', newId);

                    var nameProp = inputName.split('].')[1];
                    var newName = propPrefixName.replace('0', count) + nameProp;
                    $(this).attr('name', newName);
                }
            });

            count++;
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    TEAMUP.Init();
});