var FEATURECONTENT = (function () {
    "use strict";

    var selectors = {};

    function init() {
        console.log('init');

        cacheSelectors();

        bindAll();

        loadList();
    }

    function cacheSelectors() {
        selectors.divListFeatured = $("#divListFeatured");
    }

    function bindAll() {
        bindTooltip();
        bindBtnFeatureOk();
        bindBtnFeatureNok();
    }

    function bindTooltip() {
        $('[data-toggle="tooltip"]').tooltip();
    }

    function bindBtnFeatureOk() {
        $('body').on('click', '.btn-feature-ok', function (e) {
            var btn = $(this);
            var id = btn.closest('tr').data('id');

            $.post('/staff/featuredcontent/add', { id: id })
                .done(function (response) {
                    if (response.success === true) {
                        ALERTSYSTEM.ShowSuccessMessage("Awesome!");
                        loadList();
                    }
                    else {
                        ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                        console.log(response);
                    }
                });
        });
    }

    function bindBtnFeatureNok() {
        $('body').on('click', '.btn-feature-nok', function (e) {
            var btn = $(this);
            var id = btn.closest('tr').data('featureid');

            $.post('/staff/featuredcontent/remove', { id: id })
                .done(function (response) {
                    if (response.success === true) {
                        ALERTSYSTEM.ShowSuccessMessage("Awesome!");
                        loadList();
                    }
                    else {
                        ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
                        console.log(response);
                    }
                });
        });
    }

    function loadList() {
        console.log(selectors.divListFeatured);
        selectors.divListFeatured.html(MAINMODULE.Default.Spinner);

        $.get("/staff/featuredcontent/list", function (data) {
            selectors.divListFeatured.html(data);
        });
    }


    return {
        Init: init
    };
}());


$(function () {
    FEATURECONTENT.Init();
});