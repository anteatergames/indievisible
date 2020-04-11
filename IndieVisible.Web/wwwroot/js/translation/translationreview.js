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

        selectors.item = '.translation-item';
        selectors.entry = '.entry';
        selectors.entryInput = ':input.entry-input';
        selectors.entryActions = '.review-actions';
        selectors.entryAccept = '.entry-accept';
        selectors.entryReject = '.entry-reject';
        selectors.entryAuthor = '.entry-author';
        selectors.entryTemplate = '.entry.template';
        selectors.entryAuthorButton = '.entry-author-btn';
        selectors.entryAuthorName = '.translator-name';
        selectors.entryTranslationDate = '.translation-date';
        selectors.entryTranslationPlace = '.entry-translations-place';
        selectors.noTranslationTemplate = '.notranslation';

        selectors.id = '#Id';
    }

    function cacheObjsTranslate() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.container = $(selectors.container);

        objs.ddlLanguage = $(selectors.ddlLanguage);
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
            var btn = $(this);
            var otherBtn = btn.closest(selectors.entryActions).find(selectors.entryReject);

            var entryId = $(this).closest(selectors.entry).data('entryid');
            var url = objs.urls.data('urlEntryReview');

            entryReview(url, entryId, true, function () {
                acceptVisualAction(btn, otherBtn);
                alternateText(otherBtn);
            });

            return false;
        });
    }

    function bindEntryReject() {
        objs.container.on('click', selectors.entryReject, function (e) {
            e.preventDefault();
            var btn = $(this);
            var otherBtn = btn.closest(selectors.entryActions).find(selectors.entryAccept);

            var entryId = $(this).closest(selectors.entry).data('entryid');
            var url = objs.urls.data('urlEntryReview');

            entryReview(url, entryId, false, function () {
                rejectVisualAction(btn, otherBtn);
                alternateText(otherBtn);
            });

            return false;
        });
    }

    function entryReview(url, entryId, accept, callback) {
        var language = objs.ddlLanguage.val();

        if (language) {
            var data = {
                entryId: entryId,
                accept: accept
            };

            $.post(url, data).done(function (response) {
                if (response.success === true) {

                    if (callback) {
                        callback();
                    }

                    if (response.message) {
                        ALERTSYSTEM.Toastr.ShowWarning(response.message);
                    }
                }
                else {
                    ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                }
            });
        }
    }

    function loadSelectedLanguage(ddl) {
        var url = objs.urls.data('urlEntriesGet');
        var language = ddl.val();

        var data = {
            language: language
        };

        $.post(url, data).done(function (response) {
            if (response.success === true) {
                resetTranslationPlaces();

                for (var i = 0; i < response.value.length; i++) {
                    loadSingleTranslation(response.value[i]);
                }
            }
            else {
                ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
            }
        });
    }

    function resetTranslationPlaces() {
        var noTranslationTemplate = $(selectors.noTranslationTemplate).first().clone();

        var places = objs.container.find(selectors.item).find(selectors.entryTranslationPlace);

        places.html('');

        noTranslationTemplate.appendTo(places).removeClass('template');
    }

    function loadSingleTranslation(entry) {
        var div = objs.container.find(selectors.item + '[data-termid=' + entry.termId + ']');
        var place = div.find(selectors.entryTranslationPlace);

        place.find(selectors.noTranslationTemplate).remove();

        var newEntryObj = $(selectors.entryTemplate).first().clone();
        var entryAuthorButton = newEntryObj.find(selectors.entryAuthorButton);
        var urlAvatar = objs.urls.data('urlAvatar').replace(/xpto/g, entry.userId);

        newEntryObj.attr('data-entryid', entry.id);

        entryAuthorButton.find('img').attr('data-src', urlAvatar);
        entryAuthorButton.attr('title', entry.authorName);
        entryAuthorButton.closest(selectors.entryAuthor).find(selectors.entryAuthorName).html(entry.authorName);
        entryAuthorButton.closest(selectors.entryAuthor).find(selectors.entryTranslationDate).html(entry.createDateText);
        entryAuthorButton.attr('href', objs.urls.data('urlProfile') + entry.userId);

        var rejectBtn = newEntryObj.find(selectors.entryReject);
        var acceptBtn = newEntryObj.find(selectors.entryAccept);

        if (entry.accepted === false) {
            rejectVisualAction(rejectBtn, acceptBtn);
        }
        else if (entry.accepted === true) {
            acceptVisualAction(acceptBtn, rejectBtn);
        }
        else {
            acceptBtn.removeAttr('disabled');
            acceptBtn.addClass('text-success');

            rejectBtn.removeAttr('disabled');
            rejectBtn.addClass('text-danger');
        }


        var entryInput = newEntryObj.find(selectors.entryInput);

        entryInput.val(entry.value);

        newEntryObj.appendTo(place).removeClass('template');
    }

    function acceptVisualAction(acceptBtn, rejectBtn) {
        rejectBtn.removeAttr('disabled').removeClass('text-white btn-danger').addClass('text-danger');
        acceptBtn.attr('disabled', true).removeClass('text-success').addClass('text-white btn-success');

        alternateText(acceptBtn);
    }

    function rejectVisualAction(rejectBtn, acceptBtn) {
        acceptBtn.removeAttr('disabled').removeClass('text-white btn-success').addClass('text-success');
        rejectBtn.attr('disabled', true).removeClass('text-danger').addClass('text-white btn-danger');

        alternateText(rejectBtn);
    }

    function alternateText(btn) {
        var oldText = btn.attr('title');
        btn.attr('title', btn.data('textAlternative'));
        btn.data('textAlternative', oldText);
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
