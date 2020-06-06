var STUDYCOURSEEDIT = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;
    var isNew = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.form = '#frmCourseSave';
        selectors.btnSave = '#btnSaveCourse';
        selectors.txtAreaDescription = '#Description';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.form = $(selectors.form);
        objs.txtAreaDescription = $(selectors.txtAreaDescription);
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
        isNew = window.location.href.indexOf('add') > -1;

        if (isNew) {
            console.log('new course');
        }

        MAINMODULE.Common.BindPopOvers();
    }

    function bindAll() {
        bindSelect2();
        bindBtnSaveForm();
    }

    function bindSelect2() {
        $('select.select2').each(function () {
            if ($(this).data('select2') === undefined) {
                $(this).select2({
                    width: 'element'
                });
            }
        });
    }

    function bindBtnSaveForm() {
        objs.container.on('click', selectors.btnSave, function () {
            var btn = $(this);
            var valid = objs.form.valid();

            if (valid && canInteract) {
                MAINMODULE.Common.DisableButton(btn);

                submitForm(btn);
            }
        });
    }

    function submitForm(btn, callback) {
        var url = objs.form.attr('action');


        var text = objs.txtAreaDescription.val().replace(/\n/g, '<br>\n');
        //objs.txtAreaDescription.val(text);

        //var data = objs.form.serialize();

        var data2 = MAINMODULE.Tools.GetFormData(objs.form);

        data2.description = text;

        $.post(url, data2).done(function (response) {
            if (response.success === true) {
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
    STUDYCOURSEEDIT.Init();
});