EmployeeDepartment.controller('EmployeeDepartmentController',
    function EmployeeDepartmentcontoller($scope, GetAllDepartment, $routeParams, $location) {

        $scope.param = $routeParams.param;
        // GetAllDepartment.getAllDepartment().$promise.then(function (data) { $scope.data = data; });

        $scope.getAllDepartment = function () { GetAllDepartment.getAllDepartment().$promise.then(function (data) { $scope.data = data; }); }
        $scope.createdepartment = function (department, createdept) {
            if (createdept.$valid) {

                GetAllDepartment.createDepartment(department).$promise.then(function (data) { $scope.message = data; });

            }
        }
        $scope.getdepartment = function (id) {
          
            //GetAllDepartment.getDepartment(id).$promise.then(function (data) {
            //    $scope.updatedept = data;
            $location.path('/UpdateDepartment/'+id);
            //});
            
        }

        $scope.get = function () {
            GetAllDepartment.getDepartment($routeParams.id).$promise.then(function (data) {
                $scope.updatedept = data;
              
            });
        }

        $scope.updatedepartment = function (updatedept) {
            GetAllDepartment.updateDepartment(updatedept).$promise.then(function (data) {
                $scope.updated = data;
            });
            
        }
        $scope.deletedepartment = function (id) {
            GetAllDepartment.deleteDepartment(id).$promise.then(function (data) {
                $scope.delete = data
                $scope.getAllDepartment();

            });
        }
        $scope.getAllEmployee = function () { GetAllDepartment.getAllEmployee().$promise.then(function (data) { $scope.All = data; }); }
    }
    );