
/// <reference path="../scripts/typings/angularjs/angular.d.ts" />

//Defination file for svgPanZoom Function.
/// <reference path="../svgpanzoom.d.ts" />



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
        var Panning = ($attrs.panEnabled == "false") ? false : true;
        var Zooming = ($attrs.zoomEnabled == "false") ? false : true;

//We can set property to the svgPanZoom
        var panZoom = svgPanZoom($element[0], {
            zoomEnabled: Zooming,
            panEnabled: Panning,
            minZoom: 0,
            maxZoom: 10,
            zoomScaleSensitivity: 0.075

        });
       
    }
}


angular.module('Application', ['ngResource','ngRoute']).directive(PanZoom.directiveId, ['$window', $window =>
    new PanZoom($window)
]);
