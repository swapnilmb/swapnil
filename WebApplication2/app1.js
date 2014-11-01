/// <reference path="scripts/typings/angularjs/angular.d.ts" />
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the reference paths,
// then adjust the path value to be relative to this file
/// <reference path="scripts/typings/angularjs/angular-resource.d.ts" />

// Create the module and define its dependencies.
var app1 = angular.module('app1', [
    'ngResource',
    'ngAnimate',
    'ngRoute'
]);

// Execute bootstrapping code and any dependencies.
app1.run([
    '$q', '$rootScope', function ($q, $rootScope) {
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
    '$provide', function ($provide) {
        $provide.decorator('$log', [
            '$delegate', function ($delegate) {
                //var prepareLogFunction = toastrDisplayMethod=> { throw new Error("Not implemented"; };
                $delegate.debug = prepareLogFunction($delegate.debug);
                $delegate.info = prepareLogFunction($delegate.info);
                $delegate.warn = prepareLogFunction($delegate.warn);
                $delegate.error = prepareLogFunction($delegate.error);

                function prepareLogFunction(logFunction) {
                    var enhancedLogFunction = function (text) {
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
