
$(document).ready(function () {
    datepicker.init();
});

var datepicker = (function () {
    var $term = $('#Term'),
        dateFormat = 'yy-mm-dd',
        minDate;
    // init
    var init = function () {
        initEvents();
        setMinDate();
        $($term).datetimepicker({
            dateFormat: dateFormat,
            minDate: minDate,
            hourMin: 8,
            hourMax: 21,
            showMinute: false,
            showButtonPanel: false
        });
    };
    var initEvents = function () {
        $($term).on('change', datetOnChange);
    };
    //format yy/mm/dd
    var setMinDate = function () {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yy = today.getFullYear();
        minDate = yy + '-' + mm + '-' + dd;
    };
    var datetOnChange = function () {

    };
    return {
        init: init
    };
})();