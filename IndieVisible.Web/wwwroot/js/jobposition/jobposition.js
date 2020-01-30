var JOBPOSITION = (function () {
    "use strict";

    var rootUrl = '/work/jobposition';

    var selectors = {};
    var objs = {};
    var canInteract = false;
    var isIndex = false;
    var isNew = false;
    var isDetails = false;

    function init() {
        setSelectors();
        cacheObjects();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
        isNew = window.location.href.indexOf('add') > -1;
        isDetails = window.location.href.indexOf('details') > -1;
        isIndex = !isNew && !isDetails;

        if (isIndex) {
            loadJobPositions(false, rootUrl + '/list');
        }

        if (isDetails) {
            objs.ddlStatus.removeClass('invisible').show();
        }
    }

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.container = '.content';
        selectors.containerDetails = '#containerdetails';
        selectors.containerList = '#containerlist';
        selectors.list = '#divList';
        selectors.divListItem = '.jobposition-item';
        selectors.btnNewJobPosition = '#btn-jobposition-new';
        selectors.btnListMine = '#btn-jobposition-listmine';
        selectors.form = '#frmJobPositionSave';
        selectors.btnSave = '#btnPostJobPosition';
        selectors.ddlStatus = '#ddlStatus';
        selectors.btnDeleteJobPosition = '.btnDeleteJobPosition';
    }

    function cacheObjects() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.containerDetails = $(selectors.containerDetails);
        objs.containerList = $(selectors.containerList);
        objs.list = $(selectors.list);
        objs.ddlStatus = $(selectors.ddlStatus);
    }

    function bindAll() {
        bindBtnNewJobPosition();
        bindBtnListMine();
        bindBtnSaveForm();
        bindBtnApply();
        bindStatusChange();
        bindDeleteJobPosition();
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
        objs.controlsidebar.on('click', selectors.btnNewJobPosition, function () {
            if (canInteract) {
                loadNewJobPositionForm();
            }
        });
    }

    function bindBtnListMine() {
        objs.controlsidebar.on('click', selectors.btnListMine, function () {
            var url = $(this).data('url');
            if (canInteract) {
                loadJobPositions(true, url);
            }
        });
    }

    function bindBtnSaveForm() {
        objs.containerDetails.on('click', selectors.btnSave, function () {
            var valid = objs.form.valid();
            if (valid && canInteract) {
                submitForm();
            }
        });
    }


    function bindDeleteJobPosition() {
        objs.containerList.on('click', selectors.btnDeleteJobPosition, function (e) {
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
                        btn.closest(selectors.divListItem).remove();
                        loadJobPositions(false, rootUrl + '/list');

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

    function bindBtnApply() {
        objs.containerDetails.on('click', '.jobposition-button', function () {
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

    function loadJobPositions(fromControlSidebar, url) {
        objs.list.html(MAINMODULE.Default.Spinner);

        $.get(url, function (data) {
            if (fromControlSidebar) {
                objs.containerDetails.hide();
                objs.list.html(data);
                objs.containerList.show();
                cacheObjects();
            }
            else {
                objs.list.html(data);
            }
        });
    }

    function loadNewJobPositionForm() {
        objs.containerDetails.html(MAINMODULE.Default.Spinner);
        objs.containerList.hide();

        $.get(rootUrl + "/new", function (data) {
            objs.containerDetails.html(data);
            objs.containerDetails.show();

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