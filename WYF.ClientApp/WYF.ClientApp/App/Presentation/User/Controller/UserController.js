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
                userService.Login(this.username, this.password);
            }
            
        }

        return instance;


    }
})();