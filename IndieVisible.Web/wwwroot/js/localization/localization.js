var LOCALIZATION = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

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

        var url = objs.urls.data('urlList');
        var urlMine = objs.urls.data('urlMine');

        loadProjects(false, url);
        loadMyProjects(false, urlMine);
    }

    function loadProjects(fromControlSidebar, url) {
        objs.list.html(MAINMODULE.Default.Spinner);
        objs.containerDetails.html('');
        objs.containerDetails.hide();

        $.get(url, function (data) {
            if (fromControlSidebar) {
                objs.list.html(data);
                objs.containerList.show();
                cacheObjects();
            }
            else {
                objs.list.html(data);
            }
        });
    }

    function loadMyProjects(fromControlSidebar, url) {
        objs.myProjects.html(MAINMODULE.Default.SpinnerTop);

        $.get(url, function (data) {
            if (fromControlSidebar) {
                objs.myProjects.html(data);
                objs.containerList.show();
                cacheObjects();
            }
            else {
                objs.myProjects.html(data);
            }
        });
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
