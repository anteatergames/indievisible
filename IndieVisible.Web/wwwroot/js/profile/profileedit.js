var PROFILEEDIT = (function () {
    "use strict";

    var selectors = {};

    var cropperAvatar;
    var canvasAvatar;
    var initialUrlAvatar;
    var croppedAvatar = false;

    var cropperCoverImage;
    var canvasCoverImage;
    var initialUrlCoverImage;
    var croppedCoverImage = false;

    function init() {
        cacheSelectors();

        bindAll();
    }

    function cacheSelectors() {
        selectors.form = $('#frmProfileSave');
        selectors.UserId = $('#UserId');
        selectors.modalCropAvatar = $('#modalCropAvatar');
        selectors.modalCropCoverImage = $('#modalCropCoverImage');
        selectors.profileImageUrl = $("#ProfileImageUrl");
        selectors.coverImage = $("#CoverImageUrl");
    }

    function bindAll() {
        bindCropAvatar();
        bindCropCoverImage();

        bindSave();
    }

    function bindCropAvatar() {
        var image = document.getElementById('imgAvatar');
        var cropImage = document.getElementById('avatarCropArea');
        var input = document.getElementById('avatar');

        input.addEventListener('change', function (e) {

            if (cropperAvatar !== undefined) {
                cropperAvatar.destroy();
            }

            var files = e.target.files;
            var done = function (url) {
                input.value = '';
                cropImage.src = url;
                selectors.modalCropAvatar.modal('show');
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
                        console.log(e.target.result);
                        console.log(reader.result);
                        done(reader.result);
                    };
                    reader.readAsDataURL(file);
                }
            }
        });

        selectors.modalCropAvatar.on('shown.bs.modal', function () {
            cropperAvatar = new Cropper(cropImage, {
                aspectRatio: 1 / 1,
                viewMode: 3,
                autoCropArea: 1
            });
        });

        document.getElementById('cropAvatar').addEventListener('click', function () {
            croppedAvatar = true;
            if (cropperAvatar) {
                canvasAvatar = cropperAvatar.getCroppedCanvas({
                    width: 256,
                    minWidth: 256
                });
                initialUrlAvatar = image.src;
                image.src = canvasAvatar.toDataURL();
            }

            selectors.modalCropAvatar.modal('hide');
        });
    }

    function uploadAvatarCropped(callback) {
        if (cropperAvatar) {
            if (canvasAvatar) {
                var userId = document.getElementById('UserId').value;
                var currentImage = selectors.profileImageUrl.val();

                canvasAvatar.toBlob(function (blob) {
                    var formData = new FormData();

                    formData.append('image', blob);
                    formData.append('userId', userId);
                    formData.append('currentImage', currentImage);

                    $.ajax('/storage/uploadavatar', {
                        method: "POST",
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (response) {
                            selectors.profileImageUrl.val(response.imageUrl);
                            if (callback) {
                                callback();

                                cropperAvatar.destroy();
                                cropperAvatar = null;
                            }
                        },
                        error: function (response) {
                            document.getElementById('ProfileImageUrl').src = initialUrlAvatar;
                        }
                    });
                });
            }
        }
    }
    function bindCropCoverImage() {
        var image = document.getElementById('imgCoverImage');
        var cropImage = document.getElementById('coverImageCropArea');
        var input = document.getElementById('coverImage');

        input.addEventListener('change', function (e) {

            if (cropperCoverImage !== undefined) {
                cropperCoverImage.destroy();
            }

            var files = e.target.files;
            var done = function (url) {
                input.value = '';
                cropImage.src = url;
                selectors.modalCropCoverImage.modal('show');
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

        selectors.modalCropCoverImage.on('shown.bs.modal', function () {
            cropperCoverImage = new Cropper(cropImage, {
                aspectRatio: 6 / 1,
                viewMode: 3,
                autoCropArea: 1
            });
        });

        document.getElementById('cropCoverImage').addEventListener('click', function () {
            croppedCoverImage = true;
            if (cropperCoverImage) {
                canvasCoverImage = cropperCoverImage.getCroppedCanvas({
                    width: 1200,
                    minWidth: 1200
                });
                initialUrlCoverImage = image.style.backgroundImage;
                $(image).css("background-image", "url('" + canvasCoverImage.toDataURL() + "')");
            }

            selectors.modalCropCoverImage.modal('hide');
        });
    }

    function uploadCoverImage(callback) {
        if (cropperCoverImage) {
            if (canvasCoverImage) {
                var profileId = document.getElementById('Id').value;
                var userId = document.getElementById('UserId').value;
                var currentImage = selectors.coverImage.val();

                canvasCoverImage.toBlob(function (blob) {
                    var formData = new FormData();

                    formData.append('image', blob);
                    formData.append('profileId', profileId);
                    formData.append('userId', userId);
                    formData.append('currentImage', currentImage);

                    $.ajax('/storage/uploadprofilecoverimage', {
                        method: "POST",
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (response) {
                            selectors.coverImage.val(response.imageUrl);
                            if (callback) {
                                callback();

                                cropperCoverImage.destroy();
                                cropperCoverImage = null;
                            }
                        },
                        error: function (response) {
                            document.getElementById('coverImage').src = initialUrlCoverImage;
                        }
                    });
                });
            }
        }
    }


    function bindSave() {
        $('#frmProfileSave').on('click', '#btnProfileSave', function (e) {
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

                if (croppedAvatar && croppedCoverImage) {
                    uploadCoverImage(function () {
                        uploadAvatarCropped(function () {
                            submitForm(posSaveFunction);
                        });
                    });
                }
                else if (croppedAvatar && !croppedCoverImage) {
                    uploadAvatarCropped(function () {
                        submitForm(posSaveFunction);
                    });
                }
                else if (!croppedAvatar && croppedCoverImage) {
                    uploadCoverImage(function () {
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
    PROFILEEDIT.Init();
});