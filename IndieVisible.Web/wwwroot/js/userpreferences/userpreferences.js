var USERPREFERENCES = (function () {
    "use strict";

    function init() {
        bindAll();
    }

    function bindAll() {
        bindSelect2();
    }

    function bindSelect2() {
        $('.select2').select2();
    }

    return {
        Init: init
    };
}());

$(function () {
    USERPREFERENCES.Init();
});