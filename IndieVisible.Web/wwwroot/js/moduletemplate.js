var MODULETEMPLATE = (function () {
    "use strict";

    var selectors = {};

    function init() {
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