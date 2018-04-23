angular.module('carpoolApp')
    .controller('loginController', ['$scope', '$uibModalInstance', 'authService', function ($scope, $uibModalInstance, authService) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {

            authService.login($scope.loginData).then(function (response) {
                //    $location.path('/orders');
                $uibModalInstance.close();
            },
             function (err) {
                 $scope.message = err.error_description;
             });
        };

    }]);