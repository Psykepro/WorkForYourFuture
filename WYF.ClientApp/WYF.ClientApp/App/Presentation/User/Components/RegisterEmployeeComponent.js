(function () {
    'use-strict';

    angular.module('presentation').component('registerEmployee', {
        controller: 'userController',
        controllerAs: 'vm',
        restrict: 'E',
        templateUrl: 'App/Presentation/User/Views/registerEmployee.html'
    });

})();