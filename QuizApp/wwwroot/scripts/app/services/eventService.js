﻿'use strict';

angular.module('app').factory('eventService', EventService);

EventService.$inject = ['$http', 'loginService'];

function EventService($http, loginService) {

    $http.defaults.headers.common['Authorization'] = loginService.getCurrentToken();

    function createEvent(event) {
        return $http.post('/api/events/create', event);
    };

    function editEvent(event) {
        return $http.post('/api/events/edit/' + event.ID, event);
    };

    function getEvent(id) {
        return $http.get('api/events/get/' + id);
    };

    function getEvents() {
        return $http.get('api/events/getAll');
    };

    function getActiveEvents() {
        return $http.get('api/events/getActive');
    };

    function getEventsByMod(id) {
        return $http.get('api/events/getByMod/' + id);
    };

    function getPastEventsByMod(id) {
        return $http.get('api/events/getPastByMod/' + id);
    };

    function getFutureEventsByMod(id) {
        return $http.get('api/events/getFutureByMod/' + id);
    };

    function activateEvent(event) {
        event.IsActive = true;
        editEvent(event);
    };

    function deactivateEvent(event) {
        event.IsActive = false;
        editEvent(event);
    };

    function searchEventsByName(events, query) {
        var filtered = events.filter(event => event.Name.toUpperCase().indexOf(query.toUpperCase()) !== -1);
        return filtered;
    };

    return {
        createEvent: createEvent,
        editEvent: editEvent,
        getEvent: getEvent,
        getEvents: getEvents,
        getActiveEvents: getActiveEvents,
        getEventsByMod: getEventsByMod,
        getPastEventsByMod: getPastEventsByMod,
        getFutureEventsByMod: getFutureEventsByMod,
        activateEvent: activateEvent,
        deactivateEvent: deactivateEvent,
        searchEventsByName: searchEventsByName
    };
};