var POLLS = (function () {
    "use strict";
    var selectors = {};

    function init() {
        console.log('polls init');
        setSelectors();

        bindAll();
    }

    function setSelectors() {
        selectors.divPostPoll = $('div#divPostPoll');
        selectors.options = $('input.polloptioninput');
    }

    function bindAll() {
        bindBtnAddOptionBtn();
        bindBtnRemoveOptionBtn();
    }

    function bindBtnAddOptionBtn() {
        $('.content').on('click', '#btnAddOption', function (e) {
            var option = selectors.divPostPoll.children('.polloption:first');
            var newOption = option.clone();
            var input = newOption.children('.polloptioninput');
            input.val('');

            var btnRemoveOption = newOption.find('.btn-option-remove');
            $(btnRemoveOption).removeClass('invisible');

            newOption.insertBefore('#btnAddOption');
            input.focus();
            POLLS.Events.PostAddOption();
        });
    }

    function bindBtnRemoveOptionBtn() {
        $('.content').on('click', '.btn-option-remove', function (e) {
            var option = $(this).closest('.polloption');

            option.remove();
        });
    }

    function clearOptions() {
        selectors.options.val('');
    }

    return {
        Init: init,
        Methods: {
            ClearOptions: clearOptions
        },
        Events: {
            PostAddOption: function () { }
        }
    };
}());


$(function () {
    POLLS.Init();
});