var COURSEDETAILS = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.listPlans = '#divPlans';
        selectors.btnEnroll = '#btnEnroll';
        selectors.btnLeaveCourse = '#btnLeaveCourse';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.listPlans = $(selectors.listPlans);
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = $(selectors.canInteract).val();

        var urlPlans = objs.urls.data('urlListplans');
        listPlans(urlPlans);
    }

    function bindAll() {
        bindBtnEnroll();
        bindBtnLeave()
    }

    function bindBtnEnroll() {
        objs.container.on('click', selectors.btnEnroll, function (e) {
            e.preventDefault();

            var btn = $(this);
            var url = btn.data('url');

            if (canInteract) {
                MAINMODULE.Ajax.CallBackendAction(url);
            }

            return false;
        });
    }

    function bindBtnLeave() {
        objs.container.on('click', selectors.btnLeaveCourse, function (e) {
            e.preventDefault();

            var btn = $(this);
            var url = btn.data('url');

            if (canInteract) {
                MAINMODULE.Ajax.CallBackendAction(url);
            }

            return false;
        });
    }

    function listPlans(url) {
        MAINMODULE.Ajax.LoadHtml(url, objs.listPlans);
    }

    return {
        Init: init
    };
}());


$(function () {
    COURSEDETAILS.Init();
});