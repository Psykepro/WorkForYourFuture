(function () {
    'use-strict';

    angular.module('home').service('homeService', HomeService);

    HomeService.$inject = [];

    function HomeService() {

        var instance = {
        };

        return instance;
    }
})();