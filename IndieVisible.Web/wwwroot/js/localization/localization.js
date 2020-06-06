var LOCALIZATION = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    var canInteract = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.containerDetails = '#containerdetails';
        selectors.containerList = '#containerlist';
        selectors.list = '#divList';
        selectors.divListItem = '.feature-item';
        selectors.myProjects = '#divMyProjects';
    }

    function cacheObjsCommon() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.containerDetails = $(selectors.containerDetails);
    }

    function cacheObjs() {
        objs.containerDetails = $(selectors.containerDetails);
        objs.containerList = $(selectors.containerList);
        objs.list = $(selectors.list);
        objs.myProjects = $(selectors.myProjects);
    }

    function init() {
        setSelectors();
        cacheObjsCommon();

        cacheObjs();

        canInteract = objs.container.find(selectors.canInteract).val() === "true";

        var url = objs.urls.data('urlList');
        var urlMine = objs.urls.data('urlMine');

        loadProjects(false, url);

        if (canInteract) {
            loadMyProjects(false, urlMine);
        }
    }

    function loadProjects(fromControlSidebar, url) {
        objs.list.html(MAINMODULE.Default.Spinner);
        objs.containerDetails.html('');
        objs.containerDetails.hide();

        MAINMODULE.Ajax.LoadHtml(url, objs.list);
    }

    function loadMyProjects(fromControlSidebar, url) {
        objs.myProjects.html(MAINMODULE.Default.SpinnerTop);

        MAINMODULE.Ajax.LoadHtml(url, objs.myProjects);
    }

    return {
        Init: init
    };
}());

$(function () {
    LOCALIZATION.Init();
});

if (window.Dropzone !== undefined) {
    Dropzone.autoDiscover = false;
}
