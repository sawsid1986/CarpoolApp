angular.module('carpoolApp')
    .controller('showMessageController',
        ['$scope','$uibModalInstance','message',
        function ($scope, $uibModalInstance, message) {
            $scope.message = message || 'Do you wish to continue';
            
            $scope.yes = function () {
                $uibModalInstance.close();
            };

            $scope.no = function () {
                $uibModalInstance.dismiss('cancel');
            };
       
    }]);