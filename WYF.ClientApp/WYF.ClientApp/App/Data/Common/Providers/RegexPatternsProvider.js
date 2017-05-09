(function () {
    'use-strict';

    angular.module('data').service('regexPatternsProvider', RegexPatternsProvider);

    function RegexPatternsProvider() {

        var instance = {
            passwordPattern: "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{6,}$",
            emailPattern: "^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$",
            namePattern: "^[A-Z\\sa-z]{2,15}$",
            usernamePattern: "^[a-zA-Z0-9_]{2,15}$",
            bulstatIdNumberPattern: "^[0-9]{13,15}$",
            phonePattern: "^[0-9]{10}$",
            businessNamePattern: "^[A-Za-z&,\\s0-9]{2,30}$"
        };

        return instance;
    };

})();