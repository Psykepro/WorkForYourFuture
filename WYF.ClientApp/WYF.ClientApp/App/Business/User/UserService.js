(function () {
    'use-strict';

    angular.module('business').service('userService', UserService);

    UserService.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService'];

    function UserService($q, webApiRoutesProvider, webApiRequestsService) {

        var instance = {
            Login: Login,
            Register: Register
        };

        return instance;

        function Login(username, password) {

            var dto = {
                username: username,
                password: password,
                grant_type: 'password'
            };

            var route = webApiRoutesProvider.Routes["User"]["Login"];
            var defered = $q.defer();

            var headers = {
                "Content-Type": "application/x-www-form-urlencoded"
            }

            webApiRequestsService
                .PostRequest(route, dto, headers)
                .then(function success(result) {
                    defered.resolve(result);
                        console.log(result);
                    },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }


        function Register(username, password, confirmPassword) {

            var dto = {
                username: username,
                password: password,
                confirmPassword: confirmPassword
            };

            var route = webApiRoutesProvider.Routes["User"]["Register"];
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

        
    }

})();