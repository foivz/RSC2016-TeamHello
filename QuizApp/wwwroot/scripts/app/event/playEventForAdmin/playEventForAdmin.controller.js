'use strict';

angular.module('app').controller('playEventForAdminController', PlayEventForAdminController);

PlayEventForAdminController.$inject = ['eventService', '$stateParams'];

function PlayEventForAdminController(eventService, $stateParams) {
    var vm = this;

    eventService.playEventForAdmin($stateParams.id)
    .then(function (result) {
        vm.event = result.data;
    });
};