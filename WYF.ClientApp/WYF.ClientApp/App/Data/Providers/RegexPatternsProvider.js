(function () {
    'use-strict';

    angular.module('data').service('regexPatternsProvider', RegexPatternsProvider);

    RegexPatternsProvider.$inject = [];

    function RegexPatternsProvider() {

        var instance = {
            passwordPattern: "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{6,}$",
            emailPattern: "^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$"
        };

        return instance;
    };

})();