(function () {
    'use-strict';

    angular.module('presentation').controller('mainController', MainController);

    MainController.$inject = ['$scope',
                                '$location',
                                'userService',
                                'USERNAME_KEY_IN_LOCAL_STORAGE',
                                'ACCESSTOKEN_KEY_IN_LOCAL_STORAGE',
                                'PERSON_ID_IN_LOCAL_STORAGE',
                                'ROLE_NAME_IN_LOCAL_STORAGE'];

    function MainController($scope,
                            $location,
                            userService,
                            USERNAME_KEY_IN_LOCAL_STORAGE,
                            ACCESSTOKEN_KEY_IN_LOCAL_STORAGE,
                            PERSON_ID_IN_LOCAL_STORAGE, 
                            ROLE_NAME_IN_LOCAL_STORAGE) {

        var instance = {
            checkAccess: checkAccess,
            logout: logout
        };

        function checkAccess() {
            var accessToken = localStorage.getItem(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE);

            if (accessToken !== null && accessToken !== undefined) {
                var currentUsername = localStorage.getItem(USERNAME_KEY_IN_LOCAL_STORAGE);
                var currentPersonId = localStorage.getItem(PERSON_ID_IN_LOCAL_STORAGE);
                var currentRoleName = localStorage.getItem(ROLE_NAME_IN_LOCAL_STORAGE);
                _setUsername(currentUsername);
                _setPersonId(currentPersonId);

                if (currentRoleName.toLocaleLowerCase() === "employer") {
                    _setIsEmployer(true);
                } else {
                    _setIsEmployer(false);
                }

                return true;

            } else {
                _setUsername('');
                _setPersonId('');
                _setIsEmployer(null);
            }

            return false;
        }

        function _setUsername(value) {
            if (value !== undefined && value !== null) {
                instance.username = value;
            }
        }

        function _setPersonId(value, isAuthenticated) {
            if (value !== undefined && value !== null) {
                instance.personId = value;
            } 
        }

        function _setIsEmployer(value) {
            if (value !== undefined) {
                instance.isEmployer = value;
            }
        }

        function logout() {
            userService.logout()
                .then(function success(result) {
                    notie.alert({
                        type: 'success',
                        text: "You successfully logout!",
                        position: 'bottom'
                    });

                    checkAccess();

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
            checkAccess();
        });


        return instance;
    }
})();