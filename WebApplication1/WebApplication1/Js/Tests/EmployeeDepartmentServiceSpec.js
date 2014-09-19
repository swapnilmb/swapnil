describe('GetallDepartment', function () {
    beforeEach(module('EmployeeDepartment'));
    it('should get department by id', inject(function (GetAllDepartment, $httpBackend) {
        var departments = { deptName: 'hr', id: 1 };
        var mockdepartments = departments;
        $httpBackend.when('GET', 'api/DepartmentApi/GetDepartmentbyid/1').respond(departments);
        abc = GetAllDepartment.getDepartment(departments.id);

    
        abc.then(function (result) {
            expect(result.deptName).toBe(mockdepartments.deptName);
        })
        $httpBackend.flush();
    }
    ));

    it('should get all department', inject(function (GetAllDepartment, $httpBackend) {
        var departments = [ { deptName: 'hr', id: 1 }, { deptName: 'php', id: 2 } ];
        var mockdepartments = departments;
        $httpBackend.when('GET', 'api/DepartmentApi/AllDepartment').respond(departments);
        promise = GetAllDepartment.getAllDepartment();

      
        promise.then(function (result) {
            expect(result.length).toBe(2);
        })
        $httpBackend.flush();
    }
    ));

    it('Creating new department', inject(function (GetAllDepartment, $httpBackend) {

        var department = { dep: { deptName: 'hr', id: 1 } };

        var mockdepartment = department;
        $httpBackend.when('POST', 'api/DepartmentApi/CreateDepartment').respond(department);
        promise = GetAllDepartment.createDepartment(department);
        promise.then(function (result) {
            expect(result.dep).toEqual(mockdepartment.dep);
        })
        $httpBackend.flush();

    }));

    it('Update Department', inject(function (GetAllDepartment, $httpBackend) {

        var department = { dep: { deptName: 'hr', id: 1 } };

        var mockdepartment = { dep: { deptName: 'hr', id: 2 } };
        $httpBackend.when('POST', 'api/DepartmentApi/UpdateDepartment').respond(department);
        promise = GetAllDepartment.updateDepartment(department);
        promise.then(function (result) {
            expect(result.dep).not.toEqual(mockdepartment.dep);
        })
        $httpBackend.flush();

    }));
    
    it('Delete Department', inject(function (GetAllDepartment, $httpBackend) {
        var department = [{ deptName: 'hr', id: 1 }, { deptName: 'php', id: 2 }];

        var mockdepartment = department;
        $httpBackend.when('GET', 'api/DepartmentApi/DeleteDepartment/1').respond(department[1]);
        promise = GetAllDepartment.deleteDepartment(department[0].id);
        promise.then(function (result) {
            expect(result.deptName).not.toEqual('hr');
        })
        $httpBackend.flush();
    }))

});