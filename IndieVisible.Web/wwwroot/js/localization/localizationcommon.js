var LOCALIZATIONCOMMON = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';

        selectors.btnDelete = '.btnDeleteTranslationProject';
    }

    function cacheObjsTranslate() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
    }

    function init() {
        setSelectors();
        cacheObjsTranslate();

        canInteract = objs.container.find(selectors.canInteract).val();

        bindTranslate();

        setStickyElements();
    }

    function bindTranslate() {
        bindDeleteProject();
        CONTENTACTIONS.BindShareContent();
        MAINMODULE.Common.BindPopOvers();
    }

    function bindDeleteProject() {
        objs.container.on('click', selectors.btnDelete, function (e) {
            e.preventDefault();

            var btn = $(this);

            if (canInteract) {
                deleteProject(btn);
            }

            return false;
        });
    }

    function setSelectedTranslator(btn) {
        btn.closest(selectors.entry).find(selectors.entryAuthorButton + ' img').addClass('grayscale');

        btn.find('img').removeClass('grayscale');

        btn.closest(selectors.entry).find(selectors.entryAuthorName).html(btn.attr('title'));
    }

    function deleteProject(btn, callback) {
        var url = btn.data('url');

        var msgs = MAINMODULE.Common.GetDeleteMessages(btn);

        ALERTSYSTEM.ShowConfirmMessage(msgs.confirmationTitle, msgs.msg, msgs.confirmationButtonText, msgs.cancelButtonText, function () {
            $.ajax({
                url: url,
                type: 'DELETE'
            }).done(function (response) {
                if (response.success) {
                    if (callback) {
                        callback(response);
                    }

                    MAINMODULE.Common.HandleSuccessDefault(response);
                }
                else {
                    ALERTSYSTEM.ShowWarningMessage(response.message);
                }
            });
        });
    }

    function addNewAuthor(container, translation) {
        var newAuthorObj = $(selectors.entryAuthorTemplate).first().clone();
        var btn = newAuthorObj.find('a');

        var urlAvatar = objs.urls.data('urlAvatar').replace(/xpto/g, translation.userId);
        btn.find('img').attr('data-src', urlAvatar);

        btn.attr('data-userid', translation.userId);
        btn.attr('title', translation.authorName);
        btn.attr('data-value', translation.value);

        newAuthorObj.removeClass('template');
            
        newAuthorObj.appendTo(container);

        setSelectedTranslator(btn);
    }

    function setStickyElements() {
        MAINMODULE.Layout.SetStickyElement('#divTranslationSelector', 50, '#divTranslationSelector');
    }

    return {
        Init: init
    };
}());

$(function () {
    LOCALIZATIONCOMMON.Init();
});
