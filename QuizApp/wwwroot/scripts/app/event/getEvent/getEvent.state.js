'use strict';

angular.module('app').config(GetEventStateProvider);

GetEventStateProvider.$inject = ['$stateProvider'];

function GetEventStateProvider($stateProvider) {
    $stateProvider
    .state('getEvent', {
        url: '/get-event/{id}',
        templateUrl: '/./../../scripts/app/event/getEvent/getEvent.template.html',
        controller: 'getEventController',
        controllerAs: 'vm'
    });
};