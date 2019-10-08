var ARTICLES = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        ACTIVITYFEED.Init(objs.divActivityFeed, FEEDTYPE.ARTICLES);

        ACTIVITYFEED.Methods.LoadActivityFeed();
    }

    function setSelectors() {
        selectors.divActivityFeed = '#divActivityFeed';
    }

    function cacheObjs() {
        objs.divActivityFeed = $('#divActivityFeed');
    }

    function bindAll() {
    }


    return {
        Init: init
    };
}());


$(function () {
    ARTICLES.Init();
});