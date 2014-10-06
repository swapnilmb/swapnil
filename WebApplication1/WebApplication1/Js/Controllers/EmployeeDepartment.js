/// <reference path="../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../services/departments.ts" />
/// <reference path="../application.ts" />

var EmployeeDepartment = (function () {
    function EmployeeDepartment($scope, $http, $resource, Departments) {
        var _this = this;
        this.$scope = $scope;
        this.$http = $http;
        this.$resource = $resource;
        this.Departments = Departments;
        $scope.save = function (dept) {
            return _this.save(dept);
        };
        $scope.getAllDept = function () {
            return _this.getAllDept();
        };
        $scope.deleteDept = function (id) {
            return _this.deleteDept(id);
        };
    }
    EmployeeDepartment.prototype.save = function (dept) {
        var _this = this;
        this.Departments.saveDept(dept).then(function (result) {
            _this.$scope.departmentsss = result;
        });
    };

    EmployeeDepartment.prototype.getAllDept = function () {
        var _this = this;
        this.Departments.getAll().then(function (result) {
            //for (var i = 0; i < result.length; i++) {
            _this.$scope.departmentsss = result;
            // }
        });
    };

    EmployeeDepartment.prototype.deleteDept = function (id) {
        var _this = this;
        this.Departments.deleteDept(id).then(function () {
            _this.$scope.getAllDept();
        });
    };
    EmployeeDepartment.controllerId = "EmployeeDepartment";
    return EmployeeDepartment;
})();

// Update the app1 variable name to be that of your module variable
Application.controller(EmployeeDepartment.controllerId, [
    '$scope', '$http', '$resource', 'Departments', function ($scope, $http, $resource, Departments) {
        return new EmployeeDepartment($scope, $http, $resource, Departments);
    }
]);
//# sourceMappingURL=EmployeeDepartment.js.map
