angular
    .module('carpoolApp.cars')
    .controller('carsController',
        ['$scope', '$uibModal', 'vehicleServices', 'notificationFactory', 'dialogFactory','$window',
            function ($scope, $uibModal, vehicleServices, notificationFactory, dialogFactory, $window) {
                $scope.VehicleList = null;
                var fetchVehicle = function () {
                    vehicleServices.query().$promise.then(
                        function (response) {
                            $scope.VehicleList = response;
                        },
                        function (error) {
                            if (error.data['Message'] != null) {
                                notificationFactory.error(error.data['Message']);
                            }
                        });
                };

                $scope.addEditCar = function (vehicle) {
                    $uibModal.open({
                        controller: 'addEditCarController',
                        templateUrl: 'MyCars/AddCar',
                        size: 'lg',
                        resolve: {
                            vehicleDTO: function () {
                                return vehicle;
                            }
                        }
                    }).result.then(
                        function () {
                            fetchVehicle();
                            notificationFactory.success("Car added successfully");
                        });
                };

                $scope.delete = function (vehicle) {
                    dialogFactory.confirm('Do you wish to delete this car', function () {
                        vehicleServices.delete({ id: vehicle.Id }).$promise.then(
                            function (response) {                                
                                fetchVehicle();
                            },
                            function (error) {
                                if (error.data['Message'] != null) {
                                    notificationFactory.error(error.data['Message']);
                                }
                            });
                    });
                }

                fetchVehicle();
            }]);