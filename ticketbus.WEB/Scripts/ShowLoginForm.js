
function IsLogin(){
    var $SignInButton = $("#SignInButton");
    var $RegistrationButton = $("#RegistrationButton");
    var $LogOffButton = $("#LogOffButton");


    $.ajax({
        url: "/Account/IsLogin",
        type: "GET",
        datatype: "json",
        success: function (result) {
            if (result == false) {

                $SignInButton.show();
                $RegistrationButton.show();
                $LogOffButton.hide();
                $('.order-button').hide();
            }
            if (result == true) {
                $SignInButton.hide();
                $RegistrationButton.hide();
                $LogOffButton.show();
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
        success: function (result) {
            alert(result); //пока что просто алерт с результатом частичного представления
        }
        
    })
})


//on start
$(document).ready(function () {
    IsLogin();
})


//overlay
    var $container = $('#over-lay');
    $container.hide();

    SignInButton.onclick = function () {

        $container.fadeIn(200);
    }

    $container.click(function (event) {
        $container.fadeOut(200);
    })



    $('#SignInForm').click(function (event) {    
        event.stopPropagation();
    })







