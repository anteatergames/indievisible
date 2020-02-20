﻿var SEARCH = (function () {
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
        selectors.divSearchPosts.html(MAINMODULE.Default.SpinnerTop);

        $.get("/search/posts?q=" + encodeURIComponent(selectors.term.val()), function (data) { selectors.divSearchPosts.html(data); });
    }

    return {
        Init: init
    };
}());

$(function () {
    SEARCH.Init();
});