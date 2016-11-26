'use strict';

angular.module('app').config(EditEventStateProvider);

EditEventStateProvider.$inject = ['$stateProvider'];

function EditEventStateProvider($stateProvider) {
    $stateProvider
    .state('editEvent', {
        url: '/edit-event/{id}',
        templateUrl: '/./../../scripts/app/event/editEvent/editEvent.template.html',
        controller: 'editEventController',
        controllerAs: 'vm'
    });
};