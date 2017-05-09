(function () {
    angular.module('data').factory('RegisterEmployerBm',
        function() {

           
            function RegisterEmployerBm() {

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
                this.businessName = "";
                this.bulstatIdNumber = "";
                this.phoneNumber = "";

                return this;
            }


            return RegisterEmployerBm;
        });


})();

