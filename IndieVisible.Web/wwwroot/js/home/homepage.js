var HOMEPAGE = (function () {
    "use strict";

    var postModalActive = false;
    var divPostImagesActive = false;

    var postImagesDropZone = null;

    var defaultCommentBoxHeight = 0;
    var defaultTxtPostContentHeight = 0;

    //var spinner = '<div class="flex-square overlay rectangle bg-transparent"><div class="flex-square-inner"><div class="flex-square-inner-content text-dark"><i class="fa fa-spinner fa-3x fa-spin"></i></div></div></div>';

    var selectors = {};

    function init() {
        setSelectors();

        bindAll();

        loadCounters();

        loadLatestGames();

        loadActivityFeed();

        defaultCommentBoxHeight = Math.ceil(selectors.commentBox.outerHeight());

        defaultTxtPostContentHeight = Math.ceil(selectors.txtPostContent.height());
    }

    function setSelectors() {
        selectors.divCounters = $("#divCounters");
        selectors.divLatestGames = $("#divLatestGames");
        selectors.divActivityFeed = $("#divActivityFeed");
        selectors.divPostImages = $('div#divPostImages');
        selectors.txtPostContent = $('#txtPostContent');
        selectors.commentBox = $('.commentmodal');
        selectors.commentModal = $('.commentmodal .modal');
        selectors.postImages = $('#txtPostImages');
    }

    function bindAll() {
        bindSendSimpleContent();
        bindShowCommentModal();
        bindPostAddImageBtn();
        bindPostTextArea();
    }

    function bindPostTextArea() {
        $('.content').on('keydown', 'textarea.postbox', function (e) {
            var txtArea = $(this);
            if ((e.keyCode === 10 || e.keyCode === 13) && e.ctrlKey) {
                var text = txtArea.val();

                if (text.length > 0) {
                    // send
                }
            }

            autosize(this);
        });
    }

    function bindShowCommentModal() {
        $('.content').on('click', '.posttextarea', function (e) {
            if (postModalActive === false) {
                postModalActive = true;
                $('#modalPost').addClass('modal');
                $('#modalPost').modal('show');
                $('.commentmodal .modal').css('padding-right', '');
                $('.commentmodal .modal-header .close').show();
                $('.modal-backdrop').css('height', window.innerHeight + 'px');
                $('.modal-backdrop').css('top', window.pageYOffset + 'px');
            }
            $(this).focus();
            resizeCommentBox();
            selectors.commentModal.animate({ scrollTop: 0 }, "fast");
        });

        $('#modalPost').on('hidden.bs.modal', function (e) {
            if (postModalActive === true) {
                hidePostModal();
            }
            resizeCommentBox();
        });
    }

    function bindPostAddImageBtn() {
        Dropzone.autoDiscover = false;
        $('.content').on('click', '#btnPostAddImage', function (e) {

            if (divPostImagesActive) {
                hideImageAdd();
                resizeCommentBox();
            }
            else {
                divPostImagesActive = true;
                if (!postImagesDropZone) {
                    postImagesDropZone = new Dropzone("div#divPostImages", {
                        url: '/storage/uploadcontentimage',
                        paramName: 'upload',
                        addRemoveLinks: true,
                        autoProcessQueue: false,
                        maxFiles: 1
                        //resizeWidth
                    });

                    postImagesDropZone.on("addedfile", function (file) {
                        resizeCommentBox();
                    });
                }

                selectors.divPostImages.show();

                resizeCommentBox();
            }
        });
    }

    function bindSendSimpleContent() {
        $('.content').on('click', '#btnSendSimpleContent', function (e) {
            var btn = $(this);
            var txtArea = btn.closest('.simplecontentpostarea').find('.posttextarea');
            var text = txtArea.val().replace(/\n/g, '<br>\n');
            if (text.length === 0) {
                ALERTSYSTEM.ShowWarningMessage("You must type a text to post!");
                return false;
            }

            if (!postImagesDropZone) {
                var images = selectors.postImages.val();
                sendSimpleContent(text, images).done(function (response) {
                    hidePostModal();
                    hideImageAdd();
                    if (postImagesDropZone) {
                        postImagesDropZone.removeAllFiles();
                    }
                    sendSimpleContentCallback(response, txtArea);
                });
            }
            else {
                postImagesDropZone.processQueue();

                var files = postImagesDropZone.getAcceptedFiles();

                postImagesDropZone.on("success", function (file) {
                    var response = JSON.parse(file.xhr.response);
                    if (response.uploaded) {
                        selectors.postImages.val(selectors.postImages.val() + '|' + response.url);
                    }
                });

                postImagesDropZone.on("queuecomplete", function (file) {
                    var images = selectors.postImages.val();
                    sendSimpleContent(text, images).done(function (response) {
                        hidePostModal();
                        hideImageAdd();
                        postImagesDropZone.removeAllFiles();
                        sendSimpleContentCallback(response, txtArea);
                    });
                });
            }

        });
    }

    function resizeCommentBox() {

        var divPostImagesHeight = selectors.divPostImages.outerHeight();
        var h = Math.floor(selectors.txtPostContent.height());
        var txtPostContentHeight = h === defaultTxtPostContentHeight ? 0 : h - defaultTxtPostContentHeight;

        var height = defaultCommentBoxHeight + txtPostContentHeight;

        if (divPostImagesActive) {
            height += divPostImagesHeight;
        }

        selectors.commentModal.height(height);

        selectors.commentBox.height(height);
    }

    function hidePostModal() {
        postModalActive = false;
        $('.commentmodal .modal').css('padding-right', '');
        $('#modalPost').modal('hide');
        $('#modalPost').css('display', '');
        $('#modalPost').removeClass('modal');
        $('.commentmodal .modal-header .close').hide();
    }

    function hideImageAdd() {
        divPostImagesActive = false;
        selectors.divPostImages.hide();
    }

    function sendSimpleContent(text, images) {
        return $.post("/content/post", { text: text, images: images })
            .done(function (response) {
                if (!response.success) {
                    ALERTSYSTEM.ShowWarningMessage(response.message);
                }
            });
    }
    function sendSimpleContentCallback(response, txtArea) {
        if (response.success === true) {
            txtArea.val('');
            CONTENTACTIONS.AutosizeTextArea(txtArea[0]);
            loadActivityFeed();
            if (postImagesDropZone) {
                postImagesDropZone.disable();
            }
        }
    }

    function loadCounters() {
        selectors.divCounters.html(MAINMODULE.Default.Spinner);

        $.get("/home/counters", function (data) { selectors.divCounters.html(data); });
    }

    function loadLatestGames() {
        selectors.divLatestGames.html(MAINMODULE.Default.Spinner);

        $.get("/game/latest", function (data) { selectors.divLatestGames.html(data); });
    }

    function loadActivityFeed() {
        selectors.divActivityFeed.html(MAINMODULE.Default.Spinner);

        $.get("/content/feed", function (data) {
            selectors.divActivityFeed.html(data);
            loadOembeds();
        });
    }

    function loadOembeds() {
        var embedo = new Embedo({
            youtube: true,
            facebook: {
                appId: $('meta[property="fb:app_id"]').attr('content'), // Enable facebook SDK
                version: 'v3.2',
                width: "100%"
            }
        });

        var oembeds = $('oembed');

        oembeds.each(function (index, element) {
            $(element).find('embed').hide();

            var w = $(element).closest('.videoWrapper').width();
            var h = w * 9 / 16;

            embedo.load(element, element.innerHTML, {
                width: w,
                height: h,
                centerize: true,
                strict: false
            })
                .done(function (xpto) {
                    //$(element).find('embed').addClass('embed-responsive').show();
                });
        });
    }


    function autosize(el) {
        setTimeout(function () {
            el.style.cssText = 'height:auto;';
            el.style.cssText = 'height:' + (el.scrollHeight + 2) + 'px';

            resizeCommentBox();
        }, 0);
    }

    return {
        Init: init
    };
}());


$(function () {
    HOMEPAGE.Init();
});