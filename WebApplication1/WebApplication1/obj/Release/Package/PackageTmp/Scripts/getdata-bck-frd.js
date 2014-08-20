$(function () {
    $(document).on('click', '.clicklink', function (e) {
        e.preventDefault();

        var url = $(this).attr('href');
        if (url != null)
        {
            window.location.hash = url;
        }
        else
        {
            var url1 = $(this).attr('action');
            window.location.hash = url1;
        }
       
    
       
        //var value = window.location.hash.substring(1);
        //updateMyApp(value);

    });
});



function getLocationhash() {

    return window.location.hash.substring(1);
}
function updateMyApp(value) {

    $.ajax({
        url: value,

        success: function (data) {

            $('#sd').hide().html(data).fadeIn(500);
            $("#Progress").hide();
            $("#upd").hide();
            $("#del").hide();
            $("#cre").hide();
            $("#signin").show();
            $("#crt").hide();
        }
    });

}
$(window).on("hashchange", function () {
    $("#Progress").show();
    updateMyApp(getLocationhash());
});