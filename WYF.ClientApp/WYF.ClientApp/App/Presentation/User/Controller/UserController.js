(function () {
    'use-strict';

    angular.module('presentation').controller('userController', UserController);

    UserController.$inject = ['$scope', 'userService'];

    function UserController($scope, userService) {

        var instance = {
            submitForm: submitForm
        };

        function submitForm() {
            isFormValid = $scope.loginForm.$valid;

            if (isFormValid) {
                userService
                    .Login("ps@abv.bg", "Aa!1234")
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