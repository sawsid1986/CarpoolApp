angular.module('carpoolApp', ['carpoolApp.cars', 'carpoolApp.posts', 'angular-loading-bar', 'ngResource', 'ui.bootstrap', 'LocalStorageModule'])
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });;