var COMMONEDIT = (function () {
    "use strict";

    function init() {
    }


    function resetValidator(formObject) {
        formObject.removeData("validator").removeData("unobtrusiveValidation");

        $.validator.unobtrusive.parse(formObject);
    }

    return {
        Init: init,
        ResetValidator: resetValidator
    };
}());

COMMONEDIT.Init();