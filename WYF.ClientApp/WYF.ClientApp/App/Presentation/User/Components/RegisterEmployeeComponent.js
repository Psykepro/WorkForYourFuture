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
        $scope.namePattern = regexPatternsProvider.namePattern;


        var instance = {
            submitEmployeeRegisterForm: submitEmployeeRegisterForm,
            ToggleIsOpen: function() {
                this.isOpen = !this.isOpen;
            },
            myDate: new Date(),
            isOpen: false
    }

        function submitEmployeeRegisterForm() {
            var isFormValid = $scope.registerEmployeeForm.$valid;

            if (isFormValid) {
                var email = this.email;
                var password = this.password;
                var confirmPassword = this.confirmPassword;

                userService.Register(email, password, confirmPassword)
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