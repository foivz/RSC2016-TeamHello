'use strict';

angular.module('app').controller('createTeamController', CreateTeamController);

CreateTeamController.$inject = ['$state','teamService'];

function CreateTeamController($state,teamServcie) {
    var vm = this;

    vm.createTeam = function () {
        teamService.createTeam(vm.teamName)
        .then(function (result) {
        vm.teamID = result.data;

        return $state.go('inviteToTeam', { id: vm.teamID });
    });
    };

};