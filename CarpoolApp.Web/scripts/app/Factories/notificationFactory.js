angular.module('carpoolApp')
    .factory('notificationFactory', function () {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        return {
            error: function (message) {
                toastr.error(message);
            },
            success: function (message) {
                toastr.success(message);
            },
            info: function (message) {
                toastr.info(message);
            },
            warning: function (message) {
                toastr.warning(message);
            }

        };

    });