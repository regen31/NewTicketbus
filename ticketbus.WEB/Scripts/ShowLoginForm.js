
function IsLogin(){
    var $SignInButton = $("#SignInButton");
    var $RegistrationButton = $("#RegistrationButton");
    var $LogOffButton = $("#LogOffButton");
    var $OrderHistoryButton = $("#OrderHistoryButton");


    $.ajax({
        url: "/Account/IsLogin",
        type: "GET",
        datatype: "json",
        success: function (result) {
            if (result == false) {

                $SignInButton.show();
                $RegistrationButton.show();
                $LogOffButton.hide();
                $OrderHistoryButton.hide();
                $('.order-button').hide();
            }
            if (result == true) {
                $SignInButton.hide();
                $RegistrationButton.hide();
                $LogOffButton.show();
                $OrderHistoryButton.show();
                $('.order-button').show();
            }
        }
    })
}





//order-button click
$('body').on('click', '.order-button', function () {
    var IdFromAtr = $(this).attr('routeId');
    var datefromAtr = $(this).attr('searchDate');
    
    $.ajax({
        url: "/Order/BuyTicket",
        type: "POST",
        data: { RouteId: IdFromAtr, date: datefromAtr },
        beforeSend: function () {
            $whiteoverlay.show();
        },
        success: function (result) {
            $whiteoverlay.hide();
            alert(result); //пока что просто алерт с результатом частичного представления
        }
        
    })
})



//History PartialView
$('#OrderHistoryButton').click(function (event) {
    $.ajax({
        url: "/Order/GetUsersOrders",
        type: "GET",
        datatype: 'html',
        beforeSend: function () {
            $whiteoverlay.show();
        },
        success: function (result) {            
            $('body').append("<div class='grey-overlay' id='HistoryContainer'></div>");
            $('#HistoryContainer').append(result);
            $whiteoverlay.hide();
        }
    })
})
$('body').on('click', '#HistoryContainer', function (event) {
    $('#HistoryContainer').remove();
})
$('body').on('click', '.user-orders-partial', function (event) {
   event.stopPropagation();
})


//on start
$(document).ready(function () {
    IsLogin();
    $whiteoverlay = $('#white-overlay');
    $whiteoverlay.hide();    
})


//overlay for login form
    var $container = $('#over-lay');
    $container.hide();

    SignInButton.onclick = function () {

        $container.fadeIn(200);
    }

    $container.click(function (event) {
        $container.fadeOut(200);
    })

    $('#over-lay').on('click', '#SignInForm', function (event) {
       event.stopPropagation();
    })

    







