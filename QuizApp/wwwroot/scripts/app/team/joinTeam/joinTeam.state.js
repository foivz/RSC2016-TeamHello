'use strict';

angular.module('app').config(JoinTeamStateProvider);

JoinTeamStateProvider.$inject = ['$stateProvider'];

function JoinTeamStateProvider($stateProvider) {
    $stateProvider
    .state('joinTeam', {
        url: '/join/{token}',
        templateUrl: '/./../../scripts/app/team/joinTeam/joinTeam.template.html',
        controller: 'joinTeamController',
        controllerAs: 'vm'
    });
};