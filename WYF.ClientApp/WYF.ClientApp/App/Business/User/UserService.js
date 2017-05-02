(function () {
    'use-strict';

    angular.module('business').service('userService', UserService);

    UserService.$inject = ['$q',
                            'USERNAME_KEY_IN_LOCAL_STORAGE',
                            'ACCESSTOKEN_KEY_IN_LOCAL_STORAGE',
                            'USER_ID_IN_LOCAL_STORAGE',
                            'webApiRoutesProvider',
                            'webApiRequestsService'];

    function UserService($q,
                         USERNAME_KEY_IN_LOCAL_STORAGE,
                         ACCESSTOKEN_KEY_IN_LOCAL_STORAGE,
                         USER_ID_IN_LOCAL_STORAGE,
                         webApiRoutesProvider,
                         webApiRequestsService) {

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
                .postRequest(route, dto, headers)
                .then(function success(result) {
                    var accessToken = result.access_token;
                    var userName = result.userName;
                    var expires = result['.expires'];

                    // Setting the authorization token to the headers
                    // and sending post request to api/User/UserInfo to get userId
                    headers['Authorization'] = "Bearer " + accessToken;
                    route = webApiRoutesProvider.Routes["User"]["UserInfo"];
                        webApiRequestsService
                            .getRequest(route, headers)
                            .then(function success(result) {

                                    localStorage.setItem(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE, accessToken);
                                    localStorage.setItem(USERNAME_KEY_IN_LOCAL_STORAGE, userName);
                                    localStorage.setItem(USER_ID_IN_LOCAL_STORAGE, result.Id);
                                    localStorage.setItem("expires", expires);

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


    }

})();