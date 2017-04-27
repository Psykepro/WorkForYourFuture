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
                        iziToast.success({
                            timeout: 2000,
                            imageWidth: 150,
                            position: "topCenter",
                            title: 'OK',
                            message: 'The login was successful!',
                        });
                    },function failure(error) {
                        iziToast.error({
                            title: 'ERR',
                            message: "The login wasn't successful!",
                        });
                        });
            }
            
        }

        return instance;


    }
})();