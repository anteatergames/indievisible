var MAINMODULE = (function () {
    "use strict";

    var spinnerCenter = '<div class="spinner flex-square rectangle bg-transparent"><div class="flex-square-inner"><div class="flex-square-inner-content text-dark"><i class="fa fa-spinner fa-3x fa-spin"></i></div></div></div>';

    var spinnerTop = '<div class="bg-transparent text-center"><div class="flex-square-inner"><div class="flex-square-inner-content text-dark"><i class="fa fa-spinner fa-3x fa-spin"></i></div></div></div>';

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
        MAINMODULE.Ajax.LoadHtml("/home/notifications", objs.notificationsMenu);
    }

    function handlePointsEarned(response) {
        if (response.pointsEarned > 0) {
            var msg = translatedMessages['mgsPointsEarned'];
            msg = msg.replace('0', response.pointsEarned);

            if (response.message) {
                msg = response.message + ' ' + msg;
            }

            ALERTSYSTEM.Toastr.PointsEarned(msg);

            return true;
        }

        return false;
    }

    function setStickyElement(selector, offset, getWidthFrom) {
        var minimumOffset = 60;

        if (offset !== undefined) {
            minimumOffset = offset;
        }

        $(selector).sticky({
            topSpacing: minimumOffset,
            widthFromWrapper: getWidthFrom === undefined ? true : false,
            getWidthFrom: getWidthFrom === undefined ? '' : getWidthFrom
        });
    }

    function disableButton(btn) {
        btn.addClass('disabled');
        saveBtnOriginalText = btn.html();
        btn.html(MAINMODULE.Default.SpinnerBtn);
    }

    function enableButton(btn) {
        btn.removeClass('disabled');
    }

    function setButtonWithError(btn) {
        saveBtnOriginalText = btn.html();
        var errMsg = btn.data('errorMsg');
        btn.html(errMsg);
    }

    function removeErrorFromButton(btn) {
        btn.removeClass('disabled').html(saveBtnOriginalText);
    }

    function postSaveCallback(response, btn) {
        if (response.success === true) {
            btn.removeClass('disabled').html(MAINMODULE.Default.DoneBtn);
        }
        else {
            btn.html(saveBtnOriginalText);
            btn.removeClass('disabled');
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

    function getDeleteMessages(btn) {
        var msg = btn.data('confirmationmessage');
        var confirmationTitle = btn.data('confirmationtitle');
        var confirmationButtonText = btn.data('confirmationbuttontext');
        var cancelButtonText = btn.data('cancelbuttontext');

        if (msg === undefined) {
            msg = 'Are you sure you want to delete this?';
        }

        if (confirmationTitle === undefined) {
            confirmationTitle = 'Are you sure?';
        }

        if (confirmationButtonText === undefined) {
            confirmationButtonText = 'Yes, delete it!';
        }

        if (cancelButtonText === undefined) {
            cancelButtonText = 'Cancel';
        }

        return {
            msg: msg,
            confirmationTitle: confirmationTitle,
            confirmationButtonText: confirmationButtonText,
            cancelButtonText: cancelButtonText
        };
    }

    function handleSuccessDefault(response, callback, successCallback) {
        if (callback) {
            callback(response);
        }

        if (response.message) {
            if (successCallback) {
                successCallback();
            }

            ALERTSYSTEM.Toastr.ShowSuccess(response.message, function (result) {

                if (response.url) {
                    window.location = response.url;
                }
            });
        }
        else {
            if (response.url) {
                window.location = response.url;
            }
        }
    }

    function bindPopOvers(multiple) {
        if (multiple) {
            $("[data-toggle='popover']").each(function (index, element) {
                var data = $(element).data();
                if (data.target) {
                    var contentElementId = data.target;
                    var contentHtml = $(contentElementId).html().trim();
                    data.content = contentHtml;
                }

                $(element).popover({ html: true });
            });
        } else {
            $("[data-toggle='popover']").popover({ html: true });
        }
    }

    async function getHtml(url) {

        var useJquery = false;
        var promise;

        if (useJquery) {
            promise = $.get(url);
        }
        else {
            promise = await fetch(url, {
                method: 'GET',
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                }
            }).then(function (response) {
                return response.text();
            });
        }

        return promise;
    }

    async function loadHtml(url, listObj) {
        var idList = '';

        if (listObj instanceof jQuery) {
            idList = listObj.attr('id');
        }
        else {
            idList = listObj;
        }

        if (idList === undefined) {
            return Promise.resolve();
        }

        document.querySelector('#' + idList).innerHTML = MAINMODULE.Default.SpinnerTop;

        const promise = await getHtml(url)
            .then(function (body) {
                document.querySelector('#' + idList).innerHTML = body;

                //lazyLoadInstance.update();

                return body;
            });

        return promise;
    }

    return {
        Init: init,
        Layout: {
            SetStickyElement: setStickyElement
        },
        Ajax: {
            GetHtml: getHtml,
            LoadHtml: loadHtml
        },
        Common: {
            HandlePointsEarned: handlePointsEarned,
            HandleSuccessDefault: handleSuccessDefault,
            TranslatedMessages: translatedMessages,
            DisableButton: disableButton,
            EnableButton: enableButton,
            SetButtonWithError: setButtonWithError,
            RemoveErrorFromButton: removeErrorFromButton,
            PostSaveCallback: postSaveCallback,
            RenameInputs: renameInputs,
            GetDeleteMessages: getDeleteMessages,
            BindPopOvers: bindPopOvers
        },
        Default: {
            Spinner: spinnerCenter,
            SpinnerTop: spinnerTop,
            SpinnerBtn: spinnerBtn,
            DoneBtn: doneBtn
        }
    };
}());

MAINMODULE.Init();

//var lazyLoadInstance = new LazyLoad({
//    elements_selector: ".lazyload",
//    callback_loaded: (el) => { el.classList.remove("blur-up"); }
//});