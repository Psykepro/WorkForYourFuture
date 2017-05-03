(function () {
    'use-strict';

    angular.module('presentation').controller('mainController', MainController);

    MainController.$inject = ['$scope',
                                '$location',
                                'userService',
                                'USERNAME_KEY_IN_LOCAL_STORAGE',
                                'ACCESSTOKEN_KEY_IN_LOCAL_STORAGE',
                                'USER_ID_IN_LOCAL_STORAGE'];

    function MainController($scope,
                            $location,
                            userService,
                            USERNAME_KEY_IN_LOCAL_STORAGE,
                            ACCESSTOKEN_KEY_IN_LOCAL_STORAGE,
                            USER_ID_IN_LOCAL_STORAGE) {

        var instance = {
            isAuthenticated: isAuthenticated,
            logout: logout
        };

        function isAuthenticated() {
            var accessToken = localStorage.getItem(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE);

            if (accessToken !== null && accessToken !== undefined) {
                var currentUsername = localStorage.getItem(USERNAME_KEY_IN_LOCAL_STORAGE);
                var currentUserId = localStorage.getItem(USER_ID_IN_LOCAL_STORAGE);
                this.username = currentUsername;
                this.userId = currentUserId;

                return true;
            } else {
                this.username = '';
                this.userId = '';
            }

            return false;
        }


        function logout() {
            userService.logout()
                .then(function success(result) {
                    notie.alert({
                        type: 'success',
                        text: "You successfully logout!",
                        position: 'bottom'
                    });
                    isAuthenticated();
                    $location.path("/");
                }, function failure(error) {
                    notie.alert({
                        type: 'error',
                        text: "Some error ocurred during the logout!",
                        position: 'bottom'
                    });
                    $location.path("/");
                });

        }

        $scope.$on('user-logged-in', function (event, args) {
            isAuthenticated();
        });


        return instance;
    }
})();