EmployeeDepartment.factory('GetAllDepartment', function ($resource) {
    return {
        getAllDepartment: function () {
            return $resource('api/DepartmentApi/AllDepartment').query();
        },
        createDepartment: function (department) {
            return $resource('api/DepartmentApi/CreateDepartment').save(department);
        },
        getDepartment:function (id)
        {
            return $resource('api/DepartmentApi/GetDepartmentbyid/:id', { id: '@id' }).get({ id: id });
        },
        updateDepartment: function (departments) {
            return $resource('api/DepartmentApi/UpdateDepartment').save(departments);
        },
        deleteDepartment:function(id)
        {
            return $resource('api/DepartmentApi/DeleteDepartment/:id', { id: '@id' }).get({ id: id });
        },
        getAllEmployee: function () {
            return $resource('api/DepartmentApi/AllEmployee').query();
        }
        
   
    };
});