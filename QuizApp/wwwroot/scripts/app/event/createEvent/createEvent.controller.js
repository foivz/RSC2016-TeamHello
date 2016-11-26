'use strict';

angular.module('app').controller('createEventController', CreateEventController);

CreateEventController.$inject = ['$state', 'eventService'];

function CreateEventController($state, eventService) {
    var vm = this;

    vm.event = {};

    vm.createEvent = function () {
        eventService.creatEvent(vm.event)
        .then(function (result) {
            var eventID = result.data;

            return $state.go('getEvent', { id: eventID });
        });
    }
};