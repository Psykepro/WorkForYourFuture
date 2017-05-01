(function () {
    'use-strict';

    angular.module('presentation').controller('userController', UserController);

    UserController.$inject = ['$scope',
                                'userService',
                                'commonService',
                                'regexPatternsProvider',
                                'errorMessagesProvider',
                                '$location'];

    function UserController($scope, userService, commonService, regexPatternsProvider, errorMessagesProvider, $location) {

        //////////////////////////////////////
        // SETTING REGEX PATTERNS TO $scope //
        //////////////////////////////////////

        $scope.passwordPattern = regexPatternsProvider.passwordPattern;
        $scope.emailPattern = regexPatternsProvider.emailPattern;
        $scope.namePattern = regexPatternsProvider.namePattern;
        $scope.usernamePattern = regexPatternsProvider.usernamePattern;
        $scope.phonePattern = regexPatternsProvider.phonePattern;
        $scope.bulstatIdNumberPattern = regexPatternsProvider.bulstatIdNumberPattern;
        $scope.businessNamePattern = regexPatternsProvider.businessNamePattern;

        //////////////////////////////////////
        // SETTING ERROR MESSAGES TO $scope //
        //////////////////////////////////////

        $scope.messageForNotMatchedPassword = errorMessagesProvider.messageForNotMatchedPassword;
        $scope.messageForNotMatchedBulstatIdNumber = errorMessagesProvider.messageForNotMatchedBulstatIdNumber;
        $scope.messageForNotMatchedEmail = errorMessagesProvider.messageForNotMatchedEmail;
        $scope.messageForConfirmPassword = errorMessagesProvider.messageForConfirmPassword;
        $scope.messageForMissingRequiredField = errorMessagesProvider.messageForMissingRequiredField;
        $scope.messageForNotMatchedName = errorMessagesProvider.messageForNotMatchedName;
        $scope.messageForNotMatchedPhone = errorMessagesProvider.messageForNotMatchedPhone;
        $scope.messageForNotMatchedUsername = errorMessagesProvider.messageForNotMatchedUsername;
        $scope.messageForNotMatchedBussinesName = errorMessagesProvider.messageForNotMatchedBussinesName;

        var instance = {
            submitLoginForm: submitLoginForm,
            submitEmployeeRegisterForm: submitEmployeeRegisterForm,
            chooseRegisterOption: chooseRegisterOption,
            isEmployeeRegistering: null,
            myDate: new Date(),
            isOpen: false,
            usernameOrPasswordError: '',
            allCities: null
        };

        function chooseRegisterOption(typeOfRegister) {
            commonService
                .getAllCities()
                .then(function success(result) {

                    instance.allCities = result;
                    if (typeOfRegister.toLowerCase() === "employee") {
                        instance.isEmployeeRegistering = true;
                        userService.setActiveEmployeeRegisterSection();
                    } else if (typeOfRegister.toLowerCase() === "employer") {
                        instance.isEmployeeRegistering = false;
                        userService.setActiveEmployerRegisterSection();
                    }

                    },
                    function failure(error) {
                        
                        notie.alert({
                            type: 'error',
                            text: error,
                            position: 'bottom'
                        });

                        $location.path('/');
                    });
        }

        function submitLoginForm() {

            var isFormValid = $scope.loginForm.$valid;

            var dto = {
                username: this.username,
                password: this.password

            };

            if (isFormValid) {

                userService
                    .login(dto)
                    .then(function success(result) {
                        if (instance.usernameOrPasswordError !== '') {
                            instance.usernameOrPasswordError = '';
                        }

                        notie.alert({
                            type: 'success',
                            text: "The login was successful!",
                            position: 'bottom'
                        });
                    },
                        function failure(error) {
                            instance.usernameOrPasswordError = error.data.error_description;
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
                    .registerEmployee(dto)
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