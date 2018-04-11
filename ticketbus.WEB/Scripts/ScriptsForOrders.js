

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