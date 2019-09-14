var FEEDTYPE = {
    HOME: 1,
    USER: 2,
    GAME: 3
};

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
        selectorText.btnDeletePost = '.btnDeletePost';


        bindAll();
    }


    function bindAll() {
        bindMorePosts();
        bindDeletePost();
    }

    function bindMorePosts() {
        $('body').on('click', selectorText.btnMorePosts, function () {
            var btn = $(this);
            oldestGuid = btn.data('oldestid');
            oldestDate = btn.data('oldestdate');

            ACTIVITYFEED.Methods.LoadActivityFeed();
        });
    }

    function bindDeletePost() {
        $('body').on('click', selectorText.btnDeletePost, function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var msg = btn.data('confirmationmessage');

            ALERTSYSTEM.ShowConfirmMessage(msg, function () {
                $.ajax({
                    url: '/content/' + id,
                    type: 'DELETE'
                }).done(function (response) {
                    if (response.success) {
                        var elementToDelete = btn.closest('.box-content');
                        elementToDelete.remove();

                        if (response.message) {
                            ALERTSYSTEM.ShowSuccessMessage(response.message);
                        }
                    }
                    else {
                        ALERTSYSTEM.ShowWarningMessage(response.message);
                    }
                });
            });

            return false;
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
                $(selectorText.btnMorePosts).parent().remove();
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