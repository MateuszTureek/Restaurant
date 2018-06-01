
$(document).ready(function () {
    galleryModule.init();
});

var galleryModule = (function () {
    var $liMiniImages = $('#Images').children('li').not(':first-child').not(':last-child'),
        $mainImage = $('#MainImage'),
        $liLeftArrow = $('.left-arrow-li'),
        $liRightArrow = $('.right-arrow-li'),
        $gallerySlider=$('#GallerySlider'),
        //========================
        leftValue = 0,
        maxNumberOfMiniPhoto = 5,
        numberOfShifts = 0,
        shiftCounter = 0;
    var init = function () {
        animGallery();
        numberOfShifts = calculateAmountOfShifts();
        shiftCounter = numberOfShifts;
        initEvents();
    };
    var initEvents = function () {
        $($liMiniImages).on('click', liMiniPhotoOnClick);
        $($liLeftArrow).on('click', leftArrowOnClick);
        $($liRightArrow).on('click', rightArrowOnClick);
    };
    var animGallery = function () {
        $($gallerySlider).animate({ 'opacity': '1' },700);
    };
    var liMiniPhotoOnClick = function () {
        var $clickedImg = $(this).children('img');
        var src = $($clickedImg).attr('src');
        $($mainImage).hide().
                      attr('src', src).
                      fadeIn();
    };
    var leftArrowOnClick = function () {
        if (shiftCounter == 0) return;
        leftValue -= 20;
        $($liMiniImages).animate({
            'left': leftValue + '%'
        }, 300);
        --shiftCounter;
    };
    var rightArrowOnClick = function () {
        if (shiftCounter != 0 && shiftCounter > -1) return;
        leftValue += 20;
        $($liMiniImages).animate({
            'left': leftValue + '%'
        }, 300);
        ++shiftCounter;
    };
    var calculateAmountOfShifts = function () {
        var totalMiniPhoto = $($liMiniImages).length;
        return totalMiniPhoto % maxNumberOfMiniPhoto;
    };
    return {
        init: init
    };
})();