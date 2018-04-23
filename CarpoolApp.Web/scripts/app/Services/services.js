angular.module('carpoolApp')
    .factory('vehicleServices', ['$resource', function ($resource) {
        return $resource('api/Vehicle/:id', { id: '@id' }, { update: { method: 'PUT' } });
    }])
    .factory('postService', ['$resource', function ($resource) {
        return $resource('api/post/:id', { id: '@id' }, { update: { method: 'PUT' } });
    }])
.factory('locationService', ['$resource', function ($resource) {
    return $resource('api/Location/:id', {
        id: '@id'
    },
    {
        update: { method: 'PUT' },
        getLocations: {
            method: 'GET',
            url: 'api/GetLocation?locationName=:locationName',
            isArray: true
        }
    });
}]);