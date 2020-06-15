var STUDYCOURSEEDIT = (function () {
    "use strict";

    var selectors = {};
    var objs = {};
    var canInteract = false;
    var isNew = false;

    var propPrefix = 'Plans';

    function setSelectors() {
        selectors.controlsidebar = '.control-sidebar';
        selectors.canInteract = '#caninteract';
        selectors.urls = '#urls';
        selectors.container = '#featurecontainer';
        selectors.form = '#frmCourseSave';
        selectors.btnSave = '#btnSaveCourse';
        selectors.txtAreaDescription = '#Description';
        selectors.sortablePlanning = 'divPlans';
        selectors.divPlans = '#divPlans';
        selectors.planItem = '.studyplan';
        selectors.template = selectors.planItem + '.template';
        selectors.btnAddPlan = '#btn-course-plan-add';
        selectors.btnDeletePlan = '.btn-plan-delete';
        selectors.planCounter = '#planCounter';
        selectors.divNoItems = '#divNoItems';
        selectors.btnCollapse = '.btn-collapse';
        selectors.btnSavePlans = '#btn-course-plans-save';
        selectors.rangeSlider = 'input[type="range"]';
    }

    function cacheObjs() {
        objs.controlsidebar = $(selectors.controlsidebar);
        objs.container = $(selectors.container);
        objs.urls = $(selectors.urls);
        objs.form = $(selectors.form);
        objs.txtAreaDescription = $(selectors.txtAreaDescription);
        objs.sortablePlanning = document.getElementById(selectors.sortablePlanning);
        objs.divPlans = $(selectors.divPlans);
        objs.divNoItems = $(selectors.divNoItems);

    }

    function init() {
        setSelectors();
        cacheObjs();

        bindAll();

        canInteract = $(selectors.canInteract).val();
        isNew = window.location.href.indexOf('add') > -1;

        if (isNew) {
            console.log('new course');
        }

        MAINMODULE.Common.BindPopOvers();

        var urlPlans = objs.urls.data('urlListplansforedit');
        loadPlans(urlPlans);
    }

    function bindAll() {
        bindSelect2();
        bindBtnSaveForm();
        bindBtnAddPlan();
        bindBtnDeletePlan();
        bindBtnCollapse();
        bindBtnSavePlans();
    }

    function bindSelect2() {
        $('select.select2').each(function () {
            if ($(this).data('select2') === undefined) {
                $(this).select2({
                    width: 'element'
                });
            }
        });
    }

    function bindBtnSaveForm() {
        objs.container.on('click', selectors.btnSave, function () {
            var btn = $(this);
            var valid = objs.form.valid();

            if (valid && canInteract) {
                MAINMODULE.Common.DisableButton(btn);

                submitForm(btn);
            }
        });
    }

    function bindBtnAddPlan() {
        objs.container.on('click', selectors.btnAddPlan, function (e) {
            e.preventDefault();

            addNewPlan();

            return false;
        });
    }

    function bindBtnDeletePlan() {
        objs.container.on('click', selectors.btnDeletePlan, function (e) {
            e.preventDefault();

            var btn = $(this);

            deletePlan(btn);

            return false;
        });
    }


    function bindBtnCollapse() {
        objs.container.on('click', selectors.btnCollapse, function (e) {
            e.preventDefault();

            var btn = $(this);
            var icon = btn.find('i');

            var target = btn.closest('.studyplan').find('.collapse').first();
            var alternateIcon = icon.data('icon-alternate');
            var temp = icon.attr('class');
            icon.attr('class', alternateIcon);
            icon.data('icon-alternate', temp);

            $(target).slideToggle();

            return false;
        });
    }


    function bindBtnSavePlans() {
        objs.container.on('click', selectors.btnSavePlans, function (e) {
            e.preventDefault();
            var btn = $(this);

            MAINMODULE.Common.DisableButton(btn);

            var valid = objs.form.valid();

            if (valid && canInteract) {
                savePlans(btn, function (response) {
                    if (response.message) {
                        ALERTSYSTEM.Toastr.ShowWarning(response.message);
                    }
                });
            }
            else {
                MAINMODULE.Common.RemoveErrorFromButton(btn);
            }

            return false;
        });
    }

    function initSortable() {
        if (objs.sortablePlanning) {
            new Sortable(objs.sortablePlanning, {
                handle: '.handle',
                animation: 150,
                ghostClass: 'blue-background-class',
                onEnd: (e) => {
                    MAINMODULE.Common.RenameInputs(objs.divPlans, selectors.planItem, propPrefix);
                    reOrder(objs.divPlans, selectors.planItem, propPrefix);
                }
            });
        }
    }

    const initRangeSlider = (context) => {
        $(selectors.rangeSlider, context).each(function (index, element) {
            var slider = $(element);
            var handle;

            slider.rangeslider({
                polyfill: false,
                onInit: function (position, value) {
                    handle = setSliderHandler(handle, this.$range, this.value);
                },
                onSlide: function (position, value) {
                    handle.html(this.value);
                }
            }).on('input', function () {
                handle = setSliderHandler(handle, this.$range, this.value);
            });
        });
    };

    function setSliderHandler(handle, range, value) {
        if (handle === undefined) {
            handle = $('.rangeslider__handle', range);
        }

        handle.html(value);

        return handle;
    }

    function submitForm(btn, callback) {
        var url = objs.form.attr('action');

        var data = objs.form.serializeObject();

        $.post(url, data).done(function (response) {
            if (response.success === true) {
                MAINMODULE.Common.PostSaveCallback(response, btn);

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

    function loadPlans(url) {
        MAINMODULE.Ajax.LoadHtml(url, objs.divPlans).then(() => {
            objs.divNoItems = $(selectors.divNoItems);

            MAINMODULE.Common.RenameInputs(objs.divPlans, selectors.planItem, propPrefix);

            initSortable();

            checkNoItems(selectors.planItem, selectors.planCounter, objs.divNoItems);

            initRangeSlider(selectors.container);
        });
    }

    function addNewPlan() {
        var newPlanObj = $(selectors.template).first().clone();

        newPlanObj.find(':input').val('');

        newPlanObj.removeClass('template');

        newPlanObj.appendTo(selectors.divPlans);

        newPlanObj.find('input.form-control').first().focus();

        MAINMODULE.Common.RenameInputs(objs.divPlans, selectors.planItem, propPrefix);

        checkNoItems(selectors.planItem, selectors.planCounter, objs.divNoItems);

        MAINMODULE.Common.BindPopOvers();

        COMMONEDIT.ResetValidator(objs.form);

        initSortable();

        reOrder(objs.divPlans, selectors.planItem, propPrefix);

        initRangeSlider(newPlanObj);
    }

    function deletePlan(btn) {
        var plan = btn.closest(selectors.planItem);

        plan.remove();

        MAINMODULE.Common.RenameInputs(objs.divPlans, selectors.planItem, propPrefix);

        checkNoItems(selectors.planItem, selectors.planCounter, objs.divNoItems);

        COMMONEDIT.ResetValidator(objs.form);
    }



    function savePlans(btn, callback) {
        var url = objs.urls.data('urlPlansSave');

        var plans = $(selectors.planItem + ':not(.template)');
        var data = plans.find(':input, :hidden').serializeObject();

        $.post(url, data).done(function (response) {
            if (response.success === true) {
                MAINMODULE.Common.PostSaveCallback(response, btn);

                MAINMODULE.Common.HandleSuccessDefault(response, callback, function (result) {
                    MAINMODULE.Common.RemoveErrorFromButton(btn);

                    loadPlans(objs.urls.data('urlListplansforedit'));
                });
            }
            else {
                ALERTSYSTEM.ShowWarningMessage("An error occurred! Check the console!");
            }
        });
    }

    function checkNoItems(itemSelector, counterSelector, noItemObject) {
        var count = $(itemSelector + ':not(.template)').length;

        $(counterSelector).html(count);

        if (count === 0) {
            noItemObject.show();
        }
        else {
            noItemObject.hide();
        }
    }

    function reOrder(objContainer, itemSelector, propPreffix) {
        var count = 0;

        objContainer.find(itemSelector + ' .order').each(function (index2, element2) {
            $(this).val(count);
            count++;
        });
    }

    return {
        Init: init
    };
}());

$(function () {
    STUDYCOURSEEDIT.Init();
});
