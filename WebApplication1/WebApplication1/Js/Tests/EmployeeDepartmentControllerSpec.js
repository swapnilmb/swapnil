describe('EmployeeDepartmentController', function () {
    var scope, $controllerConstructor, mockEventData;
    beforeEach(module('EmployeeDepartment'));
    beforeEach(inject(function ($controller, $rootScope) {
        scope = $rootScope.$new();
        mockEventData = sinon.stub({ getAllDepartment: function () { } });
        $controllerConstructor = $controller;
    }));
    it('should set the scope ', function () {
        var mockEvents = {};
        mockEventData.getAllDepartment.returns(mockEvents);
        var ctrl = $controllerConstructor("EmployeeDepartmentController", { $scope: scope, GetAllDepartment: mockEventData, $routeParams: {}, $location: {} });
        expect(scope.getAllDepartment).toBe(mockEvents);
    })

    it('should set the scope to url ', function () {
        var mocklocation = sinon.stub({ path: function () { } });
        var ctrl = $controllerConstructor("EmployeeDepartmentController", { $scope: scope, GetAllDepartment: mockEventData, $routeParams: {}, $location: mocklocation });

        var id = { id: 2 };

        scope.getdepartment(id);
       
        expect(mocklocation.path.calledWith('/UpdateDepartment/2')).toBe(true);
    })
})