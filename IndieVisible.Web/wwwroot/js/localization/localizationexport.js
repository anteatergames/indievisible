var LOCALIZATIONEXPORT = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
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
    }

    function bindAll() {
        MAINMODULE.Common.BindPopOvers();
        bindBtnExportProject();
        bindBtnExportSingleLanguage();
        bindBtnExportContributorsNameProfile();
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
    LOCALIZATIONEXPORT.Init();
});