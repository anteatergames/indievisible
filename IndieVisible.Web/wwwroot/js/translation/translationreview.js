var TRANSLATIONREVIEW = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';

        selectors.ddlLanguage = '#Language';

        selectors.entry = '.translation-entry';
        selectors.entryInput = ':input.entry-input';
        selectors.entryActions = '.translation-entry-actions';
        selectors.entryAccept = selectors.entryActions + ' .entry-accept';
        selectors.entryReject = selectors.entryActions + ' .entry-reject';
        selectors.entryAuthors = '.entry-authors';
        selectors.entryAuthorTemplate = '.entry-author.template';
        selectors.entryAuthorButton = '.entry-author-btn';
        selectors.entryAuthorName = '.translator-name';

        selectors.id = '#Id';
    }

    function cacheObjsTranslate() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.container = $(selectors.container);

        objs.ddlLanguage = $(selectors.ddlLanguage);
        objs.entryAuthors = $(selectors.entryAuthors);
    }

    function init() {
        setSelectors();
        cacheObjsTranslate();

        bindTranslate();

        setStickyElements();

        loadSelectedLanguage(objs.ddlLanguage);
    }

    function bindTranslate() {
        bindLanguageChange();
        bindAuthorChange();
        bindEntryAccept();
        bindEntryReject();
    }

    function bindLanguageChange() {
        objs.container.on('change', selectors.ddlLanguage, function () {
            var ddl = $(this);

            objs.container.find(selectors.entryInput).val('');
            $(selectors.entryInput).data('originalval', '');

            loadSelectedLanguage(ddl);
        });
    }

    function bindEntryAccept() {
        objs.container.on('click', selectors.entryAccept, function (e) {
            e.preventDefault();

            ALERTSYSTEM.Toastr.ShowWarning("This is not implemented yet");

            var btn = $(this);

            var input = btn.closest(selectors.entry).find(selectors.entryInput);
            var entryId = input.data('entryid');
            var url = objs.urls.data('urlEntryAccept');
            var language = objs.ddlLanguage.val();

            if (language && input.val().length > 0) {
                var data = {
                    entryId: entryId
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

            return false;
        });
    }

    function bindEntryReject() {
        objs.container.on('click', selectors.entryReject, function (e) {
            e.preventDefault();

            ALERTSYSTEM.Toastr.ShowWarning("This is not implemented yet");

            return false;
        });
    }

    function bindAuthorChange() {
        objs.container.on('click', selectors.entryAuthorButton, function (e) {
            e.preventDefault();

            var btn = $(this);
            var input = btn.closest(selectors.entry).find(selectors.entryInput);
            var v = btn.data('value');
            input.val(v);
            input.data('entryid', btn.data('entryid'));

            setSelectedTranslator(btn);

            return false;
        });
    }

    function setSelectedTranslator(btn) {
        btn.closest(selectors.entry).find(selectors.entryAuthorButton + ' img').addClass('grayscale');

        btn.find('img').removeClass('grayscale');

        btn.closest(selectors.entry).find(selectors.entryAuthorName).html(btn.attr('title'));
    }

    function addNewAuthor(container, translation) {
        var newAuthorObj = $(selectors.entryAuthorTemplate).first().clone();
        var btn = newAuthorObj.find('a');

        var urlAvatar = objs.urls.data('urlAvatar').replace(/xpto/g, translation.userId);
        btn.find('img').attr('data-src', urlAvatar);

        btn.attr('data-userid', translation.userId);
        btn.attr('title', translation.authorName);
        btn.attr('data-value', translation.value);
        btn.data('entryid', translation.id);

        newAuthorObj.removeClass('template');

        newAuthorObj.appendTo(container);

        setSelectedTranslator(btn);
    }

    function deleteEntryAuthorButton(termId, userId) {
        var entryInput = objs.container.find(selectors.entryInput + '[data-termid=' + termId + ']');

        var entry = entryInput.closest(selectors.entry);

        var authorBtn = entry.find(selectors.entryAuthorButton + '[data-userId=' + userId + ']');

        authorBtn.parent().remove();
    }

    function loadSelectedLanguage(ddl) {
        var url = objs.urls.data('urlEntriesGet');
        var language = ddl.val();

        var data = {
            language: language
        };

        $.post(url, data).done(function (response) {
            if (response.success === true) {
                resetTranslationStatus();

                for (var i = 0; i < response.value.length; i++) {
                    loadSingleTranslation(response.value[i]);
                }
            }
            else {
                ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
            }
        });
    }

    function resetTranslationStatus() {
        var names = $(selectors.entryAuthorName);
        names.html(names.data('nobody'));

        $(selectors.entryAuthors).html('');
    }

    function loadSingleTranslation(translation) {
        var entryInput = objs.container.find(selectors.entryInput + '[data-termid=' + translation.termId + ']');

        entryInput.val(translation.value);
        entryInput.data('originalval', translation.value);

        entryInput.data('entryid', translation.id);

        addNewAuthor(entryInput.closest(selectors.entry).find(selectors.entryAuthors), translation);
    }

    function setStickyElements() {
        MAINMODULE.Layout.SetStickyElement('#divTranslationSelector', 50, '#divTranslationSelector');
    }

    return {
        Init: init
    };
}());

$(function () {
    TRANSLATIONREVIEW.Init();
});
