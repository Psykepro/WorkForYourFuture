(function () {
    'use-strict';

    angular.module('data').service('webApiRoutesProvider', WebApiRoutesProvider);

    function WebApiRoutesProvider() {

        var apiPrefix = "/api/";

        //////////
        // USER //
        //////////
        var userApiPrefix = apiPrefix + 'User/';
        var userRoutes = {
            "RegisterEmployee": userApiPrefix + "RegisterEmployee",
            "RegisterEmployer": userApiPrefix + "RegisterEmployer",
            "Login": "/Token",
            "UserInfo": userApiPrefix + "UserInfo",
            "PersonId" : userApiPrefix + "PersonId",
            "Logout" : userApiPrefix + "Logout",
            "FacebookLogin": userApiPrefix +
                "ExternalLogin?provider=Facebook&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A64219%2",
            "GoogleLogin": userApiPrefix +
                "ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A64219%2F"
        };

        /////////
        // JOB //
        /////////
        var jobApiPrefix = apiPrefix + 'Job/';
        var jobRoutes = {
        };

        ////////////
        // COMMON //
        ////////////
        var commonApiPrefix = apiPrefix + 'Common/';
        var commonRoutes = {
            "Cities": commonApiPrefix + 'Cities',
            "Languages": commonApiPrefix + 'Languages',
        };

        ///////////
        // ADMIN //
        ///////////
        var adminApiPrefix = apiPrefix + 'Admin/';
        var adminRoutes = {

        };

        var instance = {
            Routes: {
                "User": userRoutes,
                "Job": jobRoutes,
                "Admin": adminRoutes,
                "Common": commonRoutes
            }
        };

        return instance;
    };

})();