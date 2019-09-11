var FEEDTYPE = {
    HOME: 1,
    USER: 2,
    GAME: 3
}

var ACTIVITYFEED = (function () {
    "use strict";
    var selectors = {};
    var selectorText = {};

    var feedType;
    var feedId;

    var oldestGuid;
    var oldestDate;

    function init(divActivityFeed, type, id) {

        feedType = type;
        feedId = id;

        selectors.divActivityFeed = divActivityFeed;
        selectorText.btnMorePosts = '#btnMorePosts';

        bindAll();
    }


    function bindAll() {
        bindMorePosts();
    }

    function bindMorePosts() {
        $('body').on('click', selectorText.btnMorePosts, function () {
            var btn = $(this);
            oldestGuid = btn.data('oldestid');
            oldestDate = btn.data('oldestdate');

            ACTIVITYFEED.Methods.LoadActivityFeed();
        });
    }


    function loadActivityFeed(callback) {
        selectors.divActivityFeed.append(MAINMODULE.Default.Spinner);

        var url = "/content/feed?load=1";
        
        if (feedId && feedType === FEEDTYPE.USER) {
            url += '&userId=' + feedId;
        }
        if (feedId && feedType === FEEDTYPE.GAME) {
            url += '&gameId=' + feedId;
        }

        if (oldestGuid) {
            url += '&oldestId=' + oldestGuid;
        }
        if (oldestDate) {
            url += '&oldestDate=' + oldestDate;
        }

        $.get(url, function (response) {

            if (oldestDate !== undefined && oldestGuid !== undefined) {
                selectors.divActivityFeed.find('.spinner').remove();
                $(selectorText.btnMorePosts).remove();
                selectors.divActivityFeed.append(response);
            }
            else {
                selectors.divActivityFeed.html(response);
            }


            if (callback) {
                callback();
            }
        });
    }

    return {
        Init: init,
        Methods: {
            LoadActivityFeed: loadActivityFeed
        },
        Events: {
        }
    };
}());