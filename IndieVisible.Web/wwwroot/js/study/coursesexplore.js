var COURSESEXPLORE = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
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

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

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

    return {
        Init: init
    };
}());

$(function () {
    COURSESEXPLORE.Init();
});