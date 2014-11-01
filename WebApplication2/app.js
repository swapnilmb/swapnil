//angular
//  .module('app', [])
//  .factory('Mycar', function () {
//      function Mycar() {
//          Car = "Name";
          
//      }
//      return Car;
//  })
//  .controller('MainCtrl', function ($scope, Mycar) {
//      $scope.mycar = new Mycar();
//  })
//  .config(function ($provide) {
//      $provide.decorator('Mycar', function ($delegate) {

//          Object.defineProperty($delegate.prototype, 'favorite', {
//              get: function () { return favCar(Car); }
//          });

//          function favCar(Car) {
//              return {
//                  Name: 'Porsche'
//              }[Car];
//          }

//          return $delegate;

//      });
//  });