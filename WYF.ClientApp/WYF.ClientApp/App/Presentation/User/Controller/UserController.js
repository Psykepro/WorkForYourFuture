(function () {
    'use-strict';

    angular.module('presentation').controller('userController', UserController);

    UserController.$inject = ['$scope', 'userService', 'regexPatternsProvider'];

    function UserController($scope, userService, regexPatternsProvider) {
        $scope.passwordPattern = regexPatternsProvider.passwordPattern;
        $scope.emailPattern = regexPatternsProvider.emailPattern;

        var instance = {
            submitLoginForm: submitLoginForm,
            isEmployeeRegistering: false
        };

        function submitLoginForm() {
            var isFormValid = $scope.loginForm.$valid;

            if (isFormValid) {
                userService
                    .Login(this.username, this.password)
                    .then(function success(result) {
                        var accessToken = result.access_token;
                        var userName = result.userName;
                        localStorage.setItem("accessToken", accessToken);
                        localStorage.setItem("userName", userName);
                        notie.alert({
                            type: 'success',
                            text: "The login was successful!",
                            position: 'bottom'
                        });
                    }, function failure(error) {
                        notie.alert({
                            type: 'error',
                            text: "The login wasn't successful!",
                            position: 'bottom'
                        });
                    });
            }

        }

        return instance;


    }
})();