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
            'presentation',
            'ngMaterial',
            'ngMessages'
        ])
        .constant('URL', url)
        .constant('PORT', port)
        .constant('URL_WITH_PORT', url_with_port)
        .config(configureRoutes); // config;

    // Configuration of the routes
    configureRoutes.$inject = ['$routeProvider'];
    function configureRoutes($routeProvider) {
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
                templateUrl: 'App/Presentation/Home/Views/Home.html',
                controllerAs: 'vm'
            })
            .when("/Home",
            {
                controller: 'homeController',
                templateUrl: 'App/Presentation/Home/Views/Home.html',
                controllerAs: 'vm'
            })
            .when("/Home/Contacts",
            {
                controller: 'homeController',
                templateUrl: 'App/Presentation/Home/Views/Contacts.html',
                controllerAs: 'vm'
            })
            .when("/Home/About",
            {
                controller: 'homeController',
                templateUrl: 'App/Presentation/Home/Views/About.html',
                controllerAs: 'vm'
            })
            /////////////////
            // User Routes //
            /////////////////
            .when("/User/Register",
            {
                controller: 'userController',
                templateUrl: 'App/Presentation/User/Views/Register.html',
                controllerAs: 'vm'
            })
            .when("/User/Login",
            {
                controller: 'userController',
                templateUrl: 'App/Presentation/User/Views/Login.html',
                controllerAs: 'vm'
            })
            .when("/User/Profile/:id",
            {
                controller: 'userController',
                templateUrl: 'App/Presentation/User/Views/Profile.html',
                controllerAs: 'vm'
            })
            //////////////////////
            // Job(Area) Routes //
            //////////////////////
            .when("/Job/Add",
            {
                controller: 'jobController',
                templateUrl: 'App/Presentation/Job/Views/Add.html',
                controllerAs: 'vm'
            })
            .when("/Job/All",
            {
                controller: 'jobController',
                templateUrl: 'App/Presentation/Job/Views/All.html',
                controllerAs: 'vm'
            })
            .when("/Job/Details/:id",
            {
                controller: 'jobController',
                templateUrl: 'App/Presentation/Job/Views/Details.html',
                controllerAs: 'vm'
            })
            .when("/Job/Edit/:id",
            {
                controller: 'jobController',
                templateUrl: 'App/Presentation/Job/Views/Edit.html',
                controllerAs: 'vm'
            })
            ////////////////////////
            // Admin(Area) Routes //
            ////////////////////////
            .when("/Admin/Users",
            {
                controller: 'adminController',
                templateUrl: 'App/Presentation/Admin/Views/Users.html',
                controllerAs: 'vm'
            })
            .when("/Admin/Users/:id",
            {
                controller: 'adminController',
                templateUrl: 'App/Presentation/Admin/Views/User-Details.html',
                controllerAs: 'vm'
            });

    }

})();