(function () {
    'use-strict';

    angular.module('user').service('userService', UserService);

    UserService.$inject = [];

    function UserService() {

        var instance = {
        };

        return instance;
    }
})();