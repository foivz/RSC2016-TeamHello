'use strict';

angular.module('app').controller('getTeamController', GetTeamController);

GetTeamController.$inject = ['$state','teamService','$stateParams'];

function GetTeamController($state, teamService, $stateParams) {
    var vm = this;

    teamService.getTeam($stateParams.id)
    .then(function (result) {
        vm.team = result.data;
    });
    
    
};

