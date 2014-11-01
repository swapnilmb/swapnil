// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file
/// <reference path="app1.ts" />
/// <reference path="scripts/typings/angularjs/angular.d.ts" />
/// <reference path="scripts/typings/angularjs/angular-resource.d.ts" />

var MainCtrl = (function () {
    function MainCtrl($scope, $http, $resource, $log) {
        var _this = this;
        this.$scope = $scope;
        this.$http = $http;
        this.$resource = $resource;
        this.$log = $log;
        $scope.greeting = "Hello";

        $scope.callLog = function () {
            _this.callLog();
        };
    }
    MainCtrl.prototype.callLog = function () {
        this.$log.debug('Log is Called From Button for debug');
        this.$log.info('Log is Called From Button for info');
        this.$log.warn('Log is Called From Button for warning');
        this.$log.error('Log is Called From Button for Error');
    };
    MainCtrl.controllerId = "MainCtrl";
    return MainCtrl;
})();

// Update the app1 variable name to be that of your module variable
app1.controller(MainCtrl.controllerId, [
    '$scope', '$http', '$resource', '$log', function ($scope, $http, $resource, $log) {
        return new MainCtrl($scope, $http, $resource, $log);
    }
]);
