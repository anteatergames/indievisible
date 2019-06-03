var USERPREFERENCES = (function () {
    "use strict";

    function init() {
        console.log('init');

        bindAll();
    }

    function bindAll() {
        bindSelect2();
        bindSave();
    }

    function bindSelect2() {
        $('.select2').select2();
    }

    function bindSave() {
        $('#frmPreferencesSave').on('click', '#btnUserPreferencesSave', function (e) {
            e.preventDefault();

            var form = $('#frmPreferencesSave');
            var url = form.attr('action');

            var data = form.serialize();

            $.ajax({
                type: "POST",
                url: url,
                data: data,
                enctype: 'multipart/form-data',
                success: function (response) {
                    console.log(response);
                    window.location = '/';
                }
            });

            return false;
        });
    }


    return {
        Init: init
    };
}());


$(function () {
    USERPREFERENCES.Init();
});