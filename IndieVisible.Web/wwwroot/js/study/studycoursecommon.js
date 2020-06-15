var STUDYCOURSECOMMON = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.btnDelete = '.btn-course-delete';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = $(selectors.canInteract).val();
    }

    function bindAll() {
        bindDeleteCourse();
    }

    function bindDeleteCourse() {
        objs.container.on('click', selectors.btnDelete, function (e) {
            e.preventDefault();

            var btn = $(this);

            if (canInteract) {
                deleteCourse(btn);
            }

            return false;
        });
    }

    function deleteCourse(btn, callback) {
        var url = btn.data('url');

        var msgs = MAINMODULE.Common.GetDeleteMessages(btn);

        ALERTSYSTEM.ShowConfirmMessage(msgs.confirmationTitle, msgs.msg, msgs.confirmationButtonText, msgs.cancelButtonText, function () {
            $.ajax({
                url: url,
                type: 'DELETE'
            }).done(function (response) {
                if (response.success) {
                    if (callback) {
                        callback(response);
                    }

                    MAINMODULE.Common.HandleSuccessDefault(response);
                }
                else {
                    ALERTSYSTEM.ShowWarningMessage(response.message);
                }
            });
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    STUDYCOURSECOMMON.Init();
});