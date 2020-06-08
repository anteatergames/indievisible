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

    function showSuccessAlert(text, callback) {
        showAlert(text, 'success', callback);
    }

    function showWarningAlert(text, callback) {
        showAlert(text, 'warning', callback);
    }

    function showPointsEarned(text, callback) {
        showAlert(text, 'info', callback);
    }

    function showAlert(text, type, callback) {
        Swal.fire({
            toast: true,
            position: 'top-end',
            type: type,
            showConfirmButton: false,
            title: text,
            timer: 3000
        }).then(
            function (result) {
                if (callback) {
                    callback(result);
                }
            }
        );
    }

    function showSuccessMessage(msg, callback) {
        Swal.fire({
            title: "Good job!",
            text: msg,
            type: "success"
        }).then(
            function (result) {
                if (callback) {
                    callback(result);
                }
            }
        );
    }

    function showWarningMessage(msg, callback) {
        Swal.fire({
            toast: true,
            position: 'top-end',
            title: msg,
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
        Swal.fire({
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
            ShowSuccess: showSuccessAlert,
            ShowWarning: showWarningAlert,
            PointsEarned: showPointsEarned
        }
    };
}());

$(function () {
    ALERTSYSTEM.Init();
});