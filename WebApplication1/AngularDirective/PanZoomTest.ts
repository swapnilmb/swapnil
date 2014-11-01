/// <reference path="scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="scripts/typings/angularjs/angular-mocks.d.ts" />
/// <reference path="scripts/typings/angularjs/angular.d.ts" />



describe('panDisableSpec', () => {
    var scope, $controllerConstructor, directiveController, element, attr;

    beforeEach(angular.mock.module("Application"));

    beforeEach(inject(($controller: ng.IControllerService,
        $rootScope: ng.IRootScopeService,
        $q: ng.IQService, $compile: ng.ICompileService, $window: ng.IWindowService
         )=> {

        $controllerConstructor = $controller;
        scope = $rootScope.$new();

        element = ' <svg height="700" width="700" zoom-enabled="false" pan-zoom  ">';

        element = $compile(element)(scope);

        scope.$digest();

    }));


    it("should not call panEnable method if zoomEnabled is false", () => {

        expect(scope.panEnable).not.toBeDefined();

    });

    it("should have the variable panBtnVisible as false if  zoomEnabled is false  ", () => {

        expect(scope.panBtnVisible).toBe(false);

    })



});


describe('panEnableSpec', () => {
    var scope, $controllerConstructor, directiveController, element, attr;

    beforeEach(angular.mock.module("Application"));

    beforeEach(inject(($controller: ng.IControllerService,
        $rootScope: ng.IRootScopeService,
        $q: ng.IQService, $compile: ng.ICompileService, $window: ng.IWindowService
         )=> {

        $controllerConstructor = $controller;
        scope = $rootScope.$new();

        element = ' <svg height="700" width="700" zoom-enabled="True" pan-zoom  ">';

        element = $compile(element)(scope);

        scope.$digest();

    }));




    it("should have the variable panBtnVisible as true if method zoomIn is called  ", () => {

        scope.zoomIn();
        expect(scope.panBtnVisible).toBe(true);

    })

    it("should have the variable panBtnVisible as true if method zoomOut is called ", () => {

        scope.zoomOut();
        expect(scope.panBtnVisible).toBe(true);

    })

      it("should call panEnable method if zoomEnabled is true ", () => {

        expect(scope.panEnable).toBeDefined();

    });



});
