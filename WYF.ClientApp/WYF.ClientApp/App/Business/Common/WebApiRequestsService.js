(function () {
    'use-strict';

    angular.module('business').service('webApiRequestsService', WebApiRequestsService);

    WebApiRequestsService.$inject = ['$http', '$q', 'URL_WITH_PORT'];

    function WebApiRequestsService($http, $q, URL_WITH_PORT) {

        var instance = {
            PostRequest: PostRequest,
            GetRequest: GetRequest
        };

        return instance;

        function PostRequest(route, dto, headers) {

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
            
            headers = headers || $http.defaults.headers.post;
            headers["Access-Control-Allow-Origin"] = '*';

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

        function GetRequest(route, headers) {
            headers = headers || $http.defaults.headers.get;

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

    }
})();