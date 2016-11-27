'use strict';

angular.module('app').config(PlayEventForAdminStateProvider);

PlayEventForAdminStateProvider.$inject = ['$stateProvider'];

function PlayEventForAdminStateProvider($stateProvider) {
    $stateProvider
    .state('playEventForAdmin', {
        url: '/play-event/{token}/{id}',
        templateUrl: '/./../../scripts/app/event/playEventForAdmin/playEventForAdmin.template.html',
        controller: 'playEventForAdminController',
        controllerAs: 'vm'
    });
};