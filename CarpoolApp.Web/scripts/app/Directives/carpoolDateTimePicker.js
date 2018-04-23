angular.module('carpoolApp')
    .directive('carpoolDateTimePicker', function () {
        return {            
            restrict: 'A',
            link: function (scope, elm, attrs, ctrl) {
                jQuery(elm).datetimepicker({
                    format: 'd/m/Y H:i'
                });
            }
        };
    });