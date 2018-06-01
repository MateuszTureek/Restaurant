
$(document).ready(function () {
    photoModule.init();
});

var photoModule = (function () {
    var $photo = $('img', '.f-photo'),
        $file = $('#PhotoFile');
    var init = function () {
        initEvents();
        if ($($file).val() != '') {
            readURL($($file).get(0));
        }
    };
    var initEvents = function () {
        $($file).on('change', function () {
            readURL(this);
        });
    };
    var readURL = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $($photo).attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    };
    return {
        init: init
    };
})();