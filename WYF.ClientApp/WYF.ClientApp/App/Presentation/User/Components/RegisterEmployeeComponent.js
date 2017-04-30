(function () {
    'use-strict';

    angular.module('presentation').component('registerEmployee', {
        controller: RegisterEmployeeController,
        controllerAs: 'vm',
        restrict: 'E',
        templateUrl: 'App/Presentation/User/Views/RegisterEmployee.html'
    });

    RegisterEmployeeController.$inject = ['$scope', 'userService', 'regexPatternsProvider'];

    function RegisterEmployeeController($scope, userService, regexPatternsProvider) {
        $scope.passwordPattern = regexPatternsProvider.passwordPattern;
        $scope.emailPattern = regexPatternsProvider.emailPattern;

        var instance = {
            submitRegisterEmployeeForm: submitRegisterEmployeeForm
        }

        function submitRegisterEmployeeForm() {
            var isFormValid = $scope.loginForm.$valid;

            if (isFormValid) {

            }
        }
    }
})();