angular.module('carpoolApp.posts')
    .controller('postsController',
    ['$scope', 'postService', 'notificationFactory', '$uibModal',
        function ($scope, postService, notificationFactory, $uibModal) {
            $scope.MyPosts = null;

            var fetchMyPosts = function () {
                postService.query().$promise.then(
                function (response) {
                    $scope.MyPosts = response;
                },
                function (error) {                    
                    if (error.data['Message'] != null) {
                        notificationFactory.error(error.data['Message']);
                    }
                });                
            };

            $scope.addEditPosts = function (post) {
                $uibModal.open({
                    controller: 'addEditPostController',
                    templateUrl: 'MyPosts/AddEditPost',
                    size: 'lg',
                    resolve: {
                        postDTO: function () {
                            return post;
                        }
                    }
                }).result.then(
                    function () {
                        fetchMyPosts();
                        notificationFactory.success("Post added successfully");
                    });
            };

            fetchMyPosts();
        }]);