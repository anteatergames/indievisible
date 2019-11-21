var CONTENTACTIONS = (function () {
    "use strict";

    var selectors = {};

    function init() {
        cacheSelectors();

        bindAll();
    }

    function cacheSelectors() {
    }

    function bindAll() {
        bindLikeBtn();
        bindCommentBtn();
        bindCommentTextArea();
        bindCommentSendBtn();
        bindShare();
    }

    function bindLikeBtn() {
        $('.content').on('click', '.btn-interaction-like', function (e) {
            var btn = $(this);
            var likeCount = btn.closest('.box-content').find('.like-count');
            var targetId = btn.data('id');

            if (btn.hasClass("like-liked")) {
                unlike(targetId).done(function (response) { unlikeCallback(response, likeCount, btn); });
            }
            else {
                like(targetId).done(function (response) { likeCallback(response, likeCount, btn); });
            }
        });
    }

    function bindCommentBtn() {
        $('.content').on('click', '.btn-interaction-comment', function (e) {
            $(this).closest('.box-content').find('textarea.commentbox').val('').focus();
        });
    }

    function bindCommentTextArea() {
        $('.content').on('keyup', 'textarea.commentbox', function (e) {
            var btn = $(this);

            if ((e.keyCode === 10 || e.keyCode === 13) && e.ctrlKey) {
                var txtArea = btn.closest('.interaction-commentbox').find('.commenttextarea');
                var url = txtArea.data('url');
                var commentCount = btn.closest('.box-content').find('.comment-count');
                var id = txtArea.data('usercontentid');
                var text = txtArea.val().replace(/\n/g, '<br>\n');
                var type = txtArea.data('usercontenttype');

                if (text.length > 0) {
                    comment(url, id, text, type).done(function (response) { commentCallback(response, commentCount, txtArea); });
                }
            }

            autosize(this);
        });
    }


    function bindCommentSendBtn() {
        $('.content').on('click', '.btn-interaction-comment-send', function (e) {
            var btn = $(this);
            var txtArea = btn.closest('.interaction-commentbox').find('.commenttextarea');
            var url = txtArea.data('url');

            var box = txtArea.closest('.box-content');
            var commentCount = box.find('.comment-count');
            var id = txtArea.data('usercontentid');
            var text = txtArea.val().replace(/\n/g, '<br>\n');
            var type = txtArea.data('usercontenttype');

            if (text.length > 0) {
                comment(url, id, text, type).done(function (response) { commentCallback(response, commentCount, txtArea); });
            }

        });
    }


    function bindShare() {
        $('body').on('click', '.btn-interaction-share', function (e) {
            e.preventDefault();
            var urlElement = $(this).closest('.box').find('.contenturl');

            var url = urlElement.prop('href');

            console.log(url);

            FB.ui({
                method: 'share',
                href: url
            }, function (response) { });
        });
    }


    function like(targetId) {
        return $.post("/content/like", { targetId: targetId });
    }
    function likeCallback(response, likeCount, btn) {
        if (response.success === true) {
            $(likeCount).text(response.value);

            btn.addClass('text-blue');
            btn.addClass('like-liked');
        }
    }

    function unlike(targetId) {
        return $.post("/content/unlike", { targetId: targetId });
    }
    function unlikeCallback(response, likeCount, btn) {
        if (response.success === true) {
            $(likeCount).text(response.value);

            btn.removeClass('text-blue');
            btn.removeClass('like-liked');
        }
    }

    function comment(url, contentId, text, type) {

        if (url === null || url === undefined || url.length === 0) {
            url = "/content/comment";
        }

        return $.post(url, { UserContentId: contentId, Text: text, UserContentType: type });
    }
    function commentCallback(response, commentCount, txtArea) {
        if (response.success === true) {
            var commentBox = txtArea.closest('.interaction-commentbox');
            var text = txtArea.val().replace(/\n/g, '<br>\n');
            txtArea.val('');
            $(commentCount).text(response.value);
            CONTENTACTIONS.AutosizeTextArea(txtArea[0]);

            var clone = $('.box-comment-template').first().clone();

            var avatar = commentBox.find('img').attr('src');
            clone.find('img').attr('src', avatar);
            clone.find('.comment-authorname').text(commentBox.data('fullname'));
            clone.find('.comment-content').html(text);

            var currentContentCommentBox = txtArea.closest('.box-comments').find('.box-commentsection');
            currentContentCommentBox.append(clone.removeClass('d-none'));
        }
    }


    function autosize(el) {
        setTimeout(function () {
            el.style.cssText = 'height:auto;';
            // for box-sizing other than "content-box" use:
            // el.style.cssText = '-moz-box-sizing:content-box';
            el.style.cssText = 'height:' + (el.scrollHeight + 2) + 'px';
        }, 0);
    }

    return {
        Init: init,
        AutosizeTextArea: autosize
    };
}());


$(function () {
    CONTENTACTIONS.Init();
});