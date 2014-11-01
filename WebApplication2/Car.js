// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file
/// <reference path="app1.ts" />
/// <reference path="scripts/typings/angularjs/angular.d.ts" />
/// <reference path="scripts/typings/angularjs/angular-resource.d.ts" />

var Car = (function () {
    function Car($http, $resource) {
        this.$http = $http;
        this.$resource = $resource;
        this.greeting = "Hello";
    }
    Car.prototype.mycar = function () {
        //car : "Name";
        return "mycar";
    };
    Car.serviceId = "Car";
    return Car;
})();

// Update the app1 variable name to be that of your module variable
app1.factory(Car.serviceId, [
    '$http', '$resource', function ($http, $resource) {
        return new Car($http, $resource);
    }
]);
