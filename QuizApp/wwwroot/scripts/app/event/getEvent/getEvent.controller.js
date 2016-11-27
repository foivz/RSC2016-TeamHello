'use strict';

angular.module('app').controller('getEventController', GetEventController);

GetEventController.$inject = ['eventService', '$stateParams'];

function GetEventController(eventService, $stateParams) {
    var vm = this;

    eventService.getEvent($stateParams.id)
    .then(function (result) {
        vm.event = result.data;
    });
};