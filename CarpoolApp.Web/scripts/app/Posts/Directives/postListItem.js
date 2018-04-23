angular.module('carpoolApp.posts')
    .directive('postListItem', function () {
        return {
            restrict: 'E',
            templateUrl: 'MyPosts/PostListItem',
            scope: {
                post: '=post'
            }
        };
    });