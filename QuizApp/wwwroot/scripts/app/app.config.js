angular.module('app').config(AppConfig);

AppConfig.$inject = ['$urlRouterProvider', '$stateProvider'];

function AppConfig($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/home');
}