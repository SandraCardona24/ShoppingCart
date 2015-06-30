$(document).ready(function () {
    $('#linkCart').addClass('btn-default');

    $('.lineaVenta').click(function () {
        $('.lineaVenta').removeClass('info');
        $(this).addClass('info');
        $('#PageContent_tbxLineaVenta').val($(this).attr('id'));
    });

    if ($('#PageContent_lblState').hasClass('dbConnectionError')) {
        $('#modalHeader').text("Database connect error");
        $('#modalMessage').text("Please, wait a moment and try again");
        $('#myModal').modal('show');
    }

    if ($('#PageContent_lblState').hasClass('deleteError')) {
        $('#modalHeader').text("Failed to delete product");
        $('#modalMessage').text("Select the product you want to delete and try again");
        $('#myModal').modal('show');
    }

    if ($('#PageContent_lblState').hasClass('invalidAction')) {
        $('#modalHeader').text("No products in the cart");
        $('#modalMessage').text("Select the products you want to add");
        $('#myModal').modal('show');
    }

    if ($('#PageContent_lblState').hasClass('purchaseCompleted')) {
        $('#modalHeader').text("Failed to delete product");
        $('#modalMessage').text("The purchase made successfully");
        $('#myModal').modal('show');
    }


});