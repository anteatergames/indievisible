var MENTORDASHBOARD = (function () {
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
        selectors.listMentors = '#divListMentors';
        selectors.listStudents = '#divListStudents';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.studyProfile = $(selectors.studyProfile);
        objs.listCourses = $(selectors.listCourses);
        objs.listMentors = $(selectors.listMentors);
        objs.listStudents = $(selectors.listStudents);
    }

    function cacheObjectsCreateEdit() {
        //objs.xpto = $(selectors.xpto);
    }

    function setCreateEdit() {
        cacheObjectsCreateEdit();
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();

        console.log(objs.studyProfile.val());

        var urlCourses = objs.urls.data('urlListmycourses');

        if (objs.studyProfile.val() === 'Mentor') {
            urlCourses = objs.urls.data('urlListcoursesbyme');

            var urlStudents = objs.urls.data('urlListmystudents');
            loadMyStudents(urlStudents);
        }
        else {
            var urlMentors = objs.urls.data('urlListmymentors');
            loadMyMentors(urlMentors);
        }

        loadMyCourses(urlCourses);
    }

    function bindAll() {
    }

    function loadMyCourses(url) {
        MAINMODULE.Ajax.LoadHtml(url, objs.listCourses);
    }

    function loadMyMentors(url) {
        MAINMODULE.Ajax.LoadHtml(url, objs.listMentors);
    }

    function loadMyStudents(url) {
        MAINMODULE.Ajax.LoadHtml(url, objs.listStudents);
    }

    return {
        Init: init
    };
}());

$(function () {
    MENTORDASHBOARD.Init();
});