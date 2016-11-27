'use strict';

angular.module('app').config(CreateTeamStateProvider);

CreateTeamStateProvider.$inject = ['$stateProvider'];

function CreateTeamStateProvider($stateProvider) {
    $stateProvider
    .state('createTeam', {
        url: '/createTeam/{userid}',
        templateUrl: '/./../../scripts/app/team/createTeam/createTeam.template.html',
        controller: 'createTeamController',
        controllerAs: 'vm'
    });
};