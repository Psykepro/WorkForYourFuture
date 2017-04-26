(function () {
    'use-strict';

    angular.module('business').service('homeService', HomeService);

    HomeService.$inject = [];

    function HomeService() {

        var instance = {
        };

        return instance;
    }
})();