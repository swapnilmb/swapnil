

var EmployeeDepartment = angular.module('EmployeeDepartment', ['ngRoute','ngResource']).config(function ($routeProvider) {
    $routeProvider.when('/Department', {
        templateUrl: 'Template/Department.html',
        controller: 'EmployeeDepartmentController'
    }).when('/CreateDepartment', {
        templateUrl: 'Template/CreateDepartment.html',
        controller: 'EmployeeDepartmentController'
    }).when('/UpdateDepartment/:id', {
        controller: 'EmployeeDepartmentController',
        templateUrl: 'Template/UpdateDepartment.html'
        
    }).when('/Employee/', {
        controller: 'EmployeeDepartmentController',
        templateUrl: 'Template/Employee.html'

    })
});

///UpdateDepartment/:param