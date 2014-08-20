$(function () {
    $("#new").submit(function (e) {
        e.preventDefault();

        var url = $(this).attr('action');
        //window.location.hash = url;

        $.ajax({
            url: url,
            data: $("#new").serialize(),
            type: "POST",
            success: function (data) {

                $('#sd').hide().html(data).fadeIn(500);
                $("#Progress").hide();
                $("#upd").hide();
                $("#del").hide();
                $("#cre").hide();
                $("#signin").show();
                $("#crt").hide();
                $("#old").hide();
            }
        });


    });
});