(function () {
    'use-strict';

    angular.module('business').service('webApiRequestsService', WebApiRequestsService);

    WebApiRequestsService.$inject = ['$http',
                                    '$q',
                                    'URL_WITH_PORT',
                                    'ACCESSTOKEN_KEY_IN_LOCAL_STORAGE'];

    function WebApiRequestsService($http, $q, URL_WITH_PORT, ACCESSTOKEN_KEY_IN_LOCAL_STORAGE) {

        var instance = {
            postRequest: postRequest,
            getRequest: getRequest
        };

        return instance;

        function postRequest(route, dto, headers) {

            isLoginRequest = false;

            if (route.includes("Token")) {
                isLoginRequest = true;
            }

            if (isLoginRequest === true) {
                var tempArr = [];

                for (var prop in dto) {
                    tempArr.push(prop + '=' + dto[prop]);
                }

                dto = tempArr.join('&');
            }
            
            headers = headers || $http.defaults.headers.post || [];
            headers["Access-Control-Allow-Origin"] = '*';
            headers = _setAuthorizationHeaderIfExistsAuthToken(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE, headers);

            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: URL_WITH_PORT + route,
                data: dto,
                headers: headers
            })
            .then(
            function (result) {
                deferred.resolve(result.data);
            },
            function (error) {
                deferred.reject(error.data);
            });

            return deferred.promise;
        }

        function getRequest(route, headers) {
            headers = headers || [];
            headers = _setAuthorizationHeaderIfExistsAuthToken(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE, headers);

            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: URL_WITH_PORT + route,
                headers: headers
            })
            .then(
            function (result) {
                deferred.resolve(result.data);
            },
            function (error) {
                deferred.reject(error.data);
            });

            return deferred.promise;
        }


        function _setAuthorizationHeaderIfExistsAuthToken(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE, headers) {
            var accessToken = localStorage.getItem(ACCESSTOKEN_KEY_IN_LOCAL_STORAGE);
            if (accessToken !== null && accessToken !== '') {
                headers["Authorization"] = "Bearer " + accessToken;
            }

            return headers;
        }
    }
})();