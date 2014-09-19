EmployeeDepartment.factory('GetAllDepartment', function ($resource) {
    return {
        getAllDepartment: function () {
            return $resource('api/DepartmentApi/AllDepartment').query().$promise;
        },
        createDepartment: function (department) {
            return $resource('api/DepartmentApi/CreateDepartment').save(department).$promise;
        },
        getDepartment:function (id)
        {
            return $resource('api/DepartmentApi/GetDepartmentbyid/:id', { id: '@id' }).get({ id: id }).$promise;
        },
        updateDepartment: function (departments) {
            return $resource('api/DepartmentApi/UpdateDepartment').save(departments).$promise;
        },
        deleteDepartment:function(id)
        {
            return $resource('api/DepartmentApi/DeleteDepartment/:id', { id: '@id' }).get({ id: id }).$promise;
        },
        getAllEmployee: function () {
            return $resource('api/DepartmentApi/AllEmployee').query().$promise;
        }
        
   
    };
});