angular.module('carpoolApp')
    .controller('mainController', ['$scope', '$uibModal', 'authService', '$window', function ($scope, $uibModal, authService, $window) {
        $scope.login = function () {
            $uibModal.open({
                controller: 'loginController',
                templateUrl: 'Account/Login'
            });
        };        
        
        $scope.authentication = authService.authentication;

        $scope.$watch(
            function () {
                return authService.authentication;
            },
            function () {
                $scope.authentication = authService.authentication;
            });

        $scope.logOut = function () {
            authService.logOut();
            $window.location='/';
        };

    }]);