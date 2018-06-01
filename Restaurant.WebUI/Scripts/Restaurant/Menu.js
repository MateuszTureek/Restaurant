
$(document).ready(function () {
    menuModule.init();
});

var menuModule = (function () {
    var $bg4 = $('#Bg-4');
    var init = function () {
        animBg4();
    };
    var animBg4 = function () {
        $($bg4).animate({ 'opacity': '1' }, 300);
    };
    return {
        init: init
    };
})();