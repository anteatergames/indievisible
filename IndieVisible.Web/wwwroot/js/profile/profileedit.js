var PROFILEEDIT = (function () {
    "use strict";

    var selectors = {};
    var objs = {};

    var cropperAvatar;
    var canvasAvatar;
    var initialUrlAvatar;
    var croppedAvatar = false;

    var cropperCoverImage;
    var canvasCoverImage;
    var initialUrlCoverImage;
    var croppedCoverImage = false;

    function init() {
        setSelectors();
        cacheObjects();

        bindAll();
    }

    function setSelectors() {
        selectors.form = '#frmProfileSave';
        selectors.UserId = '#UserId';
        selectors.modalCropAvatar = '#modalCropAvatar';
        selectors.modalCropCoverImage = '#modalCropCoverImage';
        selectors.profileImageUrl = "#ProfileImageUrl";
        selectors.coverImage = "#CoverImageUrl";
        selectors.btnClearExternalLink = '.btnClearExternalLink';
        selectors.country = '#Country';
        selectors.location = '#Location';
    }

    function cacheObjects() {
        objs.form = $(selectors.form);
        objs.UserId = $(selectors.UserId);
        objs.modalCropAvatar = $(selectors.modalCropAvatar);
        objs.modalCropCoverImage = $(selectors.modalCropCoverImage);
        objs.profileImageUrl = $(selectors.profileImageUrl);
        objs.coverImage = $(selectors.coverImage);
        objs.country = $(selectors.country);
        objs.location = $(selectors.location);
    }

    function bindAll() {
        bindCropAvatar();
        bindCropCoverImage();

        bindSave();

        bindClearExternalLink();
        bindCountry();
        bindLocation();
    }

    function bindClearExternalLink() {
        objs.form.on('click', selectors.btnClearExternalLink, function (e) {
            $(this).closest('.input-group').find('input[type=text]').val('');
        });
    }

    function bindCountry() {

        objs.country.select2();
    }

    function bindLocation() {
        var url = objs.location.data('url');

        objs.location.select2({
            tags:true,
            ajax: {
                minimumInputLength: 3,
                url: url,
                dataType: 'json',
                data: function (params) {
                    var query = {
                        q: params.term,
                        country: objs.country.val()
                    };
                    return query;
                },
                processResults: function (data) {
                    var results = [];
                    $.each(data, function (index, account) {
                        results.push({
                            id: account.value,
                            text: account.text
                        });
                    });

                    return {
                        results: results
                    };
                }
            }
        });
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
                objs.modalCropAvatar.modal('show');
            };
            var reader;
            var file;

            if (files && files.length > 0) {
                file = files[0];

                if (URL) {
                    done(URL.createObjectURL(file));
                } else if (FileReader) {
                    reader = new FileReader();
                    reader.onload = function (e2) {
                        console.log(e2.target.result);
                        console.log(reader.result);
                        done(reader.result);
                    };
                    reader.readAsDataURL(file);
                }
            }
        });

        objs.modalCropAvatar.on('shown.bs.modal', function () {
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

            objs.modalCropAvatar.modal('hide');
        });
    }

    function uploadAvatarCropped(callback) {
        if (cropperAvatar) {
            if (canvasAvatar) {
                var userId = document.getElementById('UserId').value;
                var currentImage = objs.profileImageUrl.val();

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
                            objs.profileImageUrl.val(response.imageUrl);
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
                objs.modalCropCoverImage.modal('show');
            };
            var reader;
            var file;

            if (files && files.length > 0) {
                file = files[0];

                if (URL) {
                    done(URL.createObjectURL(file));
                } else if (FileReader) {
                    reader = new FileReader();
                    reader.onload = function (e2) {
                        done(reader.result);
                    };
                    reader.readAsDataURL(file);
                }
            }
        });

        objs.modalCropCoverImage.on('shown.bs.modal', function () {
            cropperCoverImage = new Cropper(cropImage, {
                aspectRatio: 37 / 10,
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

            objs.modalCropCoverImage.modal('hide');
        });
    }

    function uploadCoverImage(callback) {
        if (cropperCoverImage) {
            if (canvasCoverImage) {
                var profileId = document.getElementById('Id').value;
                var userId = document.getElementById('UserId').value;
                var currentImage = objs.coverImage.val();

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
                            objs.coverImage.val(response.imageUrl);
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
            MAINMODULE.Common.DisableButton(btn);

            var valid = objs.form.valid();
            if (valid) {
                if (croppedAvatar && croppedCoverImage) {
                    uploadCoverImage(function () {
                        uploadAvatarCropped(function () {
                            submitForm(btn);
                        });
                    });
                }
                else if (croppedAvatar && !croppedCoverImage) {
                    uploadAvatarCropped(function () {
                        submitForm(btn);
                    });
                }
                else if (!croppedAvatar && croppedCoverImage) {
                    uploadCoverImage(function () {
                        submitForm(btn);
                    });
                }
                else {
                    submitForm(btn);
                }
            }

            return false;
        });
    }

    function submitForm(btn) {
        var url = objs.form.attr('action');

        var data = objs.form.serialize();

        $.ajax({
            type: "POST",
            url: url,
            data: data,
            enctype: 'multipart/form-data'
        }).done(function (response) {
            if (response.success === true) {
                MAINMODULE.Common.PostSaveCallback(response, btn);

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