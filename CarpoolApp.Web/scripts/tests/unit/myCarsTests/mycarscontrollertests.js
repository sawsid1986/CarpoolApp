describe('My Cars Controller Tests', function () {
    var scope, $controller, uibModal, vehicleService, notificationFactory, $httpBackend, vehicleHttpService;
    

    beforeEach(module('carpoolapp'));
    beforeEach(inject(function (_$controller_, $uibModal, VehicleServices, NotificationFactory, _$httpBackend_) {
        scope = {};
        $httpBackend = _$httpBackend_;
        
        uibModal = $uibModal;
        vehicleService = VehicleServices;
        notificationFactory = NotificationFactory;
        $controller = _$controller_;

        vehicleHttpService=$httpBackend
            .when('GET', 'api/Vehicle')
            .respond([{ name: 'A' }, { name: 'B' }]);
    }));

    var runController = function () {
        $controller('mycarscontroller', { $scope: scope, uibModal, vehicleService, notificationFactory });
    };

    it('Should create a `VehicleList` model with 2 vehicles', function () {        
        runController();
        $httpBackend.flush();        
        expect(scope.VehicleList.length).toBe(2);
    });

    it('Should create a `VehicleList` empty model ', function () {
        vehicleHttpService.respond(401, '');

        runController();
        $httpBackend.flush();
        expect(scope.VehicleList.length).toBe(0);
    });

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

});