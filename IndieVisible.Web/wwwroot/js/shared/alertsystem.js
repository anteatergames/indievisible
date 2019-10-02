var ALERTSYSTEM = (function () {
    "use strict";

    //const toast = swal.mixin({
    //    toast: true,
    //    position: 'top-end',
    //    showConfirmButton: false,
    //    timer: 3000
    //});

    // https://sweetalert2.github.io

    function init() {
        cacheSelectors();

        bindAll();
    }

    function cacheSelectors() {
    }

    function bindAll() {
    }

    function showWarningAlert(header, text) {
        showAlert(text, 'warning');
    }

    function showAlert(text, type) {
        swal({
            toast: true,
            position: 'top-end',
            type: type,
            showConfirmButton: false,
            title: text,
            timer: 3000
        });
    }

    function showSuccessMessage(msg, callback) {
        swal({
            title: "Good job!",
            text: msg,
            type: "success"
        }).then(
            function () {
                if (callback) {
                    callback();
                }
            }
        );
    }

    function showWarningMessage(msg, callback) {
        swal({
            title: "Attention!",
            text: msg,
            type: "warning"
        }).then(
            function () {
                if (callback) {
                    callback();
                }
            }
        );
    }

    function showConfirmMessage(title, msg, confirmButtonText, cancelButtonText, callbackYes, callbackCancel) {
        swal({
            title: title,
            text: msg,
            type: "question",
            showCancelButton: true,
            confirmButtonColor: '#d33',
            confirmButtonText: confirmButtonText,
            cancelButtonText: cancelButtonText
        }).then(
            function (result) {
                if (result.value) {
                    console.log('yes');
                    if (callbackYes) {
                        callbackYes();
                    }
                }
                else {
                    console.log('no');
                    if (callbackCancel) {
                        callbackCancel();
                    }
                }
            }
        );
    }

    return {
        Init: init,
        ShowSuccessMessage: showSuccessMessage,
        ShowWarningMessage: showWarningMessage,
        ShowConfirmMessage: showConfirmMessage,
        Toastr: {
            ShowWarning: showWarningAlert
        }
    };
}());


$(function () {
    ALERTSYSTEM.Init();
});