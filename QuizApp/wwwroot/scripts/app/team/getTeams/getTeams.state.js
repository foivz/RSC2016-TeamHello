'use strict';

angular.module('app').config(GetTeamsStateProvider);

GetTeamsStateProvider.$inject = ['$stateProvider'];

function GetTeamsStateProvider($stateProvider) {
    $stateProvider
    .state('getTeams', {
        url: '/getTeams',
        templateUrl: '/./../../scripts/app/team/getTeams/getTeams.template.html',
        controller: 'getTeamsController',
        controllerAs: 'vm'
    });
};