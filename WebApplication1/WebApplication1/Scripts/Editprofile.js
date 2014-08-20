$(function () {
    $("#editprf").submit(function (e) {
        e.preventDefault();
        debugger;
        $("#Progress").show();
        var url = $(this).attr('action');
        $.ajax({
            url: url,
            data: $("#editprf").serialize(),
            type: "POST",
            success: function (data) {

                $('#edit').hide().html(data).fadeIn(500);
                $("#Progress").hide();
            }


        });

    });

});