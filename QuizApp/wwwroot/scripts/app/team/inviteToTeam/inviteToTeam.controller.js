'use strict';

angular.module('app').controller('inviteToTeamController', InviteToTeamController);

InviteToTeamController.$inject = ['$state','teamService','$stateParams'];

function InviteToTeamController($state, teamService, $stateParams) {
    var vm = this;

    teamService.getTeam($stateParams.id)
    .then(function (result) {
        vm.team = result.data;
    });
   
};

