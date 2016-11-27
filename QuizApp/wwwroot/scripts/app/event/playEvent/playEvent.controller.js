﻿'use strict';

angular.module('app').controller('playEventController', PlayEventController);

PlayEventController.$inject = ['eventService', '$stateParams'];

function PlayEventController(eventService, $stateParams) {
    var vm = this;

    eventService.playEvent($stateParams.id)
    .then(function (result) {
        vm.event = result.data;
    });
};