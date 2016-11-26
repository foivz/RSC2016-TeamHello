'use strict';

angular.module('app').config(GetTeamStateProvider);

GetTeamStateProvider.$inject = ['$stateProvider'];

function GetTeamStateProvider($stateProvider) {
    $stateProvider
    .state('getTeam', {
        url: '/getTeam/{id}',
        templateUrl: '/./../../scripts/app/team/getTeam/getTeam.template.html',
        controller: 'getTeamController',
        controllerAs: 'vm'
    });
};