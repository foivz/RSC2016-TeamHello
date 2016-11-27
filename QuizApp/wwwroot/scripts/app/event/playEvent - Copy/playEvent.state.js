'use strict';

angular.module('app').config(PlayEventStateProvider);

PlayEventStateProvider.$inject = ['$stateProvider'];

function PlayEventStateProvider($stateProvider) {
    $stateProvider
    .state('playEvent', {
        url: '/play-event/{token}',
        templateUrl: '/./../../scripts/app/event/playEvent/playEvent.template.html',
        controller: 'playEventController',
        controllerAs: 'vm'
    });
};