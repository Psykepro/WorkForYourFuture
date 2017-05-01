(function () {
    'use-strict';

    angular.module('business').service('userService', UserService);

    UserService.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService'];

    function UserService($q, webApiRoutesProvider, webApiRequestsService) {

        var instance = {
            login: login,
            registerEmployee: registerEmployee,
            setActiveEmployeeRegisterSection: setActiveEmployeeRegisterSection,
            setActiveEmployerRegisterSection: setActiveEmployerRegisterSection,
           
        };

        return instance;

        function setActiveEmployeeRegisterSection() {
            $('#employee-choose-section').addClass('active-register-section');
            $('#employer-choose-section').removeClass('active-register-section');
        }

        function setActiveEmployerRegisterSection(parameters) {
            $('#employer-choose-section').addClass('active-register-section');
            $('#employee-choose-section').removeClass('active-register-section');
        }

        function login(dto) {

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


        function registerEmployee(dto) {

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