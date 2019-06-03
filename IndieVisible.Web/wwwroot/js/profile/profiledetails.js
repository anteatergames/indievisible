var PROFILEDETAILS = (function () {
    "use strict";

    var selectors = {};

    function init() {
        cacheSelectors();

        bindAll();

        var userId = selectors.Id.val();

        loadActivityFeed(userId);
        loadGameList(userId);
        loadBadges(userId);
    }

    function cacheSelectors() {
        selectors.content = $('.content');
        selectors.tabActivity = $("#tabactivity");
        selectors.tabGames = $("#tabgames");
        selectors.Id = $('#Id');
        selectors.divBadges = $('#divBadges');
    }

    function bindAll() {
        bindFollowBtn();
        bindConnectBtn();
        bindAllowConnectionBtn();
        bindDenyConnectionBtn();
    }

    function bindFollowBtn() {
        selectors.content.on('click', '#btn-profile-follow', function (e) {
            var btn = $(this);
            var followCount = btn.closest('.user-profile').find('.follow-count');
            var targetId = btn.data('id');

            if (btn.hasClass("follow-following")) {
                unfollow(targetId).done(function (response) { unfollowCallback(response, followCount, btn); });
            }
            else {
                follow(targetId).done(function (response) { followCallback(response, followCount, btn); });
            }
        });
    }

    function bindConnectBtn() {
        selectors.content.on('click', '#btn-profile-connect', function (e) {
            var btn = $(this);
            var connectionCount = btn.closest('.user-profile').find('.connection-count');
            var targetId = btn.data('id');

            if (!btn.hasClass('disabled')) {
                if (btn.hasClass("connection-connected")) {
                    disconnect(targetId).done(function (response) { disconnectCallback(response, connectionCount, btn); });
                }
                else {
                    connect(targetId).done(function (response) { connectCallback(response, connectionCount, btn); });
                }
            }
        });
    }


    function bindAllowConnectionBtn() {
        selectors.content.on('click', '#btn-profile-connect-allow', function (e) {
            var btn = $(this);
            var btnConnect = $('#btn-profile-connect');
            var connectionCount = btn.closest('.user-profile').find('.connection-count');
            var targetId = btn.data('id');

            allowConnection(targetId).done(function (response) { allowConnectionCallback(response, connectionCount, btnConnect); });
        });
    }


    function bindDenyConnectionBtn() {
        selectors.content.on('click', '#btn-profile-connect-deny', function (e) {
            var btn = $(this);
            var btnConnect = $('#btn-profile-connect');
            var connectionCount = btn.closest('.user-profile').find('.connection-count');
            var targetId = btn.data('id');

            denyConnection(targetId).done(function (response) { denyConnectionCallback(response, connectionCount, btnConnect); });
        });
    }


    function loadActivityFeed(userId) {
        selectors.tabActivity.html(MAINMODULE.Default.Spinner);

        $.get("/content/feed?userId=" + userId, function (data) {
            selectors.tabActivity.html(data);
        });
    }


    function loadGameList(userId) {
        selectors.tabGames.html(MAINMODULE.Default.Spinner);

        $.get("/game/latest?userId=" + userId, function (data) {
            selectors.tabGames.html(data);
        });
    }

    function loadBadges(userId) {
        selectors.divBadges.html(MAINMODULE.Default.Spinner);

        $.get("/gamification/userbadge/list/" + userId, function (data) {
            selectors.divBadges.html(data);
        });
    }



    function follow(userId) {
        return $.post("/interact/user/follow", { userId: userId });
    }
    function followCallback(response, counterSelector, btn) {
        if (response.success === true) {
            $(counterSelector).text(response.value);

            btn.addClass('bg-blue');
            btn.addClass('follow-following');
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }

    function unfollow(userId) {
        return $.post("/interact/user/unfollow", { userId: userId });
    }
    function unfollowCallback(response, counterSelector, btn) {
        if (response.success === true) {
            $(counterSelector).text(response.value);

            btn.removeClass('bg-blue');
            btn.removeClass('follow-following');
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }


    function connect(userId) {
        return $.post("/interact/user/connect", { userId: userId });
    }
    function connectCallback(response, counterSelector, btn) {
        if (response.success === true) {
            var newText = btn.data('textPending');

            btn.text(newText);
            btn.addClass('disabled');

        } else {

            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }

    function disconnect(userId) {
        return $.post("/interact/user/disconnect", { userId: userId });
    }
    function disconnectCallback(response, counterSelector, btn) {
        if (response.success === true) {
            $(counterSelector).text(response.value);

            btn.removeClass('bg-green');
            btn.removeClass('connection-connected');
            btn.text(btn.data('textConnect'));
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }



    function allowConnection(userId) {
        return $.post("/interact/user/allowconnection", { userId: userId });
    }
    function allowConnectionCallback(response, counterSelector, btnConnect) {
        if (response.success === true) {
            $(counterSelector).text(response.value);

            $('.connectionalertbox').hide();

            btnConnect.addClass('bg-green');
            btnConnect.addClass('connection-connected');
            btnConnect.removeClass('disabled');
            btnConnect.text(btnConnect.data('textConnected'));
        }
        else {
            ALERTSYSTEM.ShowWarningMessage(response.message);
        }
    }



    function denyConnection(userId) {
        return $.post("/interact/user/denyconnection", { userId: userId });
    }
    function denyConnectionCallback(response, counterSelector, btnConnect) {
        if (response.success === true) {
            $(counterSelector).text(response.value);

            $('.connectionalertbox').hide();

            btnConnect.removeClass('disabled');
            btnConnect.text(btnConnect.data('textConnect'));
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
    PROFILEDETAILS.Init();
});