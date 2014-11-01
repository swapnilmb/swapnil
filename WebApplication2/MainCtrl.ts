// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file
/// <reference path="app1.ts" />
/// <reference path="scripts/typings/angularjs/angular.d.ts" />
/// <reference path="scripts/typings/angularjs/angular-resource.d.ts" />

interface IMainCtrlScope extends ng.IScope {
    greeting: string;
    callLog: () => void;
    mycar;
}

interface IMainCtrl {
    
}

class MainCtrl implements IMainCtrl {
    static controllerId: string = "MainCtrl";
    
    constructor(private $scope: IMainCtrlScope, private $http: ng.IHttpService, private $resource: ng.resource.IResourceService,private $log:ng.ILogService) {
        $scope.greeting = "Hello";
       
        $scope.callLog = () => { this.callLog(); };
    }

    private callLog() {
        this.$log.debug('Log is Called From Button for debug');
        this.$log.info('Log is Called From Button for info');
        this.$log.warn('Log is Called From Button for warning');
        this.$log.error('Log is Called From Button for Error');
    }
}

// Update the app1 variable name to be that of your module variable
app1.controller(MainCtrl.controllerId, ['$scope', '$http', '$resource','$log', ($scope, $http, $resource,$log) =>
    new MainCtrl($scope, $http, $resource,$log)
]);
