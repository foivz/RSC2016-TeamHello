'use strict';

angular.module('app').controller('createEventController', CreateEventController);

CreateEventController.$inject = ['$state', 'eventService', '$stateParams'];

function CreateEventController($state, eventService, $stateParams) {
    var vm = this;

    vm.event = {};

    vm.createEvent = function () {
        event.UserID = $stateParams.userID;

        eventService.createEvent(vm.event)
        .then(function (result) {
            var eventID = result.data;

            return $state.go('getEvent', { id: eventID });
        });
    }
};