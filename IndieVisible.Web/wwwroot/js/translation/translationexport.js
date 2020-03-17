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
        selectors.btnExportNameProfile = '#btnExportNameProfile';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.containerDetails = $(selectors.containerDetails);
        objs.fillGaps = $(selectors.fillGaps);
        objs.exportProject = $(selectors.exportProject);
        objs.btnExportNameProfile = $(selectors.btnExportNameProfile);
    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = objs.container.find(selectors.canInteract).val();
    }

    function bindAll() {
        bindPopOvers();
        bindBtnExportProject();
        bindBtnExportSingleLanguage();
        bindBtnExportContributorsNameProfile();
    }

    function bindPopOvers() {
        $("[data-toggle='popover']").popover({ html: true });
    }

    function bindBtnExportProject() {
        objs.container.on('click', selectors.exportProject, function () {
            var url = $(this).data('url');

            url += '&fillGaps=' + objs.fillGaps.is(':checked');

            window.location.href = url;
        });
    }

    function bindBtnExportSingleLanguage() {
        objs.container.on('click', selectors.btnExportLanguage, function () {
            var url = $(this).data('url');

            url += '&fillGaps=' + objs.fillGaps.is(':checked');

            window.location.href = url;
        });
    }

    function bindBtnExportContributorsNameProfile() {
        objs.container.on('click', selectors.btnExportNameProfile, function () {
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