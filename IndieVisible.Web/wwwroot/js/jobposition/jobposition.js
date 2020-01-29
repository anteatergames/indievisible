var JOBPOSITION = (function () {
    "use strict";

    var rootUrl = '/jobposition';

    var selectors = {};
    var objs = {};
    var canInteract = false;
    var newIdea = false;
    var details = false;

    function init() {
        setSelectors();
        cacheObjects();

        bindAll();

        canInteract = objs.container.find('#caninteract').val();
        newIdea = window.location.href.indexOf('newidea') > -1;
        details = window.location.href.indexOf('details') > -1;

        if (!newIdea && !details) {
            loadSession();
        }

        objs.ddlStatus.removeClass('invisible').show();
    }

    function setSelectors() {
        selectors.container = '.content';
        selectors.toolbar = $("#divToolbar");
        selectors.list = $("#divList");
        selectors.btnPostVotingItem = $("#btnPostVotingItem");
        selectors.form = $("#frmBrainstormIdeaSave");
        selectors.ddlStatus = '#ddlStatus';
    }

    function cacheObjects() {
        objs.container = $(selectors.container);
        objs.ddlStatus = $(selectors.ddlStatus);
    }

    function bindAll() {
        bindBtnNewIdea();
        bindBtnNewSession();
        bindBtnSaveIdea();
        bindBtnSaveSession();
        bindBtnVote();
        bindStatusChange();
    }

    function bindStatusChange() {
        objs.container.on('change', selectors.ddlStatus, function (e) {
            var selectedStatus = $(this).val();
            var url = $(this).data('url');
            var ideaId = $(this).data('id');

            var data = {
                selectedStatus: selectedStatus,
                ideaId: ideaId
            };

            $.post(url, data).done(function (response) {
                if (response.success === true) {
                    ALERTSYSTEM.ShowSuccessMessage("Awesome!", function (isConfirm) {
                        window.location = response.url;
                    });
                }
                else {
                    ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                }
            });
        });
    }

    function bindBtnNewIdea() {
        objs.container.on('click', '.btn-idea-new', function () {
            if (canInteract) {
                loadNewForm();
            }
        });
    }

    function bindBtnNewSession() {
        objs.container.on('click', '.btn-session-new', function () {
            if (canInteract) {
                loadNewSessionForm();
            }
        });
    }

    function bindBtnSaveIdea() {
        objs.container.on('click', '#btnPostBrainstormIdea', function () {
            var valid = selectors.form.valid();
            if (valid && canInteract) {
                submitForm();
            }
        });
    }

    function bindBtnSaveSession() {
        objs.container.on('click', '#btnPostBrainstormSession', function () {
            var valid = selectors.form.valid();
            if (valid && canInteract) {
                submitForm();
            }
        });
    }

    function bindBtnVote() {
        objs.container.on('click', '.jobposition-button', function () {
            var btn = $(this);
            var item = btn.closest('.jobposition-item');
            var id = item.data('id');
            var vote = btn.data('vote');
            var sameVote = item.data('currentuservote') === vote;

            if (canInteract === 'true' && !sameVote) {
                var url = rootUrl + "/vote";

                return $.post(url, { votingItemId: id, voteValue: vote }).then(function (response) {
                    if (response.success === true) {
                        ALERTSYSTEM.ShowSuccessMessage("Awesome!", function (isConfirm) {
                            location.reload();
                        });
                    }
                    else {
                        ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                    }
                });
            }
        });
    }

    function loadSession() {
        selectors.list.html(MAINMODULE.Default.Spinner);

        var url = "/list";

        var sessionId = $('#Id').val();

        if (sessionId) {
            url += '/' + sessionId;
        }

        $.get(rootUrl + url, function (data) {
            selectors.list.html(data);
        });
    }

    function loadNewForm() {
        var sessionId = $('#jobpositioncontainer #Id').val();

        objs.container.html(MAINMODULE.Default.Spinner);

        $.get(rootUrl + "/" + sessionId + "/newidea", function (data) {
            objs.container.html(data);

            selectors.form = $("#frmBrainstormIdeaSave");

            $.validator.unobtrusive.parse(selectors.form);
        });
    }

    function loadNewSessionForm() {
        objs.container.html(MAINMODULE.Default.Spinner);

        $.get(rootUrl + "/newsession", function (data) {
            objs.container.html(data);

            selectors.form = $("#frmBrainstormSessionSave");

            $.validator.unobtrusive.parse(selectors.form);
        });
    }

    function submitForm(callback) {
        var url = selectors.form.attr('action');

        var data = selectors.form.serialize();

        $.post(url, data).done(function (response) {
            if (response.success === true) {
                if (callback) {
                    callback();
                }
                ALERTSYSTEM.ShowSuccessMessage("Awesome!", function (isConfirm) {
                    window.location = response.url;
                });
            }
            else {
                ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
            }
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    JOBPOSITION.Init();
});