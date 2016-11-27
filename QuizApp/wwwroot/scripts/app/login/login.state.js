'use strict';

angular.module('app').config(loginStateProvider);

loginStateProvider.$inject = ['$stateProvider'];

function loginStateProvider($stateProvider) {
    $stateProvider
    .state('login', {
        url: '/login',
        templateUrl: '/./../../scripts/app/login/login.template.html'
    });
};