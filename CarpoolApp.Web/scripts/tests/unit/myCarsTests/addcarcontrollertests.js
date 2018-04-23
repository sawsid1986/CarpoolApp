describe('Add Cars Controller Tests', function () {
    var scope, $controller, uibModalInstance, vehicleService, notificationFactory, $httpBackend, vehicleHttpService;

    beforeEach(module('carpoolapp'));
    beforeEach(inject(function (_$controller_, VehicleServices, NotificationFactory, _$httpBackend_) {
        scope = {};
        $httpBackend = _$httpBackend_;

        uibModalInstance = {
            close: function () { },
            dismiss: function (message) { }
        };

        vehicleService = VehicleServices;
        notificationFactory = NotificationFactory;
        $controller = _$controller_;

        spyOn(uibModalInstance, 'close');

        vehicleHttpService = $httpBackend
            .when('POST', 'api/Vehicle')
            .respond(200, '');
    }));

    var runController = function () {
        $controller('addeditcarcontroller', { $scope: scope, $uibModalInstance: uibModalInstance, vehicleService, notificationFactory });
    };

    it('Ok method should call close on success', function () {
        runController();
        scope.add();
        $httpBackend.flush();
        expect(uibModalInstance.close).toHaveBeenCalled();        
    });

    it('Ok method should not call close on failure', function () {
        vehicleHttpService.respond(401, '');
        runController();
        scope.add();
        $httpBackend.flush();
        expect(uibModalInstance.close).not.toHaveBeenCalled();
    });

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

});