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
        bindPollVote();
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
            newOption.addClass('polloptionextra');
            input.focus();
            POLLS.Events.PostAddOption();
        });
    }

    function bindBtnRemoveOptionBtn() {
        $('.content').on('click', '.btn-option-remove', function (e) {
            var option = $(this).closest('.polloption');

            option.remove();
            POLLS.Events.PostAddOption();
        });
    }
    

    function bindPollVote() {
        $('.content').on('click', '.poll-option', function (e) {
            var pollOptionCtrl = $(this);

            vote(pollOptionCtrl.val()).done(function (response) { voteCallback(response, pollOptionCtrl); });
        });
    }

    function clearOptions() {
        selectors.options.val('');
        $('.polloptionextra').remove();
    }

    function vote(pollOptionId) {
        return $.post("/interact/poll/vote", { pollOptionId: pollOptionId });
    }
    function voteCallback(response, likeCount, btn) {
        if (response.success === true) {
            console.log(response);
        }
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