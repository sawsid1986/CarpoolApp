﻿angular.module('carpoolApp')
    .factory('authInterceptorService',
        ['$q','localStorageService',
            function ($q, localStorageService) {
                var authInterceptorServiceFactory = {};

                var _request = function (config) {

                    config.headers = config.headers || {};

                    var authData = localStorageService.get('authorizationData');
                    if (authData) {
                        config.headers.Authorization = 'Bearer ' + authData.token;
                    }

                    return config;
                }

                var _responseError = function (rejection) {                    
                    return $q.reject(rejection);
                }

                authInterceptorServiceFactory.request = _request;
                authInterceptorServiceFactory.responseError = _responseError;

                return authInterceptorServiceFactory;
            }]);