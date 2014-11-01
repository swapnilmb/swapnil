/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />


declare function svgPanZoom(element: any, property: any): any;
interface IPanZoom extends ng.IDirective {

}

interface IPanZoomScope extends ng.IScope {

}

class PanZoom implements IPanZoom {
    static directiveId: string = "panZoom";
    restrict: string = "A";

    constructor(private $window: ng.IWindowService) {
    }

    controller = ($scope, $element, $attrs, $rootScope) => {

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
       
        var chkZoomEnabled = panZoom.isZoomEnabled(); //tentative will change as per document mode,just checking condition here for future use 
        if (chkZoomEnabled) {
            //Here the zoomIn is enabled and panBtnVisible will be visible
            $scope.zoomIn = () => {
                panZoom.zoomIn();
                $scope.panBtnVisible = true;
            }
            //Here the zoomOut is enabled and panBtnVisible will be visible
            $scope.zoomOut = () => {
                panZoom.zoomOut();
                $scope.panBtnVisible = true;
            }
            //Here the panning is enabled 
            $scope.panEnable = () => {
                panZoom.enablePan();

            }
        }
        //Here on mousewheel event panBtnVisible will be visible
        var mousewheelevt = (/Firefox/i.test(navigator.userAgent)) ? "DOMMouseScroll" : "mousewheel"//FF doesn't recognize mousewheel as of FF3.x
        if (document.addEventListener)
            document.addEventListener(mousewheelevt, function (e) {
                $scope.panBtnVisible = true;
                $scope.$apply(); }, false)
  
    }
}


angular.module('Application', ['ngResource', 'ngRoute']).directive(PanZoom.directiveId, ['$window', $window =>
    new PanZoom($window)
])
