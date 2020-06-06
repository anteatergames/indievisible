var STUDYPROFILESELECTOR = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    var canInteract = false;

    function setSelectors() {
        selectors.container = '.content-wrapper';
        selectors.canInteract = '#caninteract';
        selectors.btnSetStudyProfile = '.btnsetstudyprofile';
    }

    function cacheObjects() {
        objs.container = $(selectors.container);
    }

    function init() {
        setSelectors();
        cacheObjects();

        canInteract = objs.container.find(selectors.canInteract).val();

        bindAll();
    }

    function bindAll() {
        bindBtnSetStudyProfile();
    }

    function bindBtnSetStudyProfile() {
        objs.container.on('click', selectors.btnSetStudyProfile, function (e) {
            e.preventDefault();

            var btn = $(this);
            var url = btn.prop('href');

            if (canInteract) {
                setStudyProfile(url);
            }

            return false;
        });
    }

    function setStudyProfile(url, callback) {
        $.post(url).done(function (response) {
            if (response.success === true) {
                if (callback) {
                    callback(response);
                }
                ALERTSYSTEM.ShowSuccessMessage(response.message, function () {
                    if (response.url) {
                        window.location = response.url;
                    }
                });
            }
            else {
                ALERTSYSTEM.ShowWarningMessage(response.message);
            }
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    STUDYPROFILESELECTOR.Init();
});