(function () {
    'use-strict';

    var url = "http://localhost";
    var port = "64219";
    var url_with_port = url + ":" + port;

    angular
        .module('clientApp',
        [
            'ngRoute',
            'data',
            'business',
            'presentation'
        ])
        .constant('URL', url)
        .constant('PORT', port)
        .constant('URL_WITH_PORT', url_with_port)
        .config(function configApp($routeProvider) {
            $routeProvider
                .otherwise({
                    redirectTo: '/'
                })
                /////////////////
                // Home Routes //
                /////////////////
                .when("/",
                {
                    controller: 'homeController',
                    templateUrl: 'App/Presentation/Home/Home.html',
                    controllerAs: 'vm'
                })
                .when("/Home",
                {
                    controller: 'homeController',
                    templateUrl: 'App/Presentation/Home/Home.html',
                    controllerAs: 'vm'
                })
                .when("/Home/Contacts",
                {
                    controller: 'homeController',
                    templateUrl: 'App/Presentation/Home/Contacts.html',
                    controllerAs: 'vm'
                })
                .when("/Home/About",
                {
                    controller: 'homeController',
                    templateUrl: 'App/Presentation/Home/About.html',
                    controllerAs: 'vm'
                })
                /////////////////
                // User Routes //
                /////////////////
                .when("/User/Register",
                {
                    controller: 'userController',
                    templateUrl: 'App/Presentation/User/Register.html',
                    controllerAs: 'vm'
                })
                .when("/User/Login",
                {
                    controller: 'userController',
                    templateUrl: 'App/Presentation/User/Login.html',
                    controllerAs: 'vm'
                })
                .when("/User/Profile/:id",
                {
                    controller: 'userController',
                    templateUrl: 'App/Presentation/User/Profile.html',
                    controllerAs: 'vm'
                })
                //////////////////////
                // Job(Area) Routes //
                //////////////////////
                .when("/Job/Add",
                {
                    controller: 'jobController',
                    templateUrl: 'App/Presentation/Job/Add.html',
                    controllerAs: 'vm'
                })
                .when("/Job/All",
                {
                    controller: 'jobController',
                    templateUrl: 'App/Presentation/Job/All.html',
                    controllerAs: 'vm'
                })
                .when("/Job/Details/:id",
                {
                    controller: 'jobController',
                    templateUrl: 'App/Presentation/Job/Details.html',
                    controllerAs: 'vm'
                })
                .when("/Job/Edit/:id",
                {
                    controller: 'jobController',
                    templateUrl: 'App/Presentation/Job/Edit.html',
                    controllerAs: 'vm'
                })
                ////////////////////////
                // Admin(Area) Routes //
                ////////////////////////
                .when("/Admin/Users",
                {
                    controller: 'adminController',
                    templateUrl: 'App/Presentation/Admin/Users.html',
                    controllerAs: 'vm'
                })
                .when("/Admin/Users/:id",
                {
                    controller: 'adminController',
                    templateUrl: 'App/Presentation/Admin/User-Details.html',
                    controllerAs: 'vm'
                });

        }); // config;

})();