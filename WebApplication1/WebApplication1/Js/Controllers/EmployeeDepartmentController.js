EmployeeDepartment.controller('EmployeeDepartmentController',
    function EmployeeDepartmentcontoller($scope, GetAllDepartment) {


        // GetAllDepartment.getAllDepartment().$promise.then(function (data) { $scope.data = data; });

        $scope.getAllDepartment = function () { GetAllDepartment.getAllDepartment().$promise.then(function (data) { $scope.data = data; }); }
        $scope.createdepartment = function (department, createdept) {
            if (createdept.$valid) {

                GetAllDepartment.createDepartment(department).$promise.then(function (data) { $scope.message = data });

            }
        }
    }
    );