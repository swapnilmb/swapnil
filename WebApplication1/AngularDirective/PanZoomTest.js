/// <reference path="scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="scripts/typings/angularjs/angular-mocks.d.ts" />
/// <reference path="scripts/typings/angularjs/angular.d.ts" />
describe('panDisableSpec', function () {
    var scope, $controllerConstructor, directiveController, element, attr;

    beforeEach(angular.mock.module("Application"));

    beforeEach(inject(function ($controller, $rootScope, $q, $compile, $window) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();

        element = ' <svg height="700" width="700" zoom-enabled="false" pan-zoom  ">';

        element = $compile(element)(scope);

        scope.$digest();
    }));

    it("should not call panEnable method if zoomEnabled is false", function () {
        expect(scope.panEnable).not.toBeDefined();
    });

    it("should have the variable panBtnVisible as false if  zoomEnabled is false  ", function () {
        expect(scope.panBtnVisible).toBe(false);
    });
});

describe('panEnableSpec', function () {
    var scope, $controllerConstructor, directiveController, element, attr;

    beforeEach(angular.mock.module("Application"));

    beforeEach(inject(function ($controller, $rootScope, $q, $compile, $window) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();

        element = ' <svg height="700" width="700" zoom-enabled="True" pan-zoom  ">';

        element = $compile(element)(scope);

        scope.$digest();
    }));

    it("should have the variable panBtnVisible as true if method zoomIn is called  ", function () {
        scope.zoomIn();
        expect(scope.panBtnVisible).toBe(true);
    });

    it("should have the variable panBtnVisible as true if method zoomOut is called ", function () {
        scope.zoomOut();
        expect(scope.panBtnVisible).toBe(true);
    });

    it("should call panEnable method if zoomEnabled is true ", function () {
        expect(scope.panEnable).toBeDefined();
    });
});
//# sourceMappingURL=PanZoomTest.js.map
