app.service("PostService", function ($http) {

   // get All Post
    this.getPosts = function () {
        return $http.get("Post/PostList");
    };

    //get new post
    this.getNewPost = function () {
        return $http.get("Post/New");
    };

    // get Post By Id
    this.getPost = function (id) {
        var response = $http({
            method: "post",
            url: "Post/Edit",
            params: {
                id: id
            }
        });
        return response;
    }

    // Update Post 
    this.updatePost = function (Post) {
        var response = $http({
            method: "post",
            url: "Post/EditPost",
            data: JSON.stringify(Post),
            dataType: "json"
        });
        return response;
    }

    // New Post
    this.newPost = function (Post) {
        var response = $http({
            method: "post",
            url: "Post/NewPost",
            data: JSON.stringify(Post),
            dataType: "json"
        });
        return response;
    }

    //Delete Post
    this.Delete = function (PostId) {
        var response = $http({
            method: "post",
            url: "Post/Delete",
            params: {
                PostId: JSON.stringify(PostId)
            }
        });
        return response;
    }
});

app.service("TagsService", function ($http) {

    //get All Tags
    this.getPosts = function () {
        return $http.get("Tags/TagsList");
    };
});