$(document).ready(function () {

    if (window.location == "http://localhost:1938/Empss/Startpage#/Auth/Login?check=1") {


        $("#Progress").show();
        $.ajax({
            url: "/Auth/LogIn",

            success: function (data) {

                $("#sd").html(data).fadeIn(500);


                $("#Progress").hide();

                $("#Wrg").show();
            },
            error: function (data) {

            }
        });
    }


});