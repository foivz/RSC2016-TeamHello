'use strict';

angular.module('app').controller('homeController', HomeController);

HomeController.$inject = ['$state','eventService'];

function HomeController($state,eventService) {
    var vm = this;
    var eventID = eventService.getActiveEvents().data[0].ID;
    vm.StartQuiz = function()
    {
        console.log("OK");
        $state.go("/play-event/" + eventID);
    }

};