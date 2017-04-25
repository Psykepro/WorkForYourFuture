(function () {
    'use-strict';

    var url = "http://localhost";
    var port = "64219";
    var url_with_port = url + ":" + port;

    var app = angular
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
        .config(['$routeProvider'], function configApp($routeProvider) {
            $routeProvider
                /////////////////
                // Home Routes //
                /////////////////
                .when("/",
                {
                    controller: 'HomeController',
                    templateUrl: '~/Presentation/Home/Home.html',
                    controllerAs: 'vm'
                })
                .when("/Home",
                {
                    controller: 'HomeController',
                    templateUrl: '~/Presentation/Home/Home.html',
                    controllerAs: 'vm'
                })
                .when("/Home/Contacts",
                {
                    controller: 'HomeController',
                    templateUrl: '~/Presentation/Home/Contacts.html',
                    controllerAs: 'vm'
                })
                .when("/Home/About",
                {
                    controller: 'HomeController',
                    templateUrl: '~/Presentation/Home/About.html',
                    controllerAs: 'vm'
                })
                /////////////////
                // User Routes //
                /////////////////
                .when("/User/Register",
                {
                    controller: 'UserController',
                    templateUrl: '~/Presentation/User/Register.html',
                    controllerAs: 'vm'
                })
                .when("/User/Login",
                {
                    controller: 'UserController',
                    templateUrl: '~/Presentation/User/Login.html',
                    controllerAs: 'vm'
                })
                .when("/User/Profile/:id",
                {
                    controller: 'UserController',
                    templateUrl: '~/Presentation/User/Profile.html',
                    controllerAs: 'vm'
                })
                //////////////////////
                // Job(Area) Routes //
                //////////////////////
                .when("/Job/Add",
                {
                    controller: 'JobController',
                    templateUrl: '~/Presentation/Job/Add.html',
                    controllerAs: 'vm'
                })
                .when("/Job/All",
                {
                    controller: 'JobController',
                    templateUrl: '~/Presentation/Job/All.html',
                    controllerAs: 'vm'
                })
                .when("/Job/Details/:id",
                {
                    controller: 'JobController',
                    templateUrl: '~/Presentation/Job/Details.html',
                    controllerAs: 'vm'
                })
                .when("/Job/Edit/:id",
                {
                    controller: 'JobController',
                    templateUrl: '~/Presentation/Job/Edit.html',
                    controllerAs: 'vm'
                })
                ////////////////////////
                // Admin(Area) Routes //
                ////////////////////////
                .when("/Admin/Users",
                {
                    controller: 'AdminController',
                    templateUrl: '~/Presentation/Admin/Users.html',
                    controllerAs: 'vm'
                })
                .when("/Admin/Users/:id",
                {
                    controller: 'AdminController',
                    templateUrl: '~/Presentation/Admin/User-Details.html',
                    controllerAs: 'vm'
                })
                .otherwise({
                    redirectTo: '/'
                });

        }); // config
})();