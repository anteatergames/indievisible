var TRANSLATIONEXPORT = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.containerDetails = '#containerdetails';
        selectors.btnExportLanguage = '.export-language';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.containerDetails = $(selectors.containerDetails);
    }

    function init() {
        console.log('TRANSLATIONEXPORT.init');
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
    }

    function bindAll() {
        bindBtnExportSingleLanguage();
    }

    function bindBtnExportSingleLanguage() {
        objs.container.on('click', selectors.btnExportLanguage, function () {
            var url = $(this).data('url');

            window.location.href = url;
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    TRANSLATIONEXPORT.Init();
});