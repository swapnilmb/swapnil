EmployeeDepartment.factory('GetAllDepartment', function ($resource) {
    return {
        getAllDepartment: function () {
            return $resource('api/DepartmentApi').query();
        },
        createDepartment: function (department) {
            return $resource('api/DepartmentApi').save(department);
        }
    };
});