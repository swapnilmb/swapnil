$(document).ready(function () {

    if (window.location == "http://10.1.81.37:8010/Empss/Startpage#/Auth/Login?check=1") {


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

    if (window.location == "http://10.1.81.37:8010/Empss/Startpage#/Auth/Newpassword")
    {
   
        $.ajax({
            url: "/Auth/Newpassword",

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