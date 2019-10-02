var MAINMODULE = (function () {
    "use strict";

    var spinner = '<div class="spinner flex-square rectangle bg-transparent"><div class="flex-square-inner"><div class="flex-square-inner-content text-dark"><i class="fa fa-spinner fa-3x fa-spin"></i></div></div></div>';

    var spinner2 = '<div class="bg-transparent"><div class="flex-square-inner"><div class="flex-square-inner-content text-dark"><i class="fa fa-spinner fa-3x fa-spin"></i></div></div></div>';

    var selectors = {};

    function init() {

        cacheSelectors();

        bindAll();

        setGlobalAjax();

        loadNotifications();

        $('[data-toggle="tooltip"]').tooltip();

        showMessage();
    }

    function cacheSelectors() {
        selectors.notificationsMenu = $("#notificationsMenu");
        selectors.spanMessage = $("#spanMessage");
    }

    function bindAll() {
        bindNotImplemented();
    }

    function showMessage() {
        var msg = selectors.spanMessage.text();
        if (msg !== undefined && msg.length > 0) {
            ALERTSYSTEM.Toastr.ShowWarning("Attention!", msg);
        }
    }

    function bindNotImplemented() {
        $("body").on("click", ".notimplemented", function (e) {
            e.preventDefault();

            ALERTSYSTEM.ShowWarningMessage('KEEP CALM AND READ THIS', 'The feature you clicked is not implemented yet.');

            return false;
        });
    }

    function setGlobalAjax() {
        $(document).ajaxStart(function () { Pace.restart(); });
    }


    function loadNotifications() {
        $.get("/home/notifications", function (data) { selectors.notificationsMenu.html(data); });
    }

    return {
        Init: init,
        Default: {
            Spinner: spinner,
            Spinner2: spinner2
        }
    };
}());


$(function () {
    MAINMODULE.Init();
});