var MODULETEMPLATE = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    function setSelectors() {
        //selector.test = '#test';
    }

    function cacheObjs() {
        //objs.test = $(selector.test);
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();
    }

    function bindAll() {
    }


    return {
        Init: init
    };
}());


$(function () {
    MODULETEMPLATE.Init();
});