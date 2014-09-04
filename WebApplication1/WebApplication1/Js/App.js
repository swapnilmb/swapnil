

var EmployeeDepartment = angular.module('EmployeeDepartment', ['ngRoute','ngResource']).config(function ($routeProvider) {
    $routeProvider.when('/Department', {
        templateUrl: 'Template/Department.html',
        controller: 'EmployeeDepartmentController'
    }).when('/CreateDepartment', {
        templateUrl: 'Template/CreateDepartment.html',
        controller: 'EmployeeDepartmentController'
    })
});