var SEARCH = (function () {
    "use strict";

    var selectors = {};

    function init() {
        cacheSelectors();
        bindAll();

        searchPosts();
    }

    function cacheSelectors() {
        selectors.term = $('#q');
        selectors.divSearchPosts = $('#divSearchPosts');
    }

    function bindAll() {
    }

    function searchPosts() {
        MAINMODULE.Ajax.LoadHtml("/search/posts?q=" + encodeURIComponent(selectors.term.val()), selectors.divSearchPosts).then(() => {
            MAINMODULE.Common.BindPopOvers();
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    SEARCH.Init();
});