(function () {
    'use-strict';

    angular.module('business').service('commonService', CommonService);

    CommonService.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService'];

    function CommonService($q, webApiRoutesProvider, webApiRequestsService) {

        var instance = {
            getAllCities: getAllCities,
            getAllLanguages: getAllLanguages
        };

        function getAllCities() {
            var route = webApiRoutesProvider.Routes["Common"]["Cities"];
            var defered = $q.defer();

            webApiRequestsService
                .getRequest(route)
                .then(function success(result) {
                    defered.resolve(result);
                },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }

        function getAllLanguages() {
            var route = webApiRoutesProvider.Routes["Common"]["Languages"];
            var defered = $q.defer();

            webApiRequestsService
                .getRequest(route)
                .then(function success(result) {
                    defered.resolve(result);
                },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }

        return instance;
    }

})();