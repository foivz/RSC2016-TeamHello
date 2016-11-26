'use strict';

angular.module('app').controller('myEventsController', MyEventsController);

MyEventsController.$inject = ['$state','eventService','loginService'];

function MyEventsController($state, eventService,loginService) {
    var vm = this;

    vm.currentUser = loginService.getCurrentUser();
    vm.futureEvents = eventService.getFutureEventsByMod(vm.currentUser.ID);

    vm.isModerator = function (moderatorID) {
        if (moderatorID == currentUser.ID) {
            return true;
        }
        else {
            return false;
        }
    };

    vm.joinEvent = function (eventID) {
        //Session
    };
    
    vm.activateEvent = function (eventID) {
        eventService.activateEvent(eventService.getEvent(eventID));
    };

};