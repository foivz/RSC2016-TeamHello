'use strict';

angular.module('app').controller('joinTeamController', JoinTeamController);

JoinTeamController.$inject = ['$state','teamService', 'loginService','$stateParams'];

function JoinTeamController($state, teamService, loginService, $stateParams) {
    var vm = this;

    vm.user = loginService.getCurrentUser();

    if(vm.user)
    {
        teamService.joinTeam({id: vm.user.ID,token: $stateParams.token})
        .then(function (result) {
        $state.go("home");
        });
    }
    else
    {
        $state.go('login', { teamToken: $stateParams.token});
    }

};

