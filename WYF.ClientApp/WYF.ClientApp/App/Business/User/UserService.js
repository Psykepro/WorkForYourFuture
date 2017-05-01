(function () {
    'use-strict';

    angular.module('business').service('userService', UserService);

    UserService.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService'];

    function UserService($q, webApiRoutesProvider, webApiRequestsService) {

        var instance = {
            Login: Login,
            RegisterEmployee: RegisterEmployee
        };

        return instance;

        function Login(dto) {

            dto.grant_type = 'password';

            var route = webApiRoutesProvider.Routes["User"]["Login"];
            var defered = $q.defer();

            var headers = {
                "Content-Type": "application/x-www-form-urlencoded"
            }

            webApiRequestsService
                .PostRequest(route, dto, headers)
                .then(function success(result) {
                    var accessToken = result.access_token;
                    var userName = result.userName;
                    var expires = result['.expires'];

                    localStorage.setItem("accessToken", accessToken);
                    localStorage.setItem("username", userName);
                    localStorage.setItem("expires", expires);
                    defered.resolve(result);
                },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }


        function RegisterEmployee(dto) {

            var route = webApiRoutesProvider.Routes["User"]["RegisterEmployee"];
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