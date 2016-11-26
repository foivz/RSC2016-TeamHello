'use strict';

angular.module('app').controller('getEventController', GetEventController);

GetEventController.$inject = ['eventService'];

function GetEventController(eventService) {
    var vm = this;

    eventService.getEvent($stateParams.id)
    .then(function (result) {
        vm.event = result.data;
    });
};