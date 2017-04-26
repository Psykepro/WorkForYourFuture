(function () {
    'use-strict';

    angular.module('business').service('jobService', JobService);

    JobService.$inject = [];

    function JobService() {

        var instance = {
        };

        return instance;
    }
})();