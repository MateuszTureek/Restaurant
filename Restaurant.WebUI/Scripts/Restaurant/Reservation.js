
$(document).ready(function () {
    reservationModule.init();
});

var reservationModule = (function () {
    var $arrivedCheckBoxes = $('.arrived'),
        $arrivedConfirmButtons = $('.tdWithCheckbox').find('.btn'),
        $reservation = $('#Reservation');
    var init = function () {
        initEvents();
        arrivedOnChange();
        disabledWhenArrivedIsTrue();
        showReservationForm();
    };
    var initEvents = function () {
        $($arrivedCheckBoxes).on('change', arrivedOnChange);
        $($arrivedConfirmButtons).on('click', confirmArrivedOnClick);
    };
    var showReservationForm = function () {
        $($reservation).animate({ 'opacity': '1' }, 350);
    };
    var arrivedOnChange = function () {
        var $this = $(this);
        var $btns = $($this).siblings('input').filter('.btn');
        if ($($this).is(':checked')) {
            $($btns).css({ 'visibility': 'visible' });
        }
        else {
            $($btns).css({ 'visibility': 'hidden' });
        }
    };
    var disabledWhenArrivedIsTrue = function () {
        $.each($arrivedConfirmButtons, function (i, $object) {
            var dataVal = $($object).data('arrived');
            dataVal = JSON.parse(dataVal.toLowerCase());
            if (dataVal === true) {
                var $siblingCheckbox = $($object).siblings('input');
                $($siblingCheckbox).attr('disabled', 'disabled');
            }
        });
    };
    var confirmArrivedOnClick = function () {
        var $this = $(this);
        var reservationID = $($this).closest('td').data('id');
        $.ajax({
            url: '/Reservation/ConfirmArrived/',
            data: { id: reservationID },
            method: 'POST',
            success: function (result) {
                if (result === 200) {
                    location.reload();
                }
            },
            error: function () {
                alert('bad request');
            }
        });
    };
    return {
        init: init
    };
})();