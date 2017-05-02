function RegisterEmployerBM(username, email, password, confirmPassword, firstName, lastName, dateOfBirth, businessName, bulstatIdNumber, phoneNumber) {
    'use-strict';

    // Check if the function is not used as constructor \\
    if (!this instanceof arguments.callee) {
        return new arguments.callee(username, email, password, confirmPassword, firstName, lastName, dateOfBirth, businessName, bulstatIdNumber, phoneNumber);
    }

    var self = this;

    // TODO : Create Getters and Setters !
    self.username = username;
    self.email = email;
    self.password = password;
    self.confirmPassword = confirmPassword;
    self.firstName = firstName;
    self.lastName = lastName;
    self.dateOfBirth = dateOfBirth;
    self.businessName = businessName;
    self.bulstatIdNumber = bulstatIdNumber;
    self.phoneNumber = phoneNumber;

    return self;
}