'use strict';

angular.module('app').controller('homeController', HomeController);

HomeController.$inject = ['loginService', 'eventService'];

function HomeController(loginService, eventService) {
    var vm = this;

    eventService.getEvents()
    .then(function (result) {
        vm.events = result.data;
        console.log(vm.events);
    });
};