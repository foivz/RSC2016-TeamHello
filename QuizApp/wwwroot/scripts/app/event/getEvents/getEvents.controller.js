'use strict';

angular.module('app').controller('getEventsController', GetEventsController);

GetEventsController.$inject = ['eventService'];

function GetEventsController(eventService) {
    var vm = this;

    eventService.getEvents()
    .then(function (result) {
        vm.events = result.data;
    });
};