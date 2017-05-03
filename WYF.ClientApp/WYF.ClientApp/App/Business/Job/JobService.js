(function () {
    'use-strict';

    angular.module('business').service('jobService', JobService);

    JobService.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService'];

    function JobService($q, webApiRoutesProvider, webApiRequestsService) {

        var currentService = "Job";

        var instance = {
            getAllJobPostings: getAllJobPostings,
            getAllHierarchyLevels: getAllHierarchyLevels
        };

        function getAllJobPostings() {
            var currentAction = "All";
            var route = webApiRoutesProvider.Routes[currentService][currentAction];
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

        function getAllHierarchyLevels() {
            var currentAction = "HierarchyLevels";
            var route = webApiRoutesProvider.Routes[currentService][currentAction];
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