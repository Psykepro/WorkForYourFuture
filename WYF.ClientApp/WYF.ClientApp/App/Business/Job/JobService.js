(function () {
    'use-strict';

    angular.module('business').service('jobService', JobService);

    JobService.$inject = ['$q', 'webApiRoutesProvider', 'webApiRequestsService'];

    function JobService($q, webApiRoutesProvider, webApiRequestsService) {

        var instance = {
        };
       
        return instance;
    }
})();