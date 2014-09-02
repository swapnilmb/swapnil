EmployeeDepartment.factory('GetAllDepartment', function ($resource) {
    return {
        getAllDepartment: function () {
            return $resource('/Employee/IndexDept').query();
        }
    };
});