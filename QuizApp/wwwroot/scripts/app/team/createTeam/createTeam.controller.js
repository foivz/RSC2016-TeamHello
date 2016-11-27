'use strict';

angular.module('app').controller('createTeamController', CreateTeamController);

CreateTeamController.$inject = ['$state','teamService','userService'];

function CreateTeamController($state,teamService,userService) {
    var vm = this;

    vm.createTeam = function () {
        teamService.createTeam({ Name: vm.teamName, CaptainId: userService.getUserId() })
        .then(function (result) {
        vm.teamID = result.data.id;

        return $state.go('inviteToTeam', { id: vm.teamID });
    });
    };

};