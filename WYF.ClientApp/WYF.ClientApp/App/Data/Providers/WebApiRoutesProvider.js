(function () {
    'use-strict';

    angular.module('data').service('webApiRoutesProvider', WebApiRoutesProvider);

    WebApiRoutesProvider.$inject = [];

    function WebApiRoutesProvider() {

        var apiPrefix = "/api/";

        var homeRoutes = {

        };

        var userRoutes = {
            "Register": apiPrefix + "Register",
            "Login": apiPrefix + "Token",
            "FacebookLogin": apiPrefix +
                "User/ExternalLogin?provider=Facebook&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A64219%2",
            "GoogleLogin": apiPrefix +
                "User/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A64219%2F"
        };

        var jobRoutes = {

        };

        var adminRoutes = {

        };

        var instance = {
            Routes: {
                "Home": homeRoutes,
                "User": userRoutes,
                "Job": jobRoutes,
                "Admin": adminRoutes
            }
        };

        return instance;
    };

})();