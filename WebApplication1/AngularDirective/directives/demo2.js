Application.directive('mydemo', function () {
    return {

        link: function (scope, element, attrs) {
          
            //scope:{}
            var c = new svg_edit_setup();
            //element.on('load', function () {


            //    svg_edit_setup();

            //});
            element.on('click', function () {
                if (attrs.id == "tool_select") {
                    c.clickSelect();
                  }
               
                if (attrs.id == "tool_rect") {

                    c.clickRect();


                }
            });
            


        }
    }
});
   


//Application.directive('my', function () {
//    return {

//        link: function (scope, element, attrs) {
          
//            var svgCanvass = new SvgCanvas(document.getElementById("svgcanvas"));
//            //element.on('load', function () {


//            //    svg_edit_setup();

//            //});
           
//            element.on('mousedown', function (evt) {
//                evt.preventDefault();
//                svgCanvass.mouseDown(evt);
//            });
//            element.on('mousemove', function (evt) {
//                evt.preventDefault();
//                svgCanvass.mouseMove(evt);
//            });
//            element.on('mouseup', function (evt) {
//                evt.preventDefault();
//                svgCanvass.mouseUp(evt);
//            });



//        }
//    }
//});

Application.directive('mydraw', function () {
    return {


        link: function (scope, element, attrs) {

           var svgCanvas = new SvgCanvas(document.getElementById("svgcanvas"));
            //element.on('load', function () {


            //    svg_edit_setup();

            //});

            element.on('mousedown', function (evt) {
                //evt.preventDefault();
                svgCanvas.mouseDown(evt);
            });
            element.on('mousemove', function (evt) {
                evt.preventDefault();
                svgCanvas.mouseMove(evt);
            });
            element.on('mouseup', function (evt) {
                evt.preventDefault();
                svgCanvas.mouseUp(evt);
            });



        }
    }
});
