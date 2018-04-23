angular.module('carpoolApp')
    .factory('dialogFactory',['$uibModal', function ($uibModal) {        
        return {
            confirm: function (message,callback) {
                $uibModal.open({
                    controller: 'showMessageController',
                    templateUrl: 'Dialog/Confirm',
                    resolve: {
                        message: function () {
                            return message;
                        }
                    }
                })
                .result.then(
                    function () {                        
                        callback();
                    });
            }
        };

    }]);