'use strict';

angular.module('app').controller('editEventController', EditEventController);

EditEventController.$inject = ['$state', 'eventService', '$stateParams'];

function EditEventController($state, eventService, $stateParams) {
    var vm = this;

    eventService.getEvent($stateParams.id)
    .then(function (result) {
        vm.event = result.data;
    });

    vm.editEvent = function () {
        eventService.editEvent(vm.event)
        .then(function (result) {
            var eventID = result.data;

            return $state.go('getEvent', { id: eventID });
        });
    }
};