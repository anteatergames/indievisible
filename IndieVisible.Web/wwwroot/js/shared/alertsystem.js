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

    function showConfirmMessage(msg, callbackYes, callbackCancel) {
        swal({
            title: "Are you sure?",
            text: msg,
            type: "question",
            showCancelButton: true,
            confirmButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
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