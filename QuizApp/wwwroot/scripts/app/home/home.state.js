'use strict';

angular.module('app').config(homeStateProvider);

homeStateProvider.$inject = ['$stateProvider'];

function homeStateProvider($stateProvider) {
    $stateProvider
    .state('home', {
        url: '/home',
        controller: '/./../../scripts/app/home/home.controller.js',
        templateUrl: '/./../../scripts/app/home/home.template.html'
    });
};