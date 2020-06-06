var GAMEDETAILS = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    function init() {
        setSelectors();
        setObjs();

        bindAll();

        ACTIVITYFEED.Init(objs.divActivityFeed, FEEDTYPE.GAME, objs.Id.val());
        ACTIVITYFEED.Methods.LoadActivityFeed();

        MAINMODULE.Common.BindPopOvers();
    }

    function setSelectors() {
        selectors.container = '.content-wrapper';
        selectors.page = '.game-page';
        selectors.tabActivity = '#tabactivity';
        selectors.divActivityFeed = '#tabactivity #divActivityFeed';
        selectors.Id = '#Id';
        selectors.btnLike = '#btn-game-like';
        selectors.likeCounter = '.like-count';
        selectors.btnFollow = '#btn-game-follow';
        selectors.followCounter = '.follow-count';
        selectors.btnShare = '#btn-game-share';
    }

    function setObjs() {
        objs.container = $(selectors.container);
        objs.tabActivity = $(selectors.tabActivity);
        objs.divActivityFeed = $(selectors.divActivityFeed);
        objs.Id = $(selectors.Id);
    }

    function bindAll() {
        bindLikeBtn();
        bindFollowBtn();
        bindShareBtn();
    }

    function bindLikeBtn() {
        objs.container.on('click', selectors.btnLike, function (e) {
            var btn = $(this);
            var likeCount = btn.closest(selectors.page).find(selectors.likeCounter);
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
        objs.container.on('click', selectors.btnFollow, function (e) {
            var btn = $(this);
            var followCount = btn.closest(selectors.page).find(selectors.followCounter);
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
        objs.container.on('click', selectors.btnShare, function (e) {
            e.preventDefault();
            var url = $(this).prop('href');

            FB.ui({
                method: 'share',
                href: url
            }, function (response) { });
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