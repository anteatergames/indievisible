var BRAINSTORM = (function () {
    "use strict";

    var rootUrl = '/brainstorm';

    var selectors = {};
    var canInteract = false;
    var newIdea = false;

    function init() {
        setSelectors();

        bindAll();

        canInteract = selectors.container.find('#caninteract').val();
        newIdea = window.location.href.indexOf('newidea') > -1;

        if (!newIdea) {
            loadSession();
        }
    }

    function setSelectors() {
        selectors.container = $(".content");
        selectors.toolbar = $("#divToolbar");
        selectors.list = $("#divList");
        selectors.btnPostVotingItem = $("#btnPostVotingItem");
        selectors.form = $("#frmBrainstormIdeaSave");
    }

    function bindAll() {
        bindBtnNewIdea();
        bindBtnNewSession();
        bindBtnSaveIdea();
        bindBtnSaveSession();
        bindBtnVote();
    }

    function bindBtnNewIdea() {
        selectors.container.on('click', '.btn-idea-new', function () {
            if (canInteract) {
                loadNewForm();
            }
        });
    }

    function bindBtnNewSession() {
        selectors.container.on('click', '.btn-session-new', function () {
            if (canInteract) {
                loadNewSessionForm();
            }
        });
    }

    function bindBtnSaveIdea() {
        selectors.container.on('click', '#btnPostBrainstormIdea', function () {
            var valid = selectors.form.valid();
            if (valid && canInteract) {
                submitForm();
            }
        });
    }

    function bindBtnSaveSession() {
        selectors.container.on('click', '#btnPostBrainstormSession', function () {
            var valid = selectors.form.valid();
            if (valid && canInteract) {
                submitForm();
            }
        });
    }

    function bindBtnVote() {
        selectors.container.on('click', '.brainstorm-button', function () {
            var btn = $(this);
            var item = btn.closest('.brainstorm-item');
            var id = item.data('id');
            var vote = btn.data('vote');
            var sameVote = item.data('currentuservote') === vote;

            if (canInteract && !sameVote) {
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
        var sessionId = $('#brainstormcontainer #Id').val();

        selectors.container.html(MAINMODULE.Default.Spinner);

        $.get(rootUrl + "/" + sessionId + "/newidea", function (data) {
            selectors.container.html(data);

            selectors.form = $("#frmBrainstormIdeaSave");

            $.validator.unobtrusive.parse(selectors.form);
        });
    }

    function loadNewSessionForm() {
        selectors.container.html(MAINMODULE.Default.Spinner);

        $.get(rootUrl + "/newsession", function (data) {
            selectors.container.html(data);

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
    BRAINSTORM.Init();
});