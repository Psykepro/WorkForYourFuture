(function () {
    'use-strict';

    angular.module('presentation').controller('mainController', MainController);

    MainController.$inject = ['$scope'];

    function MainController($scope) {

        

        var instance = {
            isAuthenticated : isAuthenticated
        };

        function isAuthenticated() {
            var accessToken = localStorage.getItem('accessToken');

            if (accessToken !== null && accessToken !== undefined) {
                $scope.userName = localStorage.getItem('userName');
                return true;
            }

            return false;
        }

        return instance;
    }
})();