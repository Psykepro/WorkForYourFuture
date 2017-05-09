(function () {
    'use-strict';

    angular.module('data').service('errorMessagesProvider', ErrorMessagesProvider);

    function ErrorMessagesProvider() {

        var instance = {
            messageForNotMatchedPassword:
                "Invalid password (Minimum 6 characters and at least 1 Uppercase Alphabet, 1 Lowercase Alphabet and 1 Number)",
            messageForNotMatchedUsername: "The Username must be between 2 and 15 characters and must contains only letters, digits and underscore.",
            messageForNotMatchedEmail: "Enter valid email.",
            messageForNotMatchedName: "The name must be between 2 and 15 characters and must contains only letters and spaces.",
            messageForNotMatchedPhone: "The phone number is invalid.",
            messageForNotMatchedBussinesName: "The Business Name must be between 2 and 30 characters with only letters, digits and '&' .",
            messageForNotMatchedBulstatIdNumber: "The Bulstat Id Number must be between 13 and 15 characters and must contains digits.",
            messageForMissingRequiredField: "This field is required.",
            messageForConfirmPassword: "The password and confirmation password do not match."
        };

        return instance;
    };

})();