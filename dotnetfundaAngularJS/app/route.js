app.config(['$routeProvider', function ($routeProvider) {
    
    $routeProvider.when('/', {
        templateUrl: "/app/Home/home.html"
    }),

    $routeProvider.when('/post', {
        templateUrl: "/app/post/PostList.html",
        controller: "postListController"
    }),

    $routeProvider.when('/post/new', {
        templateUrl: "/app/post/Post.html",
        controller: "postController"
    }),

    $routeProvider.when('/post/:id', {
            templateUrl: "/app/post/Post.html",
            controller: "postController"
        }),


    $routeProvider.otherwise({
        redirectTo: '/'
    });

}]);
