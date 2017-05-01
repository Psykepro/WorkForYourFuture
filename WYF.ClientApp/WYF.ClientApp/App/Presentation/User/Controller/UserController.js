(function () {
    'use-strict';

    angular.module('presentation').controller('userController', UserController);

    UserController.$inject = ['$scope', 'userService', 'regexPatternsProvider'];

    function UserController($scope, userService, regexPatternsProvider) {

        $scope.passwordPattern = regexPatternsProvider.passwordPattern;
        $scope.emailPattern = regexPatternsProvider.emailPattern;
        $scope.namePattern = regexPatternsProvider.namePattern;
        $scope.usernamePattern = regexPatternsProvider.usernamePattern;

        var instance = {
            submitLoginForm: submitLoginForm,
            isEmployeeRegistering: true,
            submitEmployeeRegisterForm: submitEmployeeRegisterForm,
            myDate: new Date(),
            isOpen: false
        };

        function submitLoginForm() {

            var isFormValid = $scope.loginForm.$valid;
            var dto = {
                username: this.username,
                password: this.password

            };

            if (isFormValid) {

                userService
                    .Login(dto)
                    .then(function success(result) {
                        var accessToken = result.access_token;
                        var userName = result.userName;
                        localStorage.setItem("accessToken", accessToken);
                        localStorage.setItem("username", userName);
                        notie.alert({
                            type: 'success',
                            text: "The login was successful!",
                            position: 'bottom'
                        });
                    },
                        function failure(error) {
                            notie.alert({
                                type: 'error',
                                text: "The login wasn't successful!",
                                position: 'bottom'
                            });
                        });
            }
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
                };

                userService
                    .RegisterEmployee(dto)
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