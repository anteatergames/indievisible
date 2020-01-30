var JOBPOSITION = (function () {
    "use strict";

    var rootUrl = '/work/jobposition';

    var selectors = {};
    var objs = {};
    var canInteract = false;
    var newPosition = false;
    var details = false;

    function init() {
        setSelectors();
        cacheObjects();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
        newPosition = window.location.href.indexOf('add') > -1;
        details = window.location.href.indexOf('details') > -1;

        if (!newPosition && !details) {
            loadJobPositions();
        }

        objs.ddlStatus.removeClass('invisible').show();
    }

    function setSelectors() {
        selectors.canInteract = '#caninteract';
        selectors.container = '.content';
        selectors.list = '#divList';
        selectors.btnNewJobPosition = '#btn-jobposition-new';
        selectors.btnListMine = '#btn-jobposition-listmine';
        selectors.form = '#frmJobPositionSave';
        selectors.btnSave = '#btnPostJobPosition';
        selectors.ddlStatus = '#ddlStatus';
    }

    function cacheObjects() {
        objs.container = $(selectors.container);
        objs.list = $(selectors.list);
        objs.ddlStatus = $(selectors.ddlStatus);
    }

    function bindAll() {
        bindBtnNewJobPosition();
        bindBtnListMine();
        bindBtnSaveForm();
        bindBtnApply();
        bindStatusChange();
    }

    function bindStatusChange() {
        objs.container.on('change', selectors.ddlStatus, function (e) {
            var selectedStatus = $(this).val();
            var url = $(this).data('url');
            var id = $(this).data('id');

            var data = {
                selectedStatus: selectedStatus,
                jobPositionId: id
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

    function bindBtnNewJobPosition() {
        objs.container.on('click', selectors.btnNewJobPosition, function () {
            if (canInteract) {
                loadNewJobPositionForm();
            }
        });
    }

    function bindBtnListMine() {
        objs.container.on('click', selectors.btnListMine, function () {
            if (canInteract) {
                loadMyJobPositions();
            }
        });
    }

    function bindBtnSaveForm() {
        objs.container.on('click', selectors.btnSave, function () {
            var valid = objs.form.valid();
            if (valid && canInteract) {
                submitForm();
            }
        });
    }

    function bindBtnApply() {
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

    function loadJobPositions() {
        objs.list.html(MAINMODULE.Default.Spinner);

        var url = "/list";

        $.get(rootUrl + url, function (data) {
            objs.list.html(data);
        });
    }

    function loadMyJobPositions() {
        objs.list.html(MAINMODULE.Default.Spinner);

        var url = "/listmine";

        $.get(rootUrl + url, function (data) {
            objs.list.html(data);
        });
    }

    function loadNewJobPositionForm() {
        objs.container.html(MAINMODULE.Default.Spinner);

        $.get(rootUrl + "/new", function (data) {
            objs.container.html(data);

            objs.form = $(selectors.form);

            $.validator.unobtrusive.parse(selectors.form);
        });
    }

    function submitForm(callback) {
        var url = objs.form.attr('action');

        var data = objs.form.serialize();

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