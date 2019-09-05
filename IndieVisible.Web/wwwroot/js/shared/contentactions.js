var CONTENTACTIONS = (function () {
    "use strict";

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
            var commentCount = btn.closest('.box-content').find('.comment-count');

            if ((e.keyCode === 10 || e.keyCode === 13) && e.ctrlKey) {
                var txtArea = $(this);
                var id = txtArea.data('usercontentid');
                var text = txtArea.val();
                var type = txtArea.data('usercontenttype');

                if (text.length > 0) {
                    comment(id, text, type).done(function (response) { commentCallback(response, commentCount, txtArea); });
                }
            }

            autosize(this);
        });
    }


    function bindCommentSendBtn() {
        $('.content').on('click', '.btn-interaction-comment-send', function (e) {
            var btn = $(this);
            var txtArea = btn.closest('.interaction-commentbox').find('.commenttextarea');

            var box = txtArea.closest('.box-content');
            var commentCount = box.find('.comment-count');
            var id = txtArea.data('usercontentid');
            var text = txtArea.val().replace(/\n/g, '<br>\n');
            var type = txtArea.data('usercontenttype');

            if (text.length > 0) {
                comment(id, text, type).done(function (response) { commentCallback(response, commentCount, txtArea); });
            }

        });
    }


    function bindShare() {
        $('body').on('click', '.btn-interaction-share', function () {
            var urlElement = $(this).closest('.box').find('.contenturl');

            var url = urlElement.prop('href');

            FB.ui({
                method: 'share',
                href: url,
            }, function (response) { });
        });
    }

    function bindMorePosts() {
        $('body').on('click', '#btnMorePosts', function () {
            console.log('btnMorePosts');
        });
    }



    function like(targetId) {
        return $.post("/interact/content/like", { targetId: targetId });
    }
    function likeCallback(response, likeCount, btn) {
        if (response.success === true) {
            $(likeCount).text(response.value);

            btn.addClass('text-blue');
            btn.addClass('like-liked');
        }
    }

    function unlike(targetId) {
        return $.post("/interact/content/unlike", { targetId: targetId });
    }
    function unlikeCallback(response, likeCount, btn) {
        if (response.success === true) {
            $(likeCount).text(response.value);

            btn.removeClass('text-blue');
            btn.removeClass('like-liked');
        }
    }

    function comment(contentId, text, type) {
        return $.post("/interact/content/comment", { UserContentId: contentId, Text: text, UserContentType: type });
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
            clone.find('.comment-date').html('<i class="fa fa-asterisk"></i>');
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