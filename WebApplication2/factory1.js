// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file
/// <reference path="app1.ts" />
/// <reference path='/Scripts/typings/angularjs/angular.d.ts'/>
/// <reference path='/Scripts/typings/angularjs/angular-resource.d.ts'/>

var factory1 = (function () {
    function factory1($http, $resource) {
        this.$http = $http;
        this.$resource = $resource;
        this.greeting = "Hello";
    }
    factory1.prototype.changeGreeting = function () {
        this.greeting = "Bye";
    };
    factory1.serviceId = "factory1";
    return factory1;
})();

// Update the app1 variable name to be that of your module variable
app1.factory(factory1.serviceId, [
    '$http', '$resource', function ($http, $resource) {
        return new factory1($http, $resource);
    }
]);
