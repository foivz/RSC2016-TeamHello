'use strict';

angular.module('app').config(CreateEventStateProvider);

CreateEventStateProvider.$inject = ['$stateProvider'];

function CreateEventStateProvider($stateProvider) {
    $stateProvider
    .state('createEvent', {
        url: '/{userId}/create-event',
        templateUrl: '/./../../scripts/app/event/createEvent/createEvent.template.html',
        controller: 'createEventController',
        controllerAs: 'vm'
    });
};