$(document).ready(function () {

    if (window.location == "http://10.1.81.37:8040/Employee/Startpage#/Auth/Login?check=1") {


        $("#Progress").show();
        $.ajax({
            url: "/Auth/LogIn",

            success: function (data) {

                $("#render").html(data).fadeIn(500);


                $("#Progress").hide();
                $("#Wrg").show();
               
            },
            error: function (data) {

            }
        });
    }

    if (window.location == "http://10.1.81.37:8040/Employee/Startpage#/Auth/Newpassword")
    {
   
        $.ajax({
            url: "/Auth/Newpassword",

            success: function (data) {

                $("#render").html(data).fadeIn(500);


                $("#Progress").hide();

                $("#Wrg").show();
            },
            error: function (data) {

            }
        });
    }


});