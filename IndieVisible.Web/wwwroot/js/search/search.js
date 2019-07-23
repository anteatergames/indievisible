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
        selectors.divSearchPosts.html(MAINMODULE.Default.Spinner2);

        $.get("/search/posts/" + selectors.term.val(), function (data) { selectors.divSearchPosts.html(data); });
    }


    return {
        Init: init
    };
}());


$(function () {
    SEARCH.Init();
});