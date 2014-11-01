
/// <reference path="scripts/typings/angularjs/angular.d.ts" />
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the reference paths,
// then adjust the path value to be relative to this file
/// <reference path="scripts/typings/angularjs/angular-resource.d.ts" />


interface Iapp1 extends ng.IModule { }

// Create the module and define its dependencies.
var app1: Iapp1 = angular.module('app1', [
    // Angular modules 
    'ngResource',       // $resource for REST queries
    'ngAnimate',        // animations
    'ngRoute'           // routing

    // Custom modules 

    // 3rd Party Modules
]);

// Execute bootstrapping code and any dependencies.
app1.run(['$q', '$rootScope', ($q, $rootScope) => {

}]);

//app1.config(($provide)=> {
//    $provide.decorator('$log', ($delegate)=> {
//        var debugfn = $delegate.debug;
//        $delegate.debug = function() {
//            alert("hi");
//        };
       
//        Object.defineProperty($delegate.prototype, 'favorite', {
//            get: function () { return favCar(Car); }
//        });

//        function favCar(Car) {
//            return {
//                Name: 'Porsche'
//            }[Car];
//        }

//        return $delegate;

//    });
//});
app1.config([
    '$provide', ($provide) => {
        $provide.decorator('$log', [
            '$delegate', ($delegate) => {
                //var prepareLogFunction = toastrDisplayMethod=> { throw new Error("Not implemented"; };
                $delegate.debug = prepareLogFunction($delegate.debug);
                $delegate.info = prepareLogFunction($delegate.info);
                $delegate.warn = prepareLogFunction($delegate.warn);
                $delegate.error = prepareLogFunction($delegate.error);

                function prepareLogFunction(logFunction) {
                    var enhancedLogFunction = (text) => {
                        var dateTime = new Date(Date.now());
                        var appendStringToDebug = [dateTime + text];
                        logFunction.apply(null, appendStringToDebug);
                    };
                    return enhancedLogFunction;
                }
                return $delegate;
            }]);
    }
]);