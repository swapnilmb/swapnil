

//$(document).on("click",".af", function (e) {
//    e.preventDefault();
//    debugger;
//        //var ct = $(this).attr('href');
//        window.history.pushState({ page: this.href }, '', this.href);
//        ldPage(this.href);
//        // var url = $(this).attr('href');
//        // href = this.href;//$(this).attr('href');
//        //window.location.hash = url;

//});

//$(document).on("click", "#sa", function (e) {
//    //   e.preventDefault();        
//    //var ct = $(this).attr('href');
//    //window.history.pushState({ page: this.href }, '', this.href);
//    //ldPage(this.href);
//    // var url = $(this).attr('href');
//    // href = this.href;//$(this).attr('href');
//    //window.location.hash = url;
//    $.ajax({

//        url: "Empss/IndexDept",

//        success: function (data) {

//            $('#sd').hide().html(data).fadeIn(500);
//            $("#Progress").hide();
//            $("#upd").hide();
//            $("#del").hide();
//            $("#cre").hide();
//            $("#signin").show();
//            $("#crt").hide();
//        }
//    });

//});
//    function ldPage(p) {

//        $("#Progress").show();
//        var cr =p.substring(21);
//        debugger;
//        $.ajax({

//            url: cr,

//            success: function (data) {

//                $('#sd').hide().html(data).fadeIn(500);
//                $("#Progress").hide();
//                $("#upd").hide();
//                $("#del").hide();
//                $("#cre").hide();
//                $("#signin").show();
//                $("#crt").hide();
//            }
//        });

//    }
//    $(window).on('popstate', function (e) {
       
//        ldPage(location.href);
//        //console.log(e.originalEvent.state);
//    });
    
