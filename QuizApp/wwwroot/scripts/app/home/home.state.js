'use strict';

angular.module('app').config(homeStateProvider);

homeStateProvider.$inject = ['$stateProvider'];

function homeStateProvider($stateProvider) {
    $stateProvider
    .state('home', {
        url: '/home',
        templateUrl: '/./../../scripts/app/home/home.template.html',
        controller: 'homeController',
        controllerAs: 'vm'
    });
};