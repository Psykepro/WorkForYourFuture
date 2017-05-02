function RegisterEmployeeBM(username, email, password, confirmPassword, firstName, lastName, dateOfBirth) {

    // Check if the function is not used as constructor \\
    if (!this instanceof arguments.callee) {
        return new arguments.callee(username, email, password, confirmPassword, firstName, lastName, dateOfBirth);
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
    
    return self;
}