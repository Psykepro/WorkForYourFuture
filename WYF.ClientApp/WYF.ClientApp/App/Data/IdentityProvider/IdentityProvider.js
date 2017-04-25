(function () {
    'use-strict';

    angular.module('data').service('identityProvider', IdentityProvider);

    IdentityProvider.$inject = ['$http', 'url_with_port'];

    function IdentityProvider($http, url_with_port) {
        var instance = {
            Login: Login
        };
        return instance;

        function Login(username, password, onSuccessCallBack) {
            var dto = {
                username: username,
                password: password
            };
            var url = url_with_port + "/api/Token";
            $http.post(url, dto).then(function (result) {
                if (onSuccessCallBack != null && typeof onSuccessCallBack == 'function') onSuccessCallBack(result.data);
            }, function erro(result) {
                var a = 5;
            });
        }
    }
})();