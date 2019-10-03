var PROFILEDETAILS = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    function init() {
        setSelectors();
        cacheObjects();

        bindAll();

        loadBadges(objs.Id.val());

        loadTeams();


        ACTIVITYFEED.Init(objs.divActivityFeed, FEEDTYPE.USER, objs.Id.val());
    }
    function setSelectors() {
        selectors.content = '.content';
        selectors.divListUserTeams = '#divListUserTeams';
        selectors.tabActivity = '#tabactivity';
        selectors.divActivityFeed = '#tabactivity #divActivityFeed';
        selectors.tabGames = '#tabgames';
        selectors.tabConnections = '#tabconnections';
        selectors.Id = '#Id';
        selectors.UserId = '#UserId';
        selectors.divBadges = '#divBadges';
    }

    function cacheObjects() {
        objs.content = $(selectors.content);
        objs.divListUserTeams = $(selectors.divListUserTeams);
        objs.tabActivity = $(selectors.tabActivity);
        objs.divActivityFeed = $(selectors.divActivityFeed);
        objs.tabGames = $(selectors.tabGames);
        objs.tabConnections = $(selectors.tabConnections);
        objs.Id = $(selectors.Id);
        objs.UserId = $(selectors.UserId);
        objs.divBadges = $(selectors.divBadges);
    }

    function bindAll() {
        bindFollowBtn();
        bindConnectBtn();
        bindAllowConnectionBtn();
        bindDenyConnectionBtn();
        bindTabs();
    }

    function bindFollowBtn() {
        objs.content.on('click', '#btn-profile-follow', function (e) {
            var btn = $(this);
            var followCount = btn.closest('.user-profile').find('.follow-count');
            var targetId = btn.data('id');

            if (btn.hasClass("btn-follow-following")) {
                unfollow(targetId).done(function (response) { unfollowCallback(response, followCount, btn); });
            }
            else {
                follow(targetId).done(function (response) { followCallback(response, followCount, btn); });
            }
        });
    }

    function bindConnectBtn() {
        objs.content.on('click', '#btn-profile-connect', function (e) {
            var btn = $(this);
            var connectionCount = btn.closest('.user-profile').find('.connection-count');
            var targetId = btn.data('id');

            if (!btn.hasClass('disabled')) {
                if (btn.hasClass("btn-connect-connected")) {
                    disconnect(targetId).done(function (response) { disconnectCallback(response, connectionCount, btn); });
                }
                else {
                    connect(targetId).done(function (response) { connectCallback(response, connectionCount, btn); });
                }
            }
        });
    }


    function bindAllowConnectionBtn() {
        objs.content.on('click', '#btn-profile-connect-allow', function (e) {
            var btn = $(this);
            var btnConnect = $('#btn-profile-connect');
            var connectionCount = btn.closest('.user-profile').find('.connection-count');
            var targetId = btn.data('id');

            allowConnection(targetId).done(function (response) { allowConnectionCallback(response, connectionCount, btnConnect); });
        });
    }


    function bindDenyConnectionBtn() {
        objs.content.on('click', '#btn-profile-connect-deny', function (e) {
            var btn = $(this);
            var btnConnect = $('#btn-profile-connect');
            var connectionCount = btn.closest('.user-profile').find('.connection-count');
            var targetId = btn.data('id');

            denyConnection(targetId).done(function (response) { denyConnectionCallback(response, connectionCount, btnConnect); });
        });
    }

    function bindTabs() {
        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            e.preventDefault();

            var tabDestination = e.target.getAttribute('href');

            if (tabDestination === '#' + objs.tabActivity.prop('id')) {
                ACTIVITYFEED.Methods.LoadActivityFeed();
            }
            else if (tabDestination === '#' + objs.tabGames.prop('id')) {
                loadGameList(objs.Id.val());
            }
            else if (tabDestination === '#' + objs.tabConnections.prop('id')) {
                loadConnections(objs.UserId.val());
            }
            return false;
        });
    }


    function loadGameList(userId) {
        objs.tabGames.html(MAINMODULE.Default.Spinner);

        $.get("/game/latest?userId=" + userId, function (data) {
            objs.tabGames.html(data);
        });
    }

    function loadBadges(userId) {
        objs.divBadges.html(MAINMODULE.Default.Spinner);

        $.get("/gamification/userbadge/list/" + userId, function (data) {
            objs.divBadges.html(data);
        });
    }

    function loadConnections(userId) {
        objs.tabConnections.html(MAINMODULE.Default.Spinner);

        $.get("/user/connections/" + userId, function (data) {
            objs.tabConnections.html(data);
        });
    }



    function follow(userId) {
        return $.post("/interact/user/follow", { userId: userId });
    }
    function followCallback(response, counterSelector, btn) {
        if (response.success === true) {
            $(counterSelector).text(response.value);

            btn.addClass('btn-follow-following');
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

            btn.removeClass('btn-follow-following');
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

            btn.removeClass('btn-connect-connected');
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

            btnConnect.addClass('btn-connect-connected');
            btnConnect.removeClass('disabled');
            btnConnect.text(btnConnect.data('textConnected'));

            loadConnections(objs.UserId.val());
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


    function loadTeams() {
        objs.divListUserTeams.html(MAINMODULE.Default.Spinner2);
        console.log(objs.divListUserTeams);
        $.get('/team/list/user/' + objs.UserId.val(), function (data) { objs.divListUserTeams.html(data); })
            .done(function (response) {
                setPopOvers();
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

    return {
        Init: init
    };
}());


$(function () {
    PROFILEDETAILS.Init();
});