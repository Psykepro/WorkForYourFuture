(function () {
    'use-strict';

    angular.module('presentation').component('registerEmployee', {
        controller: 'userController',
        controllerAs: 'vm',
        restrict: 'E',
        templateUrl: 'App/Presentation/User/Views/RegisterEmployee.html'
    });

    RegisterEmployeeController.$inject = ['$scope', 'userService', 'regexPatternsProvider'];

    function RegisterEmployeeController($scope, userService, regexPatternsProvider) {

        $scope.passwordPattern = regexPatternsProvider.passwordPattern;
        $scope.emailPattern = regexPatternsProvider.emailPattern;
        $scope.namePattern = regexPatternsProvider.namePattern;


        var instance = {
            submitEmployeeRegisterForm: submitEmployeeRegisterForm,
            myDate: new Date(),
            errorMessages: {},
            isOpen: false
        }

        function submitEmployeeRegisterForm() {
            var isFormValid = $scope.registerEmployeeForm.$valid;

            if (isFormValid) {

                var dto = {
                    username: this.username,
                    email: this.email, 
                    password: this.password, 
                    confirmPassword: this.confirmPassword, 
                    firstName: this.firstName, 
                    lastName: this.lastName,
                    dateOfBirth: this.dateOfBirth
                }

                userService.RegisterEmployee()
                    .then(function success(result) {
                        notie.alert({
                            type: 'success',
                            text: "The register was successful!",
                            position: 'bottom'
                        });
                        },
                        function failure(error) {
                            notie.alert({
                                type: 'error',
                                text: "The register wasn't successful!",
                                position: 'bottom'
                            });
                        });
            }
        }

        return instance;
    }
})();