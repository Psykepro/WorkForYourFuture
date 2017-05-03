(function () {
    'use-strict';

    angular.module('business').service('userService', UserService);

    UserService.$inject = ['$q',
                            'USERNAME_KEY_IN_LOCAL_STORAGE',
                            'ACCESSTOKEN_KEY_IN_LOCAL_STORAGE',
                            'PERSON_ID_IN_LOCAL_STORAGE',
                            'EXPIRES_IN_LOCAL_STORAGE',
                            'ROLE_NAME_IN_LOCAL_STORAGE',
                            'webApiRoutesProvider',
                            'webApiRequestsService'];

    function UserService($q,
                         USERNAME_KEY_IN_LOCAL_STORAGE,
                         ACCESSTOKEN_KEY_IN_LOCAL_STORAGE,
                         PERSON_ID_IN_LOCAL_STORAGE,
                         EXPIRES_IN_LOCAL_STORAGE,
                         ROLE_NAME_IN_LOCAL_STORAGE,
                         webApiRoutesProvider,
                         webApiRequestsService) {

        var instance = {
            login: login,
            logout: logout,
            registerEmployee: registerEmployee,
            registerEmployer: registerEmployer,
            clearLocalStorage: clearLocalStorage,
            setActiveEmployeeRegisterSection: setActiveEmployeeRegisterSection,
            setActiveEmployerRegisterSection: setActiveEmployerRegisterSection
        };

        return instance;

        function setActiveEmployeeRegisterSection() {
            $('#employee-choose-section').addClass('active-register-section');
            $('#employer-choose-section').removeClass('active-register-section');
        }

        function setActiveEmployerRegisterSection() {
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
                .postRequest(route, dto, headers)
                .then(function success(result) {
                    var accessToken = result.access_token;
                    var userName = result.userName;
                    var expires = result['.expires'];

                    localStorage.setItem(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE, accessToken);
                    localStorage.setItem(USERNAME_KEY_IN_LOCAL_STORAGE, userName);
                    localStorage.setItem(EXPIRES_IN_LOCAL_STORAGE, expires);

                    route = webApiRoutesProvider.Routes["User"]["PersonId"];

                        webApiRequestsService
                            .getRequest(route, headers)
                            .then(function success(result) {
                                    localStorage.setItem(PERSON_ID_IN_LOCAL_STORAGE, result.Value);
                                    localStorage.setItem(ROLE_NAME_IN_LOCAL_STORAGE, result.Key);

                                    defered.resolve(result);
                                },
                                function failure(error) {
                                    defered.reject(error);
                                });
                    },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }

        function logout() {
            var route = webApiRoutesProvider.Routes["User"]["Logout"];
            var defered = $q.defer();

            webApiRequestsService.postRequest(route)
                .then(function success(result) {
                    clearLocalStorage();
                    defered.resolve(result);
                }, function failure(error) {
                    clearLocalStorage();
                    defered.reject(error);
                });

            return defered.promise;
        }

        function clearLocalStorage() {
            localStorage.removeItem(USERNAME_KEY_IN_LOCAL_STORAGE);
            localStorage.removeItem(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE);
            localStorage.removeItem(EXPIRES_IN_LOCAL_STORAGE);
            localStorage.removeItem(PERSON_ID_IN_LOCAL_STORAGE);
            localStorage.removeItem(ROLE_NAME_IN_LOCAL_STORAGE);
        }

        function registerEmployee(dto) {

            var route = webApiRoutesProvider.Routes["User"]["RegisterEmployee"];
            var defered = $q.defer();

            webApiRequestsService
                .postRequest(route, dto)
                .then(function success(result) {
                    defered.resolve(result);
                },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }

        function registerEmployer(dto) {

            var route = webApiRoutesProvider.Routes["User"]["RegisterEmployer"];
            var defered = $q.defer();

            webApiRequestsService
                .postRequest(route, dto)
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