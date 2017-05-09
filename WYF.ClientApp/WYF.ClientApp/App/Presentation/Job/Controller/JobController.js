(function () {
    'use-strict';

    angular.module('presentation').controller('jobController', JobController);

    JobController.$inject = ['$scope', 'jobProvider'];

    function JobController($scope, jobProvider) {

        var instance = {
            allJobPostings: jobProvider.allJobPostings,
            allHierarchyLevels: jobProvider.allHierarchyLevels
        };
       

        return instance;
    }


    function getData(parameters) {
        
    }
})();
