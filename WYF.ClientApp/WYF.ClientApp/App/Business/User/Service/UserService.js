(function () {
    'use-strict';

    angular.module('business').service('userService', UserService);

    UserService.$inject = [];

    function UserService() {

        var instance = {
            Login: Login
        };

        return instance;

        function Login(username, password, onSuccessCallBack) {

            var dto = {
                username: username,
                password: password
            };

            var url = URL_WITH_PORT + "/api/Token";
            $http.post(url, dto).then(function (result) {
                if (onSuccessCallBack != null && typeof onSuccessCallBack == 'function') onSuccessCallBack(result.data);
            }, function erro(result) {
                var a = 5;
            });
        }
    }

})();