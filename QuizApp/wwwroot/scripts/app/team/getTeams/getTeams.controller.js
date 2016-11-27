'use strict';

angular.module('app').controller('getTeamsController', GetTeamsController);

GetTeamsController.$inject = ['$state', 'teamService'];

function GetTeamsController($state,teamService) {
    var vm = this;

    teamService.getTeams(function (response) {
        vm.teams = response.data;
    });
};