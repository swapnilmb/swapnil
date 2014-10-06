
angular.module('Application').directive('pan', function () {
    return {

        controller: function ($scope, $element, $attrs, $rootScope) {
           
            var Panning = ($attrs.panEnabled == "false") ? false : true;
            var Zooming = ($attrs.zoomEnabled == "false") ? false : true;
         
            var panZoom = svgPanZoom($element[0], {
                zoomEnabled: Zooming,
                panEnabled:Panning,
                minZoom: 0,
                maxZoom: 10,
                zoomScaleSensitivity: 0.075

            });

           
            //  var count = 1;
            //  panZoom.zoomBy(7.5 + count++);
            //     panZoom.zoom(7.5);

            //panZoom.setZoomScaleSensitivity(7.5);
            //$scope.zoomIn = function () {

            //    panZoom.zoomIn();
            //    $scope.currZoom = panZoom.getZoom();
            //}

            //$scope.zoomOut = function () {

            //    panZoom.zoomOut();
            //    $scope.currZoom = panZoom.getZoom();
            //}


          
        }



    }
});


//app.controller('zoomFn', function ($scope, $element, $attrs, $rootScope) {
//    var elem = $element.attr('id');
//    var svgElement = document.querySelector("#"+elem);
//    var panZoom = svgPanZoom(svgElement, {
//        zoomEnabled: true,
//        panEnabled: false
//    });

//    $scope.abc = function () {

//        panZoom.zoomOut();
//    }
//})