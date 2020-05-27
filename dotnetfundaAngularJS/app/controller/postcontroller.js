app.controller("postListController",
     ['$scope', 'PostService', '$window', '$routeParams',
    function ($scope, PostService, $window, $routeParams) {

        GetAllPosts();

        //Get All Posts  
        function GetAllPosts() {
            var getData = PostService.getPosts();
            getData.then(function (pst) {
                $scope.posts = pst.data;
            }, function () {
                $scope.message = 'Unable to load post data: ' + error.message;
            });
        }

        //Delete Post
        $scope.deletePost = function (postId) {
            var getData = PostService.Delete(postId);
            getData.then(function (msg) {
                $scope.message = 'Post Successfully Deleted.';
            }, function () {
                $scope.message = 'Unable to delete post: ' + error.message;
            });
        }
    }]);

app.controller("postController",
     ['$scope', 'PostService', '$window', '$routeParams',
    function ($scope, PostService, $window, $routeParams) {

        //Get Post by PostId
        $scope.post = {};
        if ($routeParams.id) {
            var getData = PostService.getPost($routeParams.id);
            getData.then(function (pst) {
                $scope.post = pst.data;
                $scope.PostId = pst.data.PostId;
                $scope.Title = pst.data.Title;
                $scope.Content = pst.data.Content;
                $scope.Tags = pst.data.Tags;
            }, function () {
                $scope.message = 'Unable to load post data: ' + error.message;
            });
        }
        //Add or Update Post
        $scope.AddUpdatePost = function () {
            var Post = {
                Title: $scope.Title,
                Content: $scope.Content,
                Tags: $scope.Tags,
                PostId: $scope.PostId
            };
            if (Post.PostId != null) { //Update Post
                var getData = PostService.updatePost(Post);
                getData.then(function (msg) {
                    $window.location = "#/post";
                    $scope.message = 'Post Successfully Updated.';
                }, function () {
                    $scope.message = 'Unable to update post: ' + error.message;
                });
            } else { //Add Post
                var getData = PostService.newPost(Post);
                getData.then(function (msg) {
                    $window.location = "#/post";
                    $scope.message = 'Post Successfully Created.';
                }, function () {
                    $scope.message = 'Unable to create new post: ' + error.message;
                });
            }
        }

        //Adding Tags to Post Model
        $scope.addtag = function (param) {
            if ($scope.Tags != null) {
                $scope.Tags = param + ';' + $scope.Tags;
            }
            else { $scope.Tags = param; }
        };

    }]);

app.controller("tagsController", function ($scope, TagsService) {
    GetAllTags();
    //Get All Tags  
    function GetAllTags() {
        var getData = TagsService.getPosts()
        getData.then(function (tags) {
            $scope.tags = tags.data;
        }, function () {
            $scope.message = 'Unable to load tags: ' + error.message;
        });
    }
});