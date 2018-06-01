
$(document).ready(function () {
    homeModule.init();
});

var homeModule = (function () {
    var $cardArray = $('.offer-card');
    var $bg1_Content_1 = $('.bg-1-content');
    var $bg3_Content_1 = $('.bg-3-content-1');
    var $bg3_Content_2 = $('.bg-3-content-2');
    var $bg_1 = $('#Bg-1');
    var $bg_2 = $('#Bg-2');

    var init = function () {
        bg1Anim();
        setupEvents();
        scrollActions();
        scrollForBg_1();
        scrollForBg_2();
    };

    var setupEvents = function () {
        $($cardArray).on('mouseover', cardArrayItemOnMouseOver);
        $($cardArray).on('mouseout', cardArrayItemOnMouseOut);
    };

    var cardArrayItemOnMouseOver = function () {
        var $this = $(this);
        var orderNumer = $($this).children('span').data('order');
        switch (orderNumer) {
            case 1:
                {
                    $($this).children('span').css('backgroundColor', 'green');
                    break;
                }
            case 2:
                {
                    $($this).children('span').css('backgroundColor', 'blue');
                    break;
                }
            case 3:
                {
                    $($this).children('span').css('backgroundColor', 'red');
                    break;
                }
            case 4:
                {
                    $($this).children('span').css('backgroundColor', 'yellow');
                    break;
                }
        }
    };

    var cardArrayItemOnMouseOut = function () {
        var $this = $(this);
        $($this).children('span').css('backgroundColor', '#808080');
    };

    var scrollActions = function () {
        var currentTopScroll = $(document).scrollTop();
        var bg_1TopScroll = $($bg_1).offset().top;
        var bg_2TopScroll = $($bg_2).offset().top;
        if (currentTopScroll > bg_2TopScroll) {
            $($bg3_Content_1).css('opacity', '1');
            $($bg3_Content_2).css('opacity', '1');
        }

        if (currentTopScroll > bg_1TopScroll) {
            $($cardArray[0]).css('opacity', '1').css('height', '400px');
            $($cardArray[1]).css('opacity', '1').css('height', '400px');;
            $($cardArray[2]).css('opacity', '1').css('height', '400px');;
            $($cardArray[3]).css('opacity', '1').css('height', '400px');;
        }
    };

    var bg1Anim = function () {
        $($bg_1).animate({ "opacity": "1" }, 800, function () {
            $($bg1_Content_1).animate({ "left": "25%", "opacity": "1" }, 250);
        });
    };

    var cardItemsAnimate = function () {
        var during = 200;
        $($cardArray[0]).animate({ 'opacity': '1', 'height': '400px' }, during, function () {
            $($cardArray[1]).animate({ 'opacity': '1', 'height': '400px' }, during, function () {
                $($cardArray[2]).animate({ 'opacity': '1', 'height': '400px' }, during, function () {
                    $($cardArray[3]).animate({ 'opacity': '1', 'height': '400px' }, during);
                });
            });
        });
    };

    var bg3ContentsAnimate = function () {
        $($bg3_Content_1).animate({ 'opacity': '1' }, 300);
        $($bg3_Content_2).animate({ 'opacity': '1' }, 300);
    };

    var scrollForBg_1 = function () {
        var bg_1TopScroll = $($bg_1).offset().top;
        $(document).on('scroll', function () {
            if ($(document).scrollTop() > bg_1TopScroll) {
                cardItemsAnimate();
            }
        });
    };

    var scrollForBg_2 = function () {
        var bg_2TopScroll = $($bg_2).offset().top;
        $(document).on('scroll', function () {
            if ($(document).scrollTop() > bg_2TopScroll) {
                bg3ContentsAnimate();
                $(document).off('scroll');
            }
        });
    };

    return {
        init: init
    };

})();