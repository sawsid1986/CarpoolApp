angular.module("carpoolApp.posts")
    .controller('addEditPostController',
        ['$scope', '$uibModalInstance', 'postDTO', 'postService', 'notificationFactory', 'vehicleServices','locationService',
        function ($scope, $uibModalInstance, postDTO, postService, notificationFactory, vehicleServices, locationService) {
            $scope.isEdit = postDTO != null && postDTO != undefined;
            $scope.postDTO = $scope.isEdit ? angular.copy(postDTO) : {};
            $scope.modelState = null;
            $scope.vehicleList = null;

            var fetchMasterData = function () {
                vehicleServices.query().$promise.then(
                        function (response) {
                            $scope.vehicleList = response;
                        },
                        function (error) {
                            if (error.data['Message'] != null) {
                                notificationFactory.error(error.data['Message']);
                            }
                        });               
            };

            $scope.getLocations = function (locationName) {
                return locationService.getLocations({ locationName: locationName }).$promise.then(
                        function (response) {
                            return response;
                        },
                        function (error) {
                            if (error.data['Message'] != null) {
                                notificationFactory.error(error.data['Message']);
                            }
                        });
            }
            
            $scope.setLocation = function (Location,modelName) {                
                $scope.postDTO[modelName] = Location.Id;
            }

            $scope.add = function () {
                var method = $scope.isEdit ? postService.update : postService.save;                
                var postDTO = $scope.postDTO;

                method(postDTO).$promise
                    .then(
                    function (response) {
                        $uibModalInstance.close();
                    },
                    function (response) {                        
                        if (response.data['ModelState'] != null) {
                            $scope.modelState = response.data['ModelState'];
                        } else {
                            if (response.data['Message'] != null) {
                                $scope.modelState = null;
                                notificationFactory.error(response.data['Message']);
                            }
                        }
                    });
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };

            fetchMasterData();
        }]);