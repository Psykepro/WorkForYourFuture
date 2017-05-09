(function () {
    'use-strict';

    angular.module('data').service('jobProvider', JobProvider);

    JobProvider.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService']

    var currentService = "Job";

    function JobProvider($q, webApiRoutesProvider, webApiRequestsService) {

        var instance = {
            allJobPostings: getAllJobPostings(),
            allHierarchyLevels: getAllHierarchyLevels()
        };

        // Init allJobPostings
        getAllJobPostings();

        // Init allHierarchyLevels
        getAllHierarchyLevels();

        function getAllJobPostings() {
            var currentAction = "All";
            var route = webApiRoutesProvider.Routes[currentService][currentAction];
            var defered = $q.defer();

            webApiRequestsService
                .getRequest(route)
                .then(function success(result) {
                    instance.allJobPostings = result;
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
                    instance.allHierarchyLevels = result;
                    defered.resolve(result);
                },
                    function failure(error) {
                        defered.reject(error);
                    });

            return defered.promise;
        }

        return instance;
    };

})();