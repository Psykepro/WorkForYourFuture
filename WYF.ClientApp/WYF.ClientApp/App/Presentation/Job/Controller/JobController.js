(function () {
    'use-strict';

    angular.module('presentation').controller('jobController', JobController);

    JobController.$inject = ['$scope', 'jobService'];

    function JobController($scope, jobService) {

        var instance = {
            
        };

        
        (function () {

            // Initialize allJobs
            jobService
                .getAllJobPostings()
                .then(function success(result) {
                    instance.allJobs = result;
                },
                    function failure(error) {
                        notie.alert({
                            type: 'error',
                            text: error,
                            position: 'bottom'
                        });
                    });

            // Initialize allHierarchyLevels
            jobService
                .getAllHierarchyLevels()
                .then(function success(result) {
                    instance.allHierarchyLevels = result;
                },
                    function failure(error) {
                        notie.alert({
                            type: 'error',
                            text: error,
                            position: 'bottom'
                        });
                    });

        })();

        return instance;
    }


    function getData(parameters) {
        
    }
})();
