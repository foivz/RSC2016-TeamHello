'use strict';

angular.module('app').controller('myEventsController', MyEventsController);

MyEventsController.$inject = ['$state','eventService'];

function MyEventsController($state, eventService,loginService) {
    var vm = this;

    vm.a = "angularCheck";



    vm.futureEvents = eventService.getFutureEventsByMod();


    

};