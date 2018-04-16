var IdFromAtr = null;
var datefromAtr = null;
var ChosenSeats = [];


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


//order-button click
$('body').on('click', '.order-button', function () {
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
        }
    })
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
       
    }    
});

//overlays
$('body').on('click', '#SchemeContainer', function (event) {
    ChosenSeats = [];
    $('#SchemeContainer').remove();
})
$('body').on('click', '#scheme-window', function (event) {
    event.stopPropagation();
})