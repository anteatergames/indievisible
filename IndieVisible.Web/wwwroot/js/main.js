var MAINMODULE = (function () {
    "use strict";

    var spinnerCenter = '<div class="spinner flex-square rectangle bg-transparent"><div class="flex-square-inner"><div class="flex-square-inner-content text-dark"><i class="fa fa-spinner fa-3x fa-spin"></i></div></div></div>';

    var spinnerTop = '<div class="bg-transparent"><div class="flex-square-inner"><div class="flex-square-inner-content text-dark"><i class="fa fa-spinner fa-3x fa-spin"></i></div></div></div>';

    var spinnerBtn = '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>';

    var doneBtn = '<i class="fas fa-check"></i>';

    var selectors = {};
    var objs = {};
    var translatedMessages = {};
    var saveBtnOriginalText = '';

    function init() {
        setSelectors();
        cacheObjects();

        bindAll();

        setGlobalAjax();

        loadTranslatedMessages();

        loadNotifications();

        $('[data-toggle="tooltip"]').tooltip();

        showMessage();
    }

    function setSelectors() {
        selectors.notificationsMenu = "#notificationsMenu";
        selectors.spanMessage = "#spanMessage";
        selectors.translatedJavascriptMessages = "#translatedJavascriptMessages";
        selectors.sharePopup = '.share-popup';
        selectors.btnInteractionShare = '.btn-interaction-share';
    }

    function cacheObjects() {
        objs.notificationsMenu = $(selectors.notificationsMenu);
        objs.spanMessage = $(selectors.spanMessage);
        objs.translatedJavascriptMessages = $(selectors.translatedJavascriptMessages);
    }

    function bindAll() {
        bindMenu();
        bindNotImplemented();
        bindYouNeedToLogIn();
    }

    function bindMenu() {
        $('body').on('click', '#mainmenu li', function () {
            var clickedMenu = $(this);
            var siblings = clickedMenu.siblings();

            siblings.removeClass('active');

            clickedMenu.addClass('active');
        });
    }
    function loadTranslatedMessages() {
        objs.translatedJavascriptMessages.find('.msg').each(function (index, element) {
            var msgId = $(this).data('msgId');
            var text = $(this).text();

            translatedMessages[msgId] = text;
        });
    }

    function showMessage() {
        var msg = objs.spanMessage.text();
        if (msg !== undefined && msg.length > 0) {
            ALERTSYSTEM.Toastr.ShowWarning(msg);
        }
    }

    function bindNotImplemented() {
        $('body').on('click', '.notimplemented', function (e) {
            e.preventDefault();

            var msg = translatedMessages['msgNotImplementedYet'];

            ALERTSYSTEM.Toastr.ShowWarning(msg);

            return false;
        });
    }

    function bindYouNeedToLogIn() {
        $('body').on('click', '.needlogin', function (e) {
            e.preventDefault();
            var msgId = $(this).data('msgId');

            var msg = translatedMessages[msgId];

            ALERTSYSTEM.Toastr.ShowWarning(msg);

            return false;
        });
    }

    function setGlobalAjax() {
        $(document).ajaxStart(function () { Pace.restart(); });
    }

    function loadNotifications() {
        $.get("/home/notifications", function (data) { objs.notificationsMenu.html(data); });
    }

    function handlePointsEarned(response) {
        console.log(response.pointsEarned);
        if (response.pointsEarned > 0) {
            var msg = translatedMessages['mgsPointsEarned'];
            msg = msg.replace('0', response.pointsEarned);

            ALERTSYSTEM.Toastr.PointsEarned(msg);
        }
    }

    function setStickyElement(selector) {
        var minimumOffset = 60;
        $(selector).sticky({ topSpacing: minimumOffset });
    }

    function disableButton(btn) {
        btn.prop('disabled', true);
        saveBtnOriginalText = btn.html();
        btn.html(MAINMODULE.Default.SpinnerBtn);
    }

    function setButtonWithError(btn) {
        saveBtnOriginalText = btn.html();
        var errMsg = btn.data('errorMsg');
        btn.removeClass('btn-primary').addClass('btn-warning').html(errMsg);
    }

    function removeErrorFromButton(btn) {
        btn.removeClass('btn-warning').addClass('btn-primary').html(saveBtnOriginalText);
    }

    function postSaveCallback(response, btn) {
        if (response.success === true) {
            btn.removeClass('btn-primary').addClass('btn-success').html(MAINMODULE.Default.DoneBtn);
        }
        else {
            btn.html(saveBtnOriginalText);
            btn.prop('disabled', false);
        }
    }

    function renameInputs(objContainer, itemSelector, propPreffix) {
        var count = 0;

        var idPreffix = propPreffix + "_0__";
        var namePreffix = propPreffix + "[0].";

        objContainer.find(itemSelector).each(function (index, element) {
            var item = $(this);

            item.find(':input').each(function (index2, element2) {
                var inputId = $(this).attr('id');
                var inputName = $(this).attr('name');

                if (inputId !== undefined && inputName !== undefined) {
                    var idProp = inputId.split('__')[1];
                    var newId = idPreffix.replace('0', count) + idProp;
                    $(this).attr('id', newId);

                    var nameProp = inputName.split('].')[1];
                    var newName = namePreffix.replace('0', count) + nameProp;
                    $(this).attr('name', newName);

                    var describedBy = $(this).attr('aria-describedby');
                    if (describedBy !== undefined) {
                        var describedByProp = describedBy.split('__')[1];
                        var newdescribedBy = idPreffix.replace('0', count) + describedByProp;
                        $(this).attr('aria-describedby', newdescribedBy);
                    }
                }
            });

            item.find('span[data-valmsg-for]').each(function (index2, element2) {
                var msgFor = $(this).attr('data-valmsg-for');

                if (msgFor !== undefined) {
                    var msgForProp = msgFor.split('].')[1];
                    var newMsgFor = namePreffix.replace('0', count) + msgForProp;
                    $(this).attr('data-valmsg-for', newMsgFor);
                }

                var innerSpan = $(this).find('span');

                if (innerSpan.length > 0) {
                    var spanId = innerSpan.attr('id');
                    var idProp = spanId.split('__')[1];
                    var newId = idPreffix.replace('0', count) + idProp;
                    innerSpan.attr('id', newId);
                }
            });

            count++;
        });
    }

    return {
        Init: init,
        Layout: {
            SetStickyElement: setStickyElement
        },
        Common: {
            HandlePointsEarned: handlePointsEarned,
            TranslatedMessages: translatedMessages,
            DisableButton: disableButton,
            SetButtonWithError: setButtonWithError,
            RemoveErrorFromButton: removeErrorFromButton,
            PostSaveCallback: postSaveCallback,
            RenameInputs: renameInputs
        },
        Default: {
            Spinner: spinnerCenter,
            SpinnerTop: spinnerTop,
            SpinnerBtn: spinnerBtn,
            DoneBtn: doneBtn
        }
    };
}());

$(function () {
    MAINMODULE.Init();
});