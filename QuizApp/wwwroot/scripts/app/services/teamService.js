'use strict';

angular.module('app').factory('teamService', TeamService);

TeamService.$inject = ['$http'];

function TeamService($http) {

    function createTeam(team) {
        return $http.post('api/teams/crate', team);
    }

    function getTeam(id) {
        return $http.get('api/teams/get'+ id);
    }

    function getTeams() {
        return $http.get('api/teams/getAll');
    }

    function joinTeam(data) {
        return $http.post('api/teams/join/'+data.token+'/'+data.id);
    }

    return {
        createTeam: createTeam,
        getTeam: getTeam,
        getTeams: getTeams,
        joinTeam: joinTeam
    };
};