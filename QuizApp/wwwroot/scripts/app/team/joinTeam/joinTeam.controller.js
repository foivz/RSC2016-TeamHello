'use strict';

angular.module('app').controller('joinTeamController', JoinTeamController);

JoinTeamController.$inject = ['$state','teamService', 'loginService','$stateParams'];

function JoinTeamController($state, teamService, loginService, $stateParams) {
    var vm = this;

    vm.a = "angularCheck";

    vm.userID = loginService.isLoggedIn();

    if(vm.userID)
    {
        teamService.joinTeam({id: vm.userID,token: $stateParams.token})
        .then(function (result) {
        $state.go("home");
        });
    }
    else
    {
        $state.go('login', { teamToken: $stateParams.token});
    }

};

