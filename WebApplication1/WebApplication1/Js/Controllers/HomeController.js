EmployeeDepartment.controller('EmployeeDepartmentController',
    function EmployeeDepartmentcontoller($scope, GetAllDepartment) {


    
            GetAllDepartment.getAllDepartment().$promise.then(function (data) {$scope.data=data; });
        
        
    }
    );