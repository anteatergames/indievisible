var TRANSLATION = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;
    var isIndex = false;
    var isNew = false;
    var isDetails = false;
    var isEdit = false;

    var propPrefix = 'Terms';

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.containerDetails = '#containerdetails';
        selectors.containerList = '#containerlist';
        selectors.list = '#divList';
        selectors.divListItem = '.feature-item';
        selectors.myProjects = '#divMyProjects';
        selectors.btnNew = '#btn-new';
        selectors.form = '#frmTranslationSave';
        selectors.btnSave = '#btnSaveTranslation';
        selectors.btnEdit = '.btnEditTranslationProject';
        selectors.btnDelete = '.btnDeleteTranslationProject';
        selectors.divTerms = '#divTerms';
        selectors.term = '.translation-term';
        selectors.template = '.translation-term.template';
        selectors.btnAddTerm = '#btn-translation-term-add';
        selectors.ddlLanguage = '#Language';
    }

    function cacheObjsCommon() {
        console.log('cacheObjsCommon');
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.containerDetails = $(selectors.containerDetails);
    }

    function cacheObjsIndex() {
        console.log('cacheObjsIndex');
        objs.containerDetails = $(selectors.containerDetails);
        objs.containerList = $(selectors.containerList);
        objs.list = $(selectors.list);
        objs.myProjects = $(selectors.myProjects);
    }

    function cacheObjsDetails() {
        //objs.form = $(selectors.form);
    }

    function cacheOBjsCreateEdit() {
        objs.form = $(selectors.form);
        objs.divTerms = $(selectors.divTerms);
    }

    function setCreateEdit() {
        cacheOBjsCreateEdit();
        $.validator.unobtrusive.parse(objs.form);

        bindPopOvers();
        bindBtnAddTerm();
    }

    function setDetails() {
        cacheObjsDetails();

        bindDetails();
    }

    function init() {
        setSelectors();
        cacheObjsCommon();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
        isNew = window.location.href.indexOf('add') > -1;
        isDetails = window.location.href.indexOf('details') > -1;
        isEdit = window.location.href.indexOf('edit') > -1;
        isIndex = !isNew && !isDetails && !isEdit;

        if (isIndex) {
            cacheObjsIndex();
            var url = objs.urls.data('urlList');
            var urlMine = objs.urls.data('urlMine');
            loadTranslations(false, url);
            loadMyProjects(false, urlMine);
        }
        else if (isDetails) {
            setDetails();
        }
        else if (isEdit) {
            setCreateEdit();
        }
    }

    function bindAll() {
        bindBtnNew();
        bindBtnSaveForm();
        bindEdit();
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
        bindPopOvers();
        bindLanguageChange();
        CONTENTACTIONS.BindShareContent();
    }

    function bindPopOvers() {
        $("[data-toggle='popover']").popover();
    }

    function bindLanguageChange() {
        objs.containerDetails.on('change', selectors.ddlLanguage, function () {
            var ddl = $(this);
            var url = ddl.data('url');
            var language = ddl.val();

            var data = {
                language: language
            };

            objs.containerDetails.find('input.translation-input').val('');

            $.post(url, data).done(function (response) {
                if (response.success === true) {


                    for (var i = 0; i < response.value.length; i++) {
                        var translation = response.value[i];

                        var termInput = objs.containerDetails.find('input.translation-input[data-termid=' + translation.termId + ']');

                        termInput.val(translation.value);
                    }
                }
                else {
                    ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                }
            });
        });
    }

    function bindBtnSaveForm() {
        objs.containerDetails.on('click', selectors.btnSave, function () {
            var btn = $(this);
            $.validator.unobtrusive.parse(objs.form);
            var valid = objs.form.valid();

            if (valid && canInteract) {
                var allRequiredFilled = true;
                var allIlRequired = objs.form.find(':input[data-val-required]');
                allIlRequired.each(function (index, element) {
                    if (allRequiredFilled === true && $(this).val().length === 0) {
                        allRequiredFilled = false;
                    }
                });

                if (!allRequiredFilled) {
                    ALERTSYSTEM.ShowWarningMessage("All terms must have key and value!");
                }
                else {

                    MAINMODULE.Common.RemoveErrorFromButton(btn);
                    MAINMODULE.Common.DisableButton(btn);

                    submitForm(btn);
                }

            }
            else {
                MAINMODULE.Common.SetButtonWithError(btn);
            }
        });
    }


    function bindEdit() {
        objs.container.on('click', selectors.btnEdit, function (e) {
            e.preventDefault();
            var url = $(this).data('url');

            if (canInteract) {
                loadEditForm(url);
            }
        });
    }

    function bindBtnAddTerm() {
        objs.container.on('click', selectors.btnAddTerm, function (e) {
            e.preventDefault();

            addNewTerm();

            return false;
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

    function loadMyProjects(fromControlSidebar, url) {
        objs.myProjects.html(MAINMODULE.Default.SpinnerTop);

        $.get(url, function (data) {
            if (fromControlSidebar) {
                objs.myProjects.html(data);
                objs.containerList.show();
                cacheObjects();
            }
            else {
                objs.myProjects.html(data);
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

    function loadEditForm(url) {
        objs.containerDetails.html(MAINMODULE.Default.Spinner);
        if (objs.containerList) {
            objs.containerList.hide();
        }

        $.get(url, function (data) {
            objs.containerDetails.html(data);
            objs.containerDetails.show();

            setCreateEdit();
        });
    }

    function addNewTerm() {
        var newTermObj = $(selectors.template).first().clone();

        newTermObj.find(':input').val('');

        newTermObj.removeClass('template');

        newTermObj.prependTo(selectors.divTerms);

        newTermObj.find('input.form-control').first().focus();


        MAINMODULE.Common.RenameInputs(objs.divTerms, selectors.term, propPrefix);

        bindPopOvers();
    }

    function submitForm(btn, callback) {
        var url = objs.form.attr('action');

        var data = objs.form.serialize();

        $.post(url, data).done(function (response) {
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
    TRANSLATION.Init();
});