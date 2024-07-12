$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').val();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }

        /* alert(id + " " + quantity);*/
        $.ajax({
            url: '/ShoppingCart/AddToCart',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    $('#CartCount').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });
    });


    $('body').on('change', 'input[type=number]', function () {
        var id = $(this).attr("id").replace("Quantity_", "");
        var quantity = $(this).val();
        Update(id, quantity);
    });
    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);

    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm('Bạn có chắc chắn muốn xóa hết sản phẩm trong giỏ hàng?')
        if (conf == true) {
            DeleteAll();
        }
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng?')
        if (conf == true) {
            $.ajax({
                url: '/ShoppingCart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#CartCount').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }

    });

});

function ShowCount() {
    $.ajax({
        url: '/ShoppingCart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $('#CartCount').html(rs.Count);
        }
    });
}

function Update(id, quantity) {
    $.ajax({
        url: '/ShoppingCart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/ShoppingCart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}
function LoadCart() {
    $.ajax({
        url: '/ShoppingCart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}

