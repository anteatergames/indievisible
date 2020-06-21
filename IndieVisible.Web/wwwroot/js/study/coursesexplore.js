var COURSESEXPLORE = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.studyProfile = '#studyProfile';
        selectors.container = '#featurecontainer';
        selectors.listCourses = '#divListCourses';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.studyProfile = $(selectors.studyProfile);
        objs.listCourses = $(selectors.listCourses);
    }

    function cacheObjectsCreateEdit() {
        //objs.xpto = $(selectors.xpto);
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();

        console.log(objs.studyProfile.val());

        var urlCourses = objs.urls.data('urlListcourses');
        listCourses(urlCourses);
    }

    function bindAll() {
    }

    function listCourses(url) {
        var urlBack = objs.urls.data('urlBack');

        url += '?backUrl=' + encodeURI(urlBack);

        MAINMODULE.Ajax.LoadHtml(url, objs.listCourses);
    }

    function loadMyMentors(url) {
        MAINMODULE.Ajax.LoadHtml(url, objs.listMentors);
    }

    return {
        Init: init
    };
}());

$(function () {
    COURSESEXPLORE.Init();
});