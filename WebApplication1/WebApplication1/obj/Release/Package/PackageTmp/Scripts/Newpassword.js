$(function () {
    $("#newpassword").submit(function (e) {
        e.preventDefault();

        var url = $(this).attr('action');
        //window.location.hash = url;

        $.ajax({
            url: url,
            data: $("#newpassword").serialize(),
            type: "POST",
            success: function (data) {

                $('#render').hide().html(data).fadeIn(500);
                $("#Progress").hide();
                $("#updatemessage").hide();
                $("#deletemessage").hide();
                $("#createmessage").hide();
                
                $("#crt").hide();
                $("#oldpassword").hide();
            }
        });


    });
});