/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../controllers/employeedepartment.ts" />
/// <reference path="../application.ts" />

var Departments = (function () {
    function Departments($http, $resource) {
        this.$http = $http;
        this.$resource = $resource;
        this.resourceSaveDept = $resource('/api/DepartmentApi/CreateDepartment');
        this.resourceGetAll = $resource('/api/DepartmentApi/AllDepartment');
        this.resourceDelete = $resource('/api/DepartmentApi/DeleteDepartment', { Id: '@Id' });
    }
    Departments.prototype.saveDept = function (dept) {
        return this.resourceSaveDept.save(dept).$promise;
    };
    Departments.prototype.getAll = function () {
        return this.resourceGetAll.query().$promise;
    };
    Departments.prototype.deleteDept = function (Id) {
        return this.resourceDelete.get({ Id: Id }).$promise;
    };
    Departments.serviceId = "Departments";
    return Departments;
})();

// Update the app1 variable name to be that of your module variable
Application.factory(Departments.serviceId, [
    '$http', '$resource', function ($http, $resource) {
        return new Departments($http, $resource);
    }
]);
//# sourceMappingURL=Departments.js.map
