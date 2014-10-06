

/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../controllers/employeedepartment.ts" />
/// <reference path="../application.ts" />


// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file


interface IDepartments {
    saveDept: (dept) => ng.IPromise<any>;
    getAll: () => ng.IPromise<any>;
    deleteDept: (Id) => ng.IPromise<any>;
}

class Departments implements IDepartments {
    static serviceId: string = "Departments";
    private resourceSaveDept: ng.resource.IResourceClass<ng.resource.IResource<any>>;
    private resourceGetAll: ng.resource.IResourceClass<ng.resource.IResource<any>>;
    private resourceDelete: ng.resource.IResourceClass<ng.resource.IResource<any>>;

    constructor(private $http: ng.IHttpService, private $resource: ng.resource.IResourceService) {
        this.resourceSaveDept = $resource('/api/DepartmentApi/CreateDepartment');
        this.resourceGetAll = $resource('/api/DepartmentApi/AllDepartment');
        this.resourceDelete = $resource('/api/DepartmentApi/DeleteDepartment', { Id: '@Id' });
    }

    saveDept(dept) {
        return this.resourceSaveDept.save(dept).$promise;
    }
    getAll() {

        return this.resourceGetAll.query().$promise;
    }
    deleteDept(Id) {

        return this.resourceDelete.get({ Id: Id }).$promise;
    }
}

// Update the app1 variable name to be that of your module variable
Application.factory(Departments.serviceId, ['$http', '$resource', ($http, $resource) =>
    new Departments($http, $resource)
]);
