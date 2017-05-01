(function () {
    'use-strict';

    angular.module('data').service('webApiRoutesProvider', WebApiRoutesProvider);

    function WebApiRoutesProvider() {

        var apiPrefix = "/api/";

        var homeRoutes = {

        };

        var userApiPrefix = apiPrefix + 'User/';
        var userRoutes = {
            "RegisterEmployee": userApiPrefix + "RegisterEmployee",
            "Login": "/Token",
            "FacebookLogin": userApiPrefix +
                "ExternalLogin?provider=Facebook&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A64219%2",
            "GoogleLogin": userApiPrefix +
                "ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A64219%2F"
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