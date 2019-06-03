var GAMEEDIT = (function () {
    "use strict";

    var selectors = {};

    var cropperGameThumbnail;
    var canvasGameThumbnail;
    var initialUrlGameThumbnail;
    var croppedGameThumbnail = false;

    var cropperCoverImage;
    var canvasGameCoverImage;
    var initialUrlGameCoverImage;
    var croppedGameCoverImage = false;

    function init() {
        console.log('init');

        cacheSelectors();

        bindAll();
    }

    function cacheSelectors() {
        selectors.form = $('#frmGameSave');
        selectors.UserId = $('#UserId');
        selectors.modalCropGameThumbnail = $('#modalCropGameThumbnail');
        selectors.modalCropGameCoverImage = $('#modalCropGameCoverImage');
        selectors.gameThumbnail = $("#ThumbnailUrl");
        selectors.gameCoverImage = $("#CoverImageUrl");
    }

    function bindAll() {
        bindSelect2();
        bindSave();

        bindCropGameThumbnail();
        bindCropGameCoverImage();
    }

    function bindSelect2() {
        $('.select2').select2();
    }

    function bindCropGameThumbnail() {
        var image = document.getElementById('imgGameThumbnail');
        var cropImage = document.getElementById('cropImageGameThumbnail');
        var input = document.getElementById('gamethumbnail');

        input.addEventListener('change', function (e) {
            if (cropperGameThumbnail !== undefined) {
                cropperGameThumbnail.destroy();
            }

            var files = e.target.files;
            var done = function (url) {
                input.value = '';
                cropImage.src = url;
                selectors.modalCropGameThumbnail.modal('show');
            };
            var reader;
            var file;

            if (files && files.length > 0) {
                file = files[0];

                if (URL) {
                    done(URL.createObjectURL(file));
                } else if (FileReader) {
                    reader = new FileReader();
                    reader.onload = function (e) {
                        done(reader.result);
                    };
                    reader.readAsDataURL(file);
                }
            }
        });

        selectors.modalCropGameThumbnail.on('shown.bs.modal', function () {
            cropperGameThumbnail = new Cropper(cropImage, {
                aspectRatio: 16 / 9,
                viewMode: 3,
                autoCropArea: 1
            });
        });

        document.getElementById('cropGameThumbnail').addEventListener('click', function () {
            croppedGameThumbnail = true;
            if (cropperGameThumbnail) {
                canvasGameThumbnail = cropperGameThumbnail.getCroppedCanvas({
                    width: 500,
                    minWidth: 500
                });
                initialUrlGameThumbnail = image.src;
                image.src = canvasGameThumbnail.toDataURL();
            }

            selectors.modalCropGameThumbnail.modal('hide');
        });
    }

    function uploadGameThumbnailCropped(callback) {
        if (cropperGameThumbnail) {
            if (canvasGameThumbnail) {
                var gameId = document.getElementById('Id').value;
                var userId = document.getElementById('UserId').value;
                var currentImage = selectors.gameThumbnail.val();

                canvasGameThumbnail.toBlob(function (blob) {
                    var formData = new FormData();

                    formData.append('image', blob);
                    formData.append('gameId', gameId);
                    formData.append('userId', userId);
                    formData.append('currentImage', currentImage);

                    $.ajax('/storage/uploadgamethumbnail', {
                        method: "POST",
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (response) {
                            selectors.gameThumbnail.val(response.imageUrl);
                            if (callback) {
                                callback();

                                cropperGameThumbnail.destroy();
                                cropperGameThumbnail = null;
                            }
                        },
                        error: function (response) {
                            document.getElementById('gameThumbnail').src = initialUrlGameThumbnail;
                        }
                    });
                });
            }
        }
    }
    function bindCropGameCoverImage() {
        var image = document.getElementById('imgCoverImage');
        var cropImage = document.getElementById('cropImageGameCoverImage');
        var input = document.getElementById('gamecoverimage');

        input.addEventListener('change', function (e) {

            if (cropperCoverImage !== undefined) {
                cropperCoverImage.destroy();
            }

            var files = e.target.files;
            var done = function (url) {
                input.value = '';
                cropImage.src = url;
                selectors.modalCropGameCoverImage.modal('show');
            };
            var reader;
            var file;

            if (files && files.length > 0) {
                file = files[0];

                if (URL) {
                    done(URL.createObjectURL(file));
                } else if (FileReader) {
                    reader = new FileReader();
                    reader.onload = function (e) {
                        done(reader.result);
                    };
                    reader.readAsDataURL(file);
                }
            }
        });

        selectors.modalCropGameCoverImage.on('shown.bs.modal', function () {
            cropperCoverImage = new Cropper(cropImage, {
                aspectRatio: 6 / 1,
                viewMode: 3,
                autoCropArea: 1
            });
        });

        document.getElementById('cropGameCoverImage').addEventListener('click', function () {
            croppedGameCoverImage = true;
            if (cropperCoverImage) {
                canvasGameCoverImage = cropperCoverImage.getCroppedCanvas({
                    width: 1600,
                    minWidth: 1600
                });
                initialUrlGameCoverImage = image.src;
                image.src = canvasGameCoverImage.toDataURL();
            }

            selectors.modalCropGameCoverImage.modal('hide');
        });
    }

    function uploadGameCoverImage(callback) {
        if (cropperCoverImage) {
            if (canvasGameCoverImage) {
                var gameId = document.getElementById('Id').value;
                var userId = document.getElementById('UserId').value;
                var currentImage = selectors.gameCoverImage.val();

                canvasGameCoverImage.toBlob(function (blob) {
                    var formData = new FormData();

                    formData.append('image', blob);
                    formData.append('gameId', gameId);
                    formData.append('userId', userId);
                    formData.append('currentImage', currentImage);

                    $.ajax('/storage/uploadgamecoverimage', {
                        method: "POST",
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (response) {
                            selectors.gameCoverImage.val(response.imageUrl);
                            if (callback) {
                                callback();

                                cropperCoverImage.destroy();
                                cropperCoverImage = null;
                            }
                        },
                        error: function (response) {
                            document.getElementById('gameCoverImage').src = initialUrlGameCoverImage;
                        }
                    });
                });
            }
        }
    }

    function bindSave() {
        $('#frmGameSave').on('click', '#btnGameSave', function (e) {
            e.preventDefault();

            var btn = $(this);
            btn.button('loading');
            var icon = btn.find('i');

            icon.removeClass('fa-save');
            icon.addClass('fa-circle-notch fa-spin');

            var valid = selectors.form.valid();
            if (valid) {
                var posSaveFunction = function () {
                    icon.removeClass('fa-circle-notch fa-spin');
                    icon.addClass('fa-save');
                };

                if (croppedGameThumbnail && croppedGameCoverImage) {
                    uploadGameCoverImage(function () {
                        uploadGameThumbnailCropped(function () {
                            submitForm(posSaveFunction);
                        });
                    });
                }
                else if (croppedGameThumbnail && !croppedGameCoverImage) {
                    uploadGameThumbnailCropped(function () {
                        submitForm(posSaveFunction);
                    });
                }
                else if (!croppedGameThumbnail && croppedGameCoverImage) {
                    uploadGameCoverImage(function () {
                        submitForm(posSaveFunction);
                    });
                }
                else {
                    submitForm(posSaveFunction);
                }
            }

            return false;
        });
    }

    function submitForm(callback) {
        var url = selectors.form.attr('action');

        var data = selectors.form.serialize();

        $.ajax({
            type: "POST",
            url: url,
            data: data,
            enctype: 'multipart/form-data'
        }).done(function (response) {
            if (response.success === true) {
                if (callback) {
                    callback();
                }
                ALERTSYSTEM.ShowSuccessMessage("Awesome!", function (isConfirm) {
                    window.location = response.url;
                });
            }
            else {
                ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
            }
        });
    }

    return {
        Init: init
    };
}());


$(function () {
    GAMEEDIT.Init();
});


// must be set outside document.ready
$.validator.setDefaults({
    ignore: [],
    highlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').addClass('has-error');
        var tabPane = $(element).closest('.tab-pane');
        var tabs = tabPane.parent().parent();
        var tabPaneId = tabPane.prop('id');
        var tabsNav = tabs.find('.nav.nav-tabs');
        var tabPending = tabs.find('.nav-link[href$=' + tabPaneId + ']');   

        tabPending.addClass('has-error');

        var tab_content = $(element).parent().parent().parent().parent().parent().parent().parent();

        if ($(tab_content).find("fieldset.tab-pane.active:has(div.has-error)").length === 0) {
            $(tab_content).find("fieldset.tab-pane:has(div.has-error)").each(function (index, tab) {
                var id = $(tab).attr("id");
                $('a[href="#' + id + '"]').tab('show');
            });
        }
    },
    unhighlight: function (element, errorClass, validClass) {
        var tabPane = $(element).closest('.tab-pane');
        var tabs = tabPane.parent().parent();
        var tabPaneId = tabPane.prop('id');
        var tabsNav = tabs.find('.nav.nav-tabs');
        var tabPending = tabs.find('.nav-link[href$=' + tabPaneId + ']');
        
        var countError = $(element).closest('.tab-pane').find('.has-error').length;
        if (countError === 0) {
            tabPending.removeClass('has-error');
        }

        $(element).closest('.form-group').removeClass('has-error');
        $(element).removeClass(errorClass).addClass(validClass);        
        $(element.form).find("label[for=" + element.id + "]").removeClass(errorClass);
    }
});