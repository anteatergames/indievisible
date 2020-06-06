var STUDYCOURSEDETAILS = (function () {
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

        canInteract = objs.container.find(selectors.canInteract).val();


        var urlPlans = objs.urls.data('urlListplans');
        listPlans(urlPlans);
    }

    function bindAll() {
    }

    function listPlans(url) {
        MAINMODULE.Ajax.LoadHtml(url, objs.listPlans);
    }

    return {
        Init: init
    };
}());

$(function () {
    STUDYCOURSEDETAILS.Init();
});