var ALERTSYSTEM = (function () {
    "use strict";

    //const toast = swal.mixin({
    //    toast: true,
    //    position: 'top-end',
    //    showConfirmButton: false,
    //    timer: 3000
    //});

    function init() {
        cacheSelectors();

        bindAll();
    }

    function cacheSelectors() {
    }

    function bindAll() {
    }

    function showWarningAlert(header, text) {
        showAlert(header, text, 'warning', 'top-right', '#ffbf36');
    }

    function showAlert(header, text, icon, position, bgColor) {
        $.toast({
            heading: header,
            text: text,
            icon: icon,
            position: position,
            loaderBg: bgColor,
            hideAfter: 3500,
            stack: 6
        });

        //toast({
        //    type: 'warning',
        //    title: text
        //});
    }

    function showSuccessMessage(msg, callback) {
        // https://sweetalert2.github.io
        swal({
            title: "Good job!",
            text: msg,
            type: "success"
        })
            .then(
                function () {
                    if (callback) {
                        callback();
                    }
                }
            );
    }

    function showWarningMessage(msg, callback) {
        // https://sweetalert2.github.io
        swal({
            title: "Attention!",
            text: msg,
            type: "warning"
        })
            .then(
                function () {
                    if (callback) {
                        callback();
                    }
                }
            );
    }

    return {
        Init: init,
        ShowSuccessMessage: showSuccessMessage,
        ShowWarningMessage: showWarningMessage,
        Alert: {
            Show: showAlert,
            ShowWarning: showWarningAlert
        }
    };
}());


$(function () {
    ALERTSYSTEM.Init();
});