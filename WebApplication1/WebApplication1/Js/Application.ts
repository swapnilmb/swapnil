/// <reference path="../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the reference paths,
// then adjust the path value to be relative to this file

interface IApplication extends ng.IModule { }

// Create the module and define its dependencies.
var Application: IApplication = angular.module('Application', [
// Angular modules 
    'ngResource',       // $resource for REST queries
// animations
    'ngRoute'           // routing

    // Custom modules 

    // 3rd Party Modules
]);

// Execute bootstrapping code and any dependencies.
Application.run(['$q', '$rootScope', ($q, $rootScope) => {

}]);

Application.config(function ($routeProvider) {
    $routeProvider.when('/Department', {
        templateUrl: '/Template/Department.html',
        controller: 'EmployeeDepartment'
    });
    $routeProvider.when('/CreateDepartment', {
        templateUrl: '/Template/CreateDepartment.html',
        controller: 'EmployeeDepartment'
    });
    $routeProvider.when('/UpdateDepartment/:id', {
        controller: 'EmployeeDepartment',
        templateUrl: '/Template/UpdateDepartment.html'

    });
    $routeProvider.when('/Employee', {
        controller: 'EmployeeDepartment',
        templateUrl: '/Template/Employee.html'

    });
});