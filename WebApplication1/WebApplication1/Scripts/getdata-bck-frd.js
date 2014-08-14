$(function () {
    $(document).on('click', '.clicklink', function (e) {
        e.preventDefault();

        var url = $(this).attr('href');
        window.location.hash = url;
        $("#Progress").show();

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

    updateMyApp(getLocationhash());
});