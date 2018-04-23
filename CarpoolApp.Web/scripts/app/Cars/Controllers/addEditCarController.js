angular
    .module('carpoolApp.cars')
    .controller('addEditCarController',
        ['$scope', '$uibModalInstance', 'vehicleDTO', 'vehicleServices', 'notificationFactory',
            function ($scope, $uibModalInstance, vehicleDTO, vehicleServices, notificationFactory) {
                debugger;
                $scope.isEdit = vehicleDTO != null && vehicleDTO != undefined;
                $scope.VehicleDTO = $scope.isEdit ? angular.copy(vehicleDTO) : {};
                $scope.modelState = null;


                $scope.add = function () {
                    var method = $scope.isEdit ? vehicleServices.update : vehicleServices.save;
                    //$scope.VehicleDTO.OwnerName = "Siddhesh";
                    var VehicleDTO = $scope.VehicleDTO;
                    method(VehicleDTO).$promise
                        .then(
                        function (response) {
                            $uibModalInstance.close();
                        },
                        function (response) {
                            debugger;
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
            }]);