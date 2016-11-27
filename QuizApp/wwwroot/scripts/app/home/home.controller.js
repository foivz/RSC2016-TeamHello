'use strict';

angular.module('app').controller('homeController', HomeController);

HomeController.$inject = ['$state', 'teamService', 'userService', 'loginService','eventService'];

function HomeController($state,eventService) {
    var vm = this;
    var eventID = eventService.getActiveEvents().data[0].ID;
    $state.go("/play-event/" + eventID);

};