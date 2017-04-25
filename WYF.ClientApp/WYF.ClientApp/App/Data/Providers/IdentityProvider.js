(function () {
    'use-strict';

    angular.module('data').service('identityProvider', IdentityProvider);

    IdentityProvider.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService'];

    function IdentityProvider($q, webApiRoutesProvider, webApiRequestsService) {
        function Login(username, password) {

            var dto = {
                username: username,
                password: password,
                grant_type: 'password'
            };
            var route = webApiRoutesProvider.Routes["User"]["Login"];
            var defered = $q.defer();

            webApiRequestsService
                .PostRequest(route, dto)
                .then(function success(result) {
                    defered.resolve(result);
                },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }

        var instance = {
            Login: Login
        };

        return instance;

        
    }
})();