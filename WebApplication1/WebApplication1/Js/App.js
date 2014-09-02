

var EmployeeDepartment = angular.module('EmployeeDepartment', ['ngRoute','ngResource']).config(function ($routeProvider) {
    $routeProvider.when('/Department', {
        templateUrl: 'Template/Employee.html',
        controller: 'EmployeeDepartmentController'
    })
});