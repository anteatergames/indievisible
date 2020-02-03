var JOBPROFILESELECTOR = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    var canInteract = false;

    function setSelectors() {
        selectors.container = '.content';
        selectors.canInteract = '#caninteract';
        selectors.btnSetJobProfile = '.btnsetjobprofile';
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
        bindBtnSetJobProfile();
    }

    function bindBtnSetJobProfile() {
        objs.container.on('click', selectors.btnSetJobProfile, function (e) {
            e.preventDefault();

            var btn = $(this);
            var url = btn.prop('href');

            if (canInteract) {
                setJobProfile(url);
            }

            return false;
        });
    }

    function setJobProfile(url, callback) {
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
    JOBPROFILESELECTOR.Init();
});