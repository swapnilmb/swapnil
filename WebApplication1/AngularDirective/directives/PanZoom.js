/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../svgpanzoom.d.ts" />

var PanZoom = (function () {
    function PanZoom($window) {
        this.$window = $window;
        this.restrict = "A";
        this.controller = function ($scope, $element, $attrs, $rootScope) {
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
