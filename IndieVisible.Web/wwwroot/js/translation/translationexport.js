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
        selectors.fillGaps = '#fillGaps';
        selectors.exportProject = '#exportProject';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.containerDetails = $(selectors.containerDetails);
        objs.fillGaps = $(selectors.fillGaps);
        objs.exportProject = $(selectors.exportProject);
    }

    function init() {
        console.log('TRANSLATIONEXPORT.init');
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
    }

    function bindAll() {
        bindPopOvers();
        bindBtnExportProject();
        bindBtnExportSingleLanguage();
    }

    function bindPopOvers() {
        $("[data-toggle='popover']").popover({ html: true });
    }

    function bindBtnExportProject() {
        objs.container.on('click', selectors.exportProject, function () {
            var url = $(this).data('url');

            url += '&fillGaps=' + objs.fillGaps.is(':checked');

            console.log(url);

            window.location.href = url;
        });
    }

    function bindBtnExportSingleLanguage() {
        objs.container.on('click', selectors.btnExportLanguage, function () {
            var url = $(this).data('url');

            url += '&fillGaps=' + objs.fillGaps.is(':checked');

            console.log(url);

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