(function () {
    'use-strict';

    angular.module('presentation').controller('mainController', MainController);

    MainController.$inject = ['$scope',
                                'USERNAME_KEY_IN_LOCAL_STORAGE',
                                'ACCESSTOKEN_KEY_IN_LOCAL_STORAGE',
                                'USER_ID_IN_LOCAL_STORAGE'];

    function MainController($scope,
                            USERNAME_KEY_IN_LOCAL_STORAGE,
                            ACCESSTOKEN_KEY_IN_LOCAL_STORAGE,
                            USER_ID_IN_LOCAL_STORAGE) {

        var instance = {
            isAuthenticated: isAuthenticated,
            username: ''
        };

        function isAuthenticated() {
            var accessToken = localStorage.getItem(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE);

            if (accessToken !== null && accessToken !== undefined) {
                var currentUsername = localStorage.getItem(USERNAME_KEY_IN_LOCAL_STORAGE);
                var currentUserId = localStorage.getItem(USER_ID_IN_LOCAL_STORAGE);
                this.username = currentUsername;
                this.userId = currentUserId;

                return true;
            }

            return false;
        }

        $scope.$on('user-logged-in', function (event, args) {
            isAuthenticated();
        });


        return instance;
    }
})();