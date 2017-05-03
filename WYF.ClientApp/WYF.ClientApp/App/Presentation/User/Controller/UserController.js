(function () {
    'use-strict';

    angular.module('presentation').controller('userController', UserController);

    UserController.$inject = [
        '$scope',
        'RegisterEmployerBm',
        'RegisterEmployeeBM',
        'userService',
        'commonService',
        'regexPatternsProvider',
        'errorMessagesProvider',
        '$location',
        '$rootScope'
    ];

    function UserController($scope, RegisterEmployerBm, RegisterEmployeeBM, userService, commonService, regexPatternsProvider, errorMessagesProvider, $location, $rootScope) {

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
            submitEmployerRegisterForm: submitEmployerRegisterForm,
            chooseRegisterOption: chooseRegisterOption,
            isEmployeeRegistering: null,
            myDate: new Date(),
            isOpen: false,
            usernameOrPasswordError: "",
            allCities: null
        };

        function chooseRegisterOption(typeOfRegister) {
            if (typeOfRegister.toLowerCase() === "employee") {
                instance.registerEmlpoyeeBm = new RegisterEmployeeBM();
                instance.isEmployeeRegistering = true;
                userService.setActiveEmployeeRegisterSection();
            } else if (typeOfRegister.toLowerCase() === "employer") {
                instance.registerEmlpoyerBm = new RegisterEmployerBm();
                instance.isEmployeeRegistering = false;
                userService.setActiveEmployerRegisterSection();
            }
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

                        $rootScope.$broadcast('user-logged-in', { roleNameOfCurrentUser: result.Key });

                        notie.alert({
                            type: 'success',
                            text: "The login was successful!",
                            position: 'bottom'
                        });

                        $location.path("/");
                    },
                        function failure(error) {
                            instance.usernameOrPasswordError = error.error_description;
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

                userService
                    .registerEmployee(instance.registerEmployeeBM)
                    .then(function success(result) {
                        notie.alert({
                            type: 'success',
                            text: "The register was successful!",
                            position: 'bottom'
                        });

                        $location.path("/");
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

        function submitEmployerRegisterForm() {

            var isFormValid = $scope.registerEmployerForm.$valid;

            if (isFormValid) {

                userService
                    .registerEmployer(instance.registerEmlpoyerBm)
                    .then(function success(result) {
                        notie.alert({
                            type: 'success',
                            text: "The register was successful!",
                            position: 'bottom'
                        });

                        $location.path("/");
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