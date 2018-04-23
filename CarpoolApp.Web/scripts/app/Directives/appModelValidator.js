angular.module('carpoolApp')
    .directive('appModelValidator', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function (scope, elm, attrs, ctrl) {
                var fieldName = attrs['appModelValidatorField'] != null ? attrs['appModelValidatorField'] : attrs['ngModel'];
                var modelName = fieldName.includes(".") ? fieldName.split(".")[1] : fieldName;

                var getErrors = function (modelName) {
                    for (var model in scope.modelState) {
                        if (model.includes(modelName)) {
                            return scope.modelState[model];
                        }
                    }
                    return null;
                };

                scope.$watch("modelState", function (newValues) {
                    var errors = getErrors(modelName);

                    if (errors != null) {
                        ctrl.$setValidity("ModelError", false);
                        scope[modelName] = errors;
                    } else {
                        ctrl.$setValidity("ModelError", true);
                    }
                });
            }
        };
    });