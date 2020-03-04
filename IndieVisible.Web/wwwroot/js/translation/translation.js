var TRANSLATION = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;
    var isIndex = false;
    var isNew = false;
    var isDetails = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.containerDetails = '#containerdetails';
        selectors.containerList = '#containerlist';
        selectors.list = '#divList';
        selectors.divListItem = '.feature-item';
        selectors.btnNew = '#btn-new';
        selectors.form = '#frmTranslationSave';
        selectors.btnSave = '#btnSaveTranslation';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.containerDetails = $(selectors.containerDetails);
        objs.containerList = $(selectors.containerList);
        objs.list = $(selectors.list);
    }

    function cacheObjectsCreateEdit() {
        //objs.xpto = $(selectors.xpto);
    }

    function setCreateEdit() {
        cacheObjectsCreateEdit();
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
        isNew = window.location.href.indexOf('add') > -1;
        isDetails = window.location.href.indexOf('details') > -1;
        isIndex = !isNew && !isDetails;

        if (isIndex) {
                var url = objs.urls.data('urlList');
                loadTranslations(false, url);
        }
        else if (isDetails) {
            bindDetails();
        }
    }

    function bindAll() {
        bindBtnNew();
        bindBtnSaveForm();
    }

    function bindBtnNew() {
        objs.container.on('click', selectors.btnNew, function () {
            var url = $(this).data('url');
            if (canInteract) {
                loadNewForm(url);
            }
        });
    }

    function bindDetails() {
        CONTENTACTIONS.BindShareContent();
    }

    function bindBtnSaveForm() {
        objs.containerDetails.on('click', selectors.btnSave, function () {
            var btn = $(this);
            var valid = objs.form.valid();

            if (valid && canInteract) {
                MAINMODULE.Common.DisableButton(btn);

                submitForm(btn);
            }
        });
    }

    function loadTranslations(fromControlSidebar, url) {
        objs.list.html(MAINMODULE.Default.Spinner);
        objs.containerDetails.html('');
        objs.containerDetails.hide();

        $.get(url, function (data) {
            if (fromControlSidebar) {
                objs.list.html(data);
                objs.containerList.show();
                cacheObjects();
            }
            else {
                objs.list.html(data);
            }
        });
    }

    function loadNewForm(url) {
        objs.containerDetails.html(MAINMODULE.Default.Spinner);
        objs.containerList.hide();

        $.get(url, function (data) {
            objs.containerDetails.html(data);
            objs.containerDetails.show();

            objs.form = $(selectors.form);

            $.validator.unobtrusive.parse(selectors.form);
            setCreateEdit();
        });
    }

    function submitForm(btn, callback) {
        var url = objs.form.attr('action');

        var data = objs.form.serialize();

        $.post(url, data).done(function (response) {
            if (response.success === true) {
                console.log(btn);
                MAINMODULE.Common.PostSaveCallback(response, btn);

                if (callback) {
                    callback();
                }

                ALERTSYSTEM.ShowSuccessMessage("Awesome!", function (isConfirm) {
                    window.location = response.url;
                });
            }
            else {
                ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
            }
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    TRANSLATION.Init();
});