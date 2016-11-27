'use strict';

angular.module('app').config(InviteToTeamStateProvider);

InviteToTeamStateProvider.$inject = ['$stateProvider'];

function InviteToTeamStateProvider($stateProvider) {
    $stateProvider
    .state('inviteToTeam', {
        url: '/inviteToTeam/{id}',
        templateUrl: '/./../../scripts/app/team/inviteToTeam/inviteToTeam.template.html',
        controller: 'inviteToTeamController',
        controllerAs: 'vm'
    });
};