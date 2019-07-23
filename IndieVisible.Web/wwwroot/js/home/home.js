var HOMEPAGE = (function () {
    "use strict";

    var postModalActive = false;
    var divPostImagesActive = false;
    var divPostPollActive = false;

    var postImagesDropZone = null;

    var minheight = 160;
    var defaultCommentBoxHeight = minheight;
    var defaultTxtPostContentHeight = 0;
    var selectors = {};

    function init() {
        setSelectors();

        bindAll();

        loadCounters();

        loadLatestGames();

        loadActivityFeed();

        //defaultCommentBoxHeight = Math.ceil(selectors.commentBox.outerHeight());

        defaultTxtPostContentHeight = Math.ceil(selectors.txtPostContent.height());

        POLLS.Events.PostAddOption = resizePostBox;
    }

    function setSelectors() {
        selectors.divCounters = $("#divCounters");
        selectors.divLatestGames = $("#divLatestGames");
        selectors.divActivityFeed = $("#divActivityFeed");
        selectors.divPostImages = $('div#divPostImages');
        selectors.divPostPoll = $('div#divPostPoll');
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
        bindBtnPostAddPollBtn();
        bindPostModalHide();
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
                showPostModal();
            }
            $(this).focus();
            resizePostBox();
            selectors.commentModal.animate({ scrollTop: 0 }, "fast");
        });

        $('#modalPost').on('hidden.bs.modal', function (e) {
            if (postModalActive === true) {
                hidePostModal();
            }
            else {
                resizePostBox();
            }
            POLLS.Methods.ClearOptions();
        });
    }

    function bindPostAddImageBtn() {
        Dropzone.autoDiscover = false;
        $('.content').on('click', '#btnPostAddImage', function (e) {
            if (postModalActive === false) {
                showPostModal();
            }

            if (divPostImagesActive) {
                hideImageAdd();

                if (postImagesDropZone) {
                    postImagesDropZone.destroy();
                    postImagesDropZone = null;
                }
            }
            else {
                divPostImagesActive = true;
                if (!postImagesDropZone) {
                    instantiateDropZone();

                    postImagesDropZone.on("addedfile", function (file) {
                        resizePostBox();
                    });
                }

                selectors.divPostImages.show();

            }

            resizePostBox();
        });
    }

    function bindBtnPostAddPollBtn() {
        $('.content').on('click', '#btnPostAddPoll', function (e) {
            if (postModalActive === false) {
                showPostModal();
            }

            if (divPostPollActive) {
                hidePollAdd();
                POLLS.Methods.ClearOptions();
            } else {
                showPollAdd();
            }

            resizePostBox();
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

            var languageSelect = selectors.commentBox.find('#postlanguage');
            var language = languageSelect.val()

            var pollOptions = document.getElementsByClassName("polloptioninput");

            var options = $(pollOptions).map(function () {
                var imageBtn = $(this).next().children();
                var img = imageBtn.data('image');
                return this.value ? {
                    text: this.value,
                    image: img
                } : null;
            }).get();
            
            if (!postImagesDropZone || postImagesDropZone.getQueuedFiles().length === 0) {
                var images = selectors.postImages.val();
                var json = { text: text, images: images, pollOptions: options, language: language };

                sendSimpleContent(json).done(function (response) {
                    sendSimpleContentCallback(response, txtArea);
                });
            }
            else {
                postImagesDropZone.processQueue();

                postImagesDropZone.on("success", function (file) {
                    var response = JSON.parse(file.xhr.response);
                    if (response.uploaded) {
                        selectors.postImages.val(selectors.postImages.val() + '|' + response.url);
                    }
                });

                postImagesDropZone.on("queuecomplete", function (file) {
                    var images2 = selectors.postImages.val();
                    var json2 = { text: text, images: images2, pollOptions: options };
                    sendSimpleContent(json2).done(function (response) {
                        sendSimpleContentCallback(response, txtArea);

                        if (postImagesDropZone) {
                            postImagesDropZone.destroy();
                            postImagesDropZone = null;
                        }


                        instantiateDropZone();
                    });
                });
            }
        });
    }

    function bindPostModalHide() {
        $('#modalPost').on('hide.bs.modal', function (e) {
            hideImageAdd();
            hidePollAdd();
        });
    }

    function instantiateDropZone() {
        postImagesDropZone = new Dropzone("div#divPostImages", {
            url: '/storage/uploadcontentimage',
            paramName: 'upload',
            addRemoveLinks: true,
            autoProcessQueue: false,
            maxFiles: 1
            //resizeWidth
        });
    }

    function showPostModal() {
        postModalActive = true;
        $('#modalPost').addClass('modal');
        $('#modalPost').modal('show');
        $('.commentmodal').css('min-height', '160px');
        $('.commentmodal .modal').css('padding-right', '');
        $('.commentmodal .modal-header').removeClass('d-none');
        $('.commentmodal .modal-footer').removeClass('d-none');
        $('.commentmodal .modal-header .close').show();
        $('.modal-backdrop').css('height', window.innerHeight + 'px');
        $('.modal-backdrop').css('top', window.pageYOffset + 'px');
    }

    function resizePostBox() {

        var divPostImagesHeight = selectors.divPostImages.outerHeight();
        var divPostPollHeight = selectors.divPostPoll.outerHeight();

        var h = Math.floor(selectors.txtPostContent.height());
        var txtPostContentHeight = h === defaultTxtPostContentHeight ? 0 : h - defaultTxtPostContentHeight;


        var height = defaultCommentBoxHeight + txtPostContentHeight;

        var extra = 0;

        if (divPostImagesActive) {
            height += divPostImagesHeight;
            extra += 10;
        }

        if (divPostPollActive) {
            height += divPostPollHeight;
            extra += 10;
        }

        height += extra;

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

        $('.commentmodal .modal-header').addClass('d-none');
        $('.commentmodal .modal-footer').addClass('d-none');

        $('.commentmodal').css('height', 'auto');
        $('.commentmodal').css('min-height', 'auto');
    }

    function hideImageAdd() {
        divPostImagesActive = false;
        selectors.divPostImages.hide();
    }

    function hidePollAdd() {
        divPostPollActive = false;
        selectors.divPostPoll.hide();
    }

    function showPollAdd() {
        divPostPollActive = true;
        selectors.divPostPoll.show();
    }

    function sendSimpleContent(json) {
        return $.post("/content/post", json)
            .done(function (response) {
                if (!response.success) {
                    ALERTSYSTEM.ShowWarningMessage(response.message);
                }
            });
    }
    function sendSimpleContentCallback(response, txtArea) {

        hidePostModal();
        hideImageAdd();
        if (postImagesDropZone) {
            postImagesDropZone.removeAllFiles();
        }

        if (response.success === true) {
            txtArea.val('');
            CONTENTACTIONS.AutosizeTextArea(txtArea[0]);
            loadActivityFeed();
            if (postImagesDropZone) {
                postImagesDropZone.disable();
            }

            selectors.postImages.val('');
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

            resizePostBox();
        }, 0);
    }

    return {
        Init: init
    };
}());


$(function () {
    HOMEPAGE.Init();
});