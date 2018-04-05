
//on start
$(document).ready(function () {
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
            }
            if (result == true) {
                $SignInButton.hide();
                $RegistrationButton.hide();
                $LogOffButton.show();
            }
        }
    })
})



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







