 if (window.location.hash.substring(1) != "") {
        
        var url = window.location.hash.substring(1);
        $("#Progress").show();
        $.ajax({
            url: url,
            type: "GET",
            datatype: "html",
            success: function (data) {
                $("#sd").html(data).fadeIn(500);
                $("#Progress").hide();
            },
            error: function (data) {

            }
        });
    }