'use strict';

angular.module('app').factory('teamService', TeamService);

TeamService.$inject = ['$http'];

function TeamService($http) {

    function createTeam(team) {
        return $http.post('api/url', team); // add API URL
    };

    function getTeam(id) {
        return $http.get('api/url'+ id); // add API URL
    };

    function getTeams() {
        return $http.get('api/url'); // add API URL
    };

    function joinTeam(data) {
        return $http.post('api/url',data); // add API URL
    };

    return {
        createTeam: createTeam,
        getTeam: getTeam,
        getTeams: getTeams,
        joinTeam: joinTeam
    };
};