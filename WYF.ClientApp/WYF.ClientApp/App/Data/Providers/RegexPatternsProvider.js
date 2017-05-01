(function () {
    'use-strict';

    angular.module('data').service('regexPatternsProvider', RegexPatternsProvider);

    function RegexPatternsProvider() {

        var instance = {
            passwordPattern: "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{6,}$",
            emailPattern: "^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$",
            namePattern: "^[A-Za-z]+$",
            usernamePattern: "^[a-zA-Z0-9]{2,15}$"
        };

        return instance;
    };

})();