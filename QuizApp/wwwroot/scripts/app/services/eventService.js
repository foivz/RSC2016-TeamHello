'use strict';

angular.module('app').factory('eventService', EventService);

EventService.$inject = ['$http', 'loginService'];

function EventService($http, loginService) {

    function createEvent(event) {
        console.log(event);
        return $http.post('/api/events/create', event);
    };

    function editEvent(event) {
        return $http.post('/api/events/edit/' + event.ID, event);
    };

    function getEvent(id) {
        console.log(id);
        return $http.get('api/events/' + id);
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

    function getFutureEventsByUser(id) {
        return $http.get('api/events/getAllFuture/' + id);
    };

    function getFutureEvents() {
        return $http.get('api/events/getFuture');
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
        getFutureEventsByUser: getFutureEventsByUser,
        activateEvent: activateEvent,
        deactivateEvent: deactivateEvent,
        searchEventsByName: searchEventsByName
    };
};