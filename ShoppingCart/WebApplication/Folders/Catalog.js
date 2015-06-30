$(document).ready(function () {
    $('#colCategory').fadeTo('fast', 0.75);
    $('#linkCatalog').addClass('btn-default');

    if ($('#PageContent_lblState').hasClass('modified')) {
        $('#modalHeader').text("The product has been added to 'MyCart'");
        $('#modalMessage').text("Click 'MyCart' to view the status of the cart");
        $('#myModal').modal('show');
    }

    if ($('#PageContent_lblState').hasClass('inputError')) {
        $('#modalHeader').text("Error while trying to load the product");
        $('#modalMessage').text("Please add the product again");
        $('#myModal').modal('show');
    }

    if ($('#PageContent_lblState').hasClass('dbConnectionError')) {
        $('#modalHeader').text("Database connect error");
        $('#modalMessage').text("Please, wait a moment and try again");
        $('#myModal').modal('show');
    }

    $('#colCategory').mouseenter(function () {
        $(this).fadeTo('fast', 1);
    });
    $('#colCategory').mouseleave(function () {
        $(this).fadeTo('fast', 0.75);
    });

    $('#colProducts').mouseenter(function () {
        $(this).fadeTo('fast', 1);
    });
    $('#colProducts').mouseleave(function () {
        $(this).fadeTo('fast', 0.75);
    });

    $('#colDetails').mouseenter(function () {
        $(this).fadeTo('fast', 1);
    });
    $('#colDetails').mouseleave(function () {
        $(this).fadeTo('fast', 0.75);
    });

    $('.product').click(function () {
        $('.product').removeClass('info');
        $(this).addClass('info');
    });

    $('.category').click(function () {
        $('#colProducts').removeClass('hidden');
        $('#colProducts').fadeTo('fast', 0.75);
        $('#colDetails').slideUp('fast');
        $('.category').removeClass('info');
        $(this).addClass('info');
        var select = $(this).text().replace(" ", "_").replace("/", "_").trim();
        $('#tabProducts').hide();
        $('.' + select).show();
        $('.product').not($('.' + select)).hide();
        $('#tabProducts').slideDown(400);
    });

    $('.product').click(function () {
        $('#colDetails').hide();
        $('#colDetails').removeClass('hidden');
        $('#colDetails').slideDown(400);
        $('#lblSelectedProductID').text($(this).find(':nth-child(1)').text());
        $('#lblSelectedProductName').text($(this).find(':nth-child(2)').text());
        $('#lblSelectedProductPrice').text($(this).find(':nth-child(3)').text());
        $('#lblSelectedProductStock').text($(this).find(':nth-child(4)').text());
        $('#lblSelectedProductSupplier').text($(this).find(':nth-child(5)').text());
        $('#lblSelectedProductQuantity').text($(this).find(':nth-child(6)').text());
        $('#PageContent_btnAddProduct').hide();
    })

    $('#PageContent_tbxQuantity').keyup(function () {
        this.value = this.value.replace(/[^0-9\.]/g, '');
        if (parseInt($(this).val()) > parseInt($('#lblSelectedProductStock').text())) {
            $('#PageContent_btnAddProduct').hide('fast');
            $('#lblErrorMessage').removeClass('hidden');
        }
        else {
            if (!$(this).val() == "") {
                $('#PageContent_btnAddProduct').show('slow');
                $('#PageContent_tbxProduct').val($('#lblSelectedProductID').text());
                $('#lblErrorMessage').addClass('hidden');
            }
            else {
                $('#PageContent_btnAddProduct').hide('fast');
            }
        }
    });

    $('#PageContent_btnAddProduct').click(function () {
        $('.column').fadeTo('fast', 0.5);
    })
});