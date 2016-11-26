'use strict';

angular.module('app').config(GetEventsStateProvider);

GetEventsStateProvider.$inject = ['$stateProvider'];

function GetEventsStateProvider($stateProvider) {
    $stateProvider
    .state('getEvents', {
        url: '/get-events',
        templateUrl: '/./../../scripts/app/event/getEvents/getEvents.template.html',
        controller: 'getEventsController',
        controllerAs: 'vm'
    });
};