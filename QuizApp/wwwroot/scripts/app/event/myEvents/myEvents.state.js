'use strict';

angular.module('app').config(MyEventsStateProvider);

MyEventsStateProvider.$inject = ['$stateProvider'];

function MyEventsStateProvider($stateProvider) {
    $stateProvider
    .state('myEvents', {
        url: '/{userId}/myEvents',
        templateUrl: '/./../../scripts/app/event/myEvents/myEvents.template.html',
        controller: 'myEventsController',
        controllerAs: 'vm'
    });
};