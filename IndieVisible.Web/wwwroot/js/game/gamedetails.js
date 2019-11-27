var GAMEDETAILS = (function () {
    "use strict";

    var selectors = {};

    function init() {
        setSelectors();

        bindAll();

        ACTIVITYFEED.Init(selectors.divActivityFeed, FEEDTYPE.GAME, selectors.Id.val());
        ACTIVITYFEED.Methods.LoadActivityFeed();

        setPopOvers();
    }

    function setSelectors() {
        selectors.tabActivity = $("#tabactivity");
        selectors.divActivityFeed = $("#tabactivity #divActivityFeed");
        selectors.Id = $('#Id');
    }

    function bindAll() {
        bindLikeBtn();
        bindFollowBtn();
        bindShareBtn();
    }

    function bindLikeBtn() {
        $('.content').on('click', '#btn-game-like', function (e) {
            var btn = $(this);
            var likeCount = btn.closest('.game-page').find('.like-count');
            var likedId = btn.data('id');

            if (btn.hasClass("like-liked")) {
                unlike(likedId).done(function (response) { unlikeCallback(response, likeCount, btn); });
            }
            else {
                like(likedId).done(function (response) { likeCallback(response, likeCount, btn); });
            }
        });
    }

    function bindFollowBtn() {
        $('.content').on('click', '#btn-game-follow', function (e) {
            var btn = $(this);
            var followCount = btn.closest('.game-page').find('.follow-count');
            var followdId = btn.data('id');

            if (btn.hasClass("follow-following")) {
                unfollow(followdId).done(function (response) { unfollowCallback(response, followCount, btn); });
            }
            else {
                follow(followdId).done(function (response) { followCallback(response, followCount, btn); });
            }
        });
    }

    function bindShareBtn() {
        $('.content').on('click', '#btn-game-share', function (e) {
            e.preventDefault();
            var url = $(this).prop('href');

            FB.ui({
                method: 'share',
                href: url
            }, function (response) { });
        });
    }

    function setPopOvers() {
        $("[data-toggle='popover']").each(function (index, element) {
            var data = $(element).data();
            if (data.target) {
                var contentElementId = data.target;
                var contentHtml = $(contentElementId).html();
                data.content = contentHtml;
                data.html = true;
            }
            $(element).popover(data);
        });
    }

    function like(likedId) {
        return $.post("/game/like", { likedId: likedId });
    }
    function likeCallback(response, likeCount, btn) {
        if (response.success === true) {
            $(likeCount).text(response.value);

            btn.addClass('bg-red');
            btn.addClass('like-liked');
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }

    function unlike(likedId) {
        return $.post("/game/unlike", { likedId: likedId });
    }
    function unlikeCallback(response, likeCount, btn) {
        if (response.success === true) {
            $(likeCount).text(response.value);

            btn.removeClass('bg-red');
            btn.removeClass('like-liked');
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }

    function follow(gameId) {
        return $.post("/game/follow", { gameId: gameId });
    }
    function followCallback(response, followCount, btn) {
        if (response.success === true) {
            $(followCount).text(response.value);

            btn.addClass('bg-blue');
            btn.addClass('follow-following');
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }

    function unfollow(gameId) {
        return $.post("/game/unfollow", { gameId: gameId });
    }
    function unfollowCallback(response, likeCount, btn) {
        if (response.success === true) {
            $(likeCount).text(response.value);

            btn.removeClass('bg-blue');
            btn.removeClass('follow-following');
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }

    return {
        Init: init
    };
}());

$(function () {
    GAMEDETAILS.Init();
});