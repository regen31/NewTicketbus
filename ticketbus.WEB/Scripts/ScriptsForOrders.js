

//order-button click
$('body').on('click', '.order-button', function () {
    var IdFromAtr = $(this).attr('routeId');
    var datefromAtr = $(this).attr('searchDate');

    $.ajax({
        url: "/Order/GetScheme",
        type: "POST",
        data: { RouteId: IdFromAtr, date: datefromAtr },
        datatype: 'html',
        beforeSend: function () {
            $whiteoverlay.show();
        },
        success: function (result) {
            $whiteoverlay.hide();
            alert(result);
            $('body').append("<div class='grey-overlay' id='SchemeContainer'></div>");
            $('#SchemeContainer').append(result);
        }

    })
})