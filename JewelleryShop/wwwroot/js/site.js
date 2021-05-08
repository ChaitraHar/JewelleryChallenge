//Prints to text file
function PrintToFile() {
    $.ajax({
        url: '/Home/PrintToFile',
        type: "get",
        cache: false,
        data: { totalPrice: $('#TotalPrice').val(), discountedPrice: $('.discount-price').val(), isPrivilaged: $('#hdnPrivilaged').val().toString()},
        success: function (result) {
            window.location.href = '/Home/DownloadFile';
        },
        error: function () {
            ErrorMessagePopUp('Error occurred while Calculating', 'Error')
        }
    });
}

//Login
function Login() {
    $.ajax({
        url: '/Home/Authenticate',
        type: "POST",
        cache: false,
        dataType:"json",
        data: { enteredUserName: $('.username').val(), enteredPassword: $('.password').val() },
        success: function (result) {
            window.location.href = '/Home/Index/' + result.isPriv;
        }
    });
}

//Modal View 
$(function() {
    var placeHolderElem = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var tot = $('#TotalPrice').val().toString();
        var priv = $('#hdnPrivilaged').val();
        var dis = 0;
        if (priv.toLowerCase() == 'true') {
            dis = $('.discount-price').val().toString();
        }      

        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url) + "/" + tot + "/" + dis + "/" + priv; 
        $.get(decodedUrl).done(function (data) {
            placeHolderElem.html(data);
            placeHolderElem.find('.modal').modal('show');
        })
    })
    placeHolderElem.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            placeHolderElem.find('modal').modal('hide');
        })
    })
})

// Populates calculated data when price or weight values change
function CalcEstimate(element) {
    var total = parseFloat($('#GoldPrice').val()) * parseFloat($("#GoldWeight").val());
    if (!isNaN(total)) {
        $('#TotalPrice').val(total);
        var discounted = total - (total * 0.02);
        $('.discount-price').val(discounted);
    }
    else {
        $('#TotalPrice').val(0);
        $('.discount-price').val(0);
    }
}
