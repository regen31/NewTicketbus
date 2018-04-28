var IdFromAtr = null;
var datefromAtr = null;
var ChosenSeats = [];
var CurrentPaymentOption = null;
var $BusScheme = null;
var LoginBool = null;


function GetUnavailableSeats(Route, dateforsearch) {
    var seats = null;

    $.ajax({
        url: "/Order/GetBoughtTicketsSeatsId",
        async: false,
        type: "POST",
        data: {RouteId: Route, date: dateforsearch},
        datatype: "json",

        success: function (result) {             
            seats = result;
        }
    });
    return seats;
};

function SuccessOrder(result) {
    $('#PaymentFormContainer').empty();
    $('#PaymentFormContainer').append(result);
}

//order-button click
$('body').on('click', '.order-button', function () {

    if (LoginBool) {
        IdFromAtr = $(this).attr('routeId');
        datefromAtr = $(this).attr('searchDate');
        var seatsList = GetUnavailableSeats(IdFromAtr, datefromAtr);

        $.ajax({
            url: "/Order/GetScheme",
            type: "GET",
            datatype: 'html',
            beforeSend: function () {
                $whiteoverlay.show();
            },

            success: function (result) {
                $whiteoverlay.hide();
                $('body').append("<div class='grey-overlay' id='SchemeContainer'></div>");
                $('#SchemeContainer').append(result);                
                
                seatsList.forEach(function (item, i, seatsList) {
                    var element = document.getElementById(item);
                    element.classList.remove('available');
                    element.classList.add("unavailable");
                });                
                $BusScheme = $('#SchemeContainer');
                $('#scheme-window').css('display', 'block');
            }
        })       
    } else {
        $('#not-login-message').css('display', 'inline-block');
    }
})


//click on available seat
$('body').on('click', '.available', function (event) {
    $(this).removeClass('available');
    $(this).addClass('chosen');
    var seatID = $(this).attr('id');
    ChosenSeats.push(+seatID);
});


//click on cancel button
$('body').on('click', '#CancelChanges', function (event) {
    $('.chosen').removeClass('chosen').addClass('available');
    ChosenSeats = [];    
});



//click on "ContinueFromScheme" button
$('body').on('click', '#ContinueFromScheme', function (event) {

    if (ChosenSeats.length > 0) {
        $.ajax({
            url: "/Order/ShowPaymentOptions",
            type: "GET",            
            datatype: 'html',
            beforeSend: function () {
                $('#SchemeContainer').remove();
                $whiteoverlay.show();
            },

            success: function (result) {
                $whiteoverlay.hide();
                $('body').append("<div class='grey-overlay' id='PaymentsContainer'></div>");
                $('#PaymentsContainer').append(result);               
            }
        });
    }    
});

//payment-block click
$('body').on('click', '.payment-block', function (event) {
    CurrentPaymentOption = $(this).attr('id');
    $('.payment-block').css('border', '1px solid grey');
    $(this).css('border', "3px solid #53A6F9");
});

//continue from payment options
$('body').on('click', '#ContinueFromPaymentOptions', function (event) {
    if (CurrentPaymentOption) {

        $.ajax({
            url: "/Order/ShowPaymentForm",
            type: "POST",
            data: { RouteId: IdFromAtr, DepartDate: datefromAtr, ChosenSeats: ChosenSeats, PaymentOption: CurrentPaymentOption, },
            datatype: 'html',
            beforeSend: function () {
                $('#PaymentsContainer').remove();
                $whiteoverlay.show();
            },
            success: function (result) {
                $whiteoverlay.hide();
                $('body').append("<div class='grey-overlay' id='PaymentFormContainer'></div>");
                $('#PaymentFormContainer').append(result);
            }
        });
    }

});

//return from payment options
$('body').on('click', '#ReturnToScheme', function (event) {
    $whiteoverlay.show();
    $('#PaymentsContainer').remove();
    $whiteoverlay.hide();
    $('body').append($BusScheme);
});

//OVERLAYS
//bus scheme
$('body').on('click', '#SchemeContainer', function (event) {
    ChosenSeats = [];
    $('#SchemeContainer').remove();
})
$('body').on('click', '#scheme-window', function (event) {
    event.stopPropagation();
})

//payment options
$('body').on('click', '#PaymentsContainer', function (event) {
    ChosenSeats = [];
    CurrentPaymentOption = null;
    $('#PaymentsContainer').remove();
})
$('body').on('click', '.payment-container', function (event) {
    event.stopPropagation();
})