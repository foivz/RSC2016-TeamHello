'use strict';

angular.module('app').controller('myEventsController', MyEventsController);

MyEventsController.$inject = ['$state','eventService','$stateParams'];

function MyEventsController($state, eventService, $stateParams) {
    var vm = this;

    eventService.getFutureEventsByUser($stateParams.userId)
    .then(function (result) {
        vm.futureEvents = result.data;
        console.log(vm.futureEvents);
    });

    vm.isModerator = function (moderatorID) {
        if (moderatorID == $stateParams.userId) {
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