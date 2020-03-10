﻿var TRANSLATION = (function () {
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
        selectors.entry = '.translation-entry';
        selectors.entryInput = 'input.entry-input';
        selectors.entryActions = '.translation-entry-actions';
        selectors.entrySave = selectors.entryActions + ' .entry-save';
        selectors.entryCancel = selectors.entryActions + ' .entry-cancel';
        selectors.entryAuthors = '.entry-authors';
        selectors.entryAuthorTemplate = '.entry-author.template';
        selectors.entryAuthorButton = '.entry-author-btn';
    }

    function cacheObjsCommon() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.containerDetails = $(selectors.containerDetails);
    }

    function cacheObjsIndex() {
        objs.containerDetails = $(selectors.containerDetails);
        objs.containerList = $(selectors.containerList);
        objs.list = $(selectors.list);
        objs.myProjects = $(selectors.myProjects);
    }

    function cacheObjsDetails() {
        objs.ddlLanguage = $(selectors.ddlLanguage);
        objs.entryAuthors = $(selectors.entryAuthors);
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
        bindEntrySave();
        bindAuthorChange();
        CONTENTACTIONS.BindShareContent();
    }

    function bindPopOvers() {
        $("[data-toggle='popover']").popover();
    }

    function bindLanguageChange() {
        objs.containerDetails.on('change', selectors.ddlLanguage, function () {
            var ddl = $(this);
            var url = ddl.data('urlGet');
            var language = ddl.val();

            var data = {
                language: language
            };

            objs.containerDetails.find(selectors.entryInput).val('');
            removeAllAuthors(selectors.entryAuthors);

            $.post(url, data).done(function (response) {
                if (response.success === true) {
                    for (var i = 0; i < response.value.length; i++) {
                        loadSingleTranslation(response.value[i]);
                    }
                }
                else {
                    ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                }
            });
        });
    }

    function bindEntrySave() {
        objs.containerDetails.on('click', selectors.entrySave, function () {
            var btn = $(this);
            var input = btn.closest(selectors.entry).find(selectors.entryInput);
            var termId = input.data('termid');
            var url = objs.ddlLanguage.data('urlSet');
            var language = objs.ddlLanguage.val();

            if (language && input.val().length > 0) {
                var data = {
                    termId: termId,
                    language: language,
                    value: input.val()
                };

                $.post(url, data).done(function (response) {
                    if (response.success === true) {
                        deleteEntryAuthorButton(response.value.termId, response.value.userId);

                        loadSingleTranslation(response.value);

                        if (response.message) {
                            ALERTSYSTEM.Toastr.ShowWarning(response.message);
                        }
                    }
                    else {
                        ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                    }
                });

            }
        });
    }

    function bindAuthorChange() {
        objs.containerDetails.on('click', selectors.entryAuthorButton, function () {
            var btn = $(this);
            var input = btn.closest(selectors.entry).find(selectors.entryInput);
            var v = btn.data('value');
            input.val(v);
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
                allIlRequired.each(function () {
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

    function addNewAuthor(container, translation) {
        var newAuthorObj = $(selectors.entryAuthorTemplate).first().clone();
        var btn = newAuthorObj.find('button');

        btn.attr('data-userid', translation.userId);
        btn.attr('title', translation.authorName);
        btn.attr('data-value', translation.value);

        newAuthorObj.removeClass('template');

        newAuthorObj.appendTo(container);
    }

    function removeAllAuthors(container) {
        $(container).html('');
    }

    function deleteEntryAuthorButton(termId, userId) {
        var termInput = objs.containerDetails.find(selectors.entryInput + '[data-termid=' + termId + ']');

        var entry = termInput.closest(selectors.entry);

        var authorBtn = entry.find(selectors.entryAuthorButton + '[data-userId=' + userId + ']');

        authorBtn.parent().remove();
    }

    function loadSingleTranslation(translation) {
        var termInput = objs.containerDetails.find(selectors.entryInput + '[data-termid=' + translation.termId + ']');

        termInput.val(translation.value);

        addNewAuthor(termInput.closest(selectors.entry).find(selectors.entryAuthors), translation);
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

                ALERTSYSTEM.ShowSuccessMessage("Awesome!", function () {
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