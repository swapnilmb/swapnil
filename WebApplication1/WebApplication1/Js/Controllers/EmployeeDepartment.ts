


/// <reference path="../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../services/departments.ts" />
/// <reference path="../application.ts" />

// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file


interface IEmployeeDepartmentScope extends ng.IScope {
    departmentsss: any;
    save: (dept) => void;
    getAllDept: () => void;
    deleteDept: (id) => void;
}

interface IEmployeeDepartment {

}

class EmployeeDepartment implements IEmployeeDepartment {
    static controllerId: string = "EmployeeDepartment";

    constructor(private $scope: IEmployeeDepartmentScope, private $http: ng.IHttpService, private $resource: ng.resource.IResourceService, private Departments: Departments) {
        $scope.save = (dept) => this.save(dept);
        $scope.getAllDept = () => this.getAllDept();
        $scope.deleteDept = (id) => this.deleteDept(id);
    }

    private save(dept) {

        this.Departments.saveDept(dept).then((result) => {
            this.$scope.departmentsss = result;
        });
    }

    private getAllDept() {
        this.Departments.getAll().then((result) => {
            //for (var i = 0; i < result.length; i++) {
            this.$scope.departmentsss = result;
            // }
        });
    }

    private deleteDept(id) {
        this.Departments.deleteDept(id).then(() => {

            this.$scope.getAllDept();
        });
    }
}

// Update the app1 variable name to be that of your module variable
Application.controller(EmployeeDepartment.controllerId, ['$scope', '$http', '$resource', 'Departments', ($scope, $http, $resource, Departments) =>
    new EmployeeDepartment($scope, $http, $resource, Departments)
]);
