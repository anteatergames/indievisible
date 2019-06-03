var MODULETEMPLATE = (function () {
    "use strict";

    function init() {
        console.log('init');

        bindAll();
    }

    function bindAll() {
        //bindSave();
    }

    function bindSave() {
    }


    return {
        Init: init
    };
}());


$(function () {
    MODULETEMPLATE.Init();
});