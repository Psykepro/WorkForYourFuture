function RegisterEmployeeBM(username, email, password, confirmPassword, firstName, lastName, dateOfBirth) {
    'use-strict';

    // Check if the function is not used as constructor \\
    if (!this instanceof arguments.callee) {
        return new arguments.callee(username, email, password, confirmPassword, firstName, lastName, dateOfBirth);
    }

    var self = this;

    // TODO : Create Getters and Setters !
    
    
    return self;
}

(function () {
    angular.module('data').factory('RegisterEmployeeBM',
        function () {

            function RegisterEmployeeBM() {

                if (!this instanceof arguments.callee) {
                    return new arguments.callee();
                }

                // TODO : Create Getters and Setters !
                this.username = "";
                this.email = "";
                this.password = "";
                this.confirmPassword = "";
                this.firstName = "";
                this.lastName = "";
                this.dateOfBirth = new Date();

                return this;
            }


            return RegisterEmployeeBM;
        });


})();

