/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />

var PanZoom = (function () {
    function PanZoom($window) {
        this.$window = $window;
        this.restrict = "A";
        this.controller = function ($scope, $element, $attrs, $rootScope) {
            //Here the value of attribute comes in string so we have to convert it into boolean and pass it.
            //if the attibute is not passed then it will take default value.
            var Panning = ($attrs.panEnabled == "true" ? true : false);
            var Zooming = ($attrs.zoomEnabled == "false" ? false : true);

            $scope.panBtnVisible = Panning;

            //We can set property to the svgPanZoom
            var panZoom = svgPanZoom($element[0], {
                zoomEnabled: Zooming,
                panEnabled: false,
                minZoom: 0,
                maxZoom: 10,
                zoomScaleSensitivity: 0.075
            });

            var chkZoomEnabled = panZoom.isZoomEnabled();
            if (chkZoomEnabled) {
                //Here the zoomIn is enabled and panBtnVisible will be visible
                $scope.zoomIn = function () {
                    panZoom.zoomIn();
                    $scope.panBtnVisible = true;
                };

                //Here the zoomOut is enabled and panBtnVisible will be visible
                $scope.zoomOut = function () {
                    panZoom.zoomOut();
                    $scope.panBtnVisible = true;
                };

                //Here the panning is enabled
                $scope.panEnable = function () {
                    panZoom.enablePan();
                };
            }

            //Here on mousewheel event panBtnVisible will be visible
            var mousewheelevt = (/Firefox/i.test(navigator.userAgent)) ? "DOMMouseScroll" : "mousewheel";
            if (document.addEventListener)
                document.addEventListener(mousewheelevt, function (e) {
                    $scope.panBtnVisible = true;
                    $scope.$apply();
                }, false);
        };
    }
    PanZoom.directiveId = "panZoom";
    return PanZoom;
})();

angular.module('Application', ['ngResource', 'ngRoute']).directive(PanZoom.directiveId, [
    '$window', function ($window) {
        return new PanZoom($window);
    }
]);
//# sourceMappingURL=PanZoom.js.map
