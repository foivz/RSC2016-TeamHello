'use strict';

angular.module('app').config(ReviewEventStateProvider);

ReviewEventStateProvider.$inject = ['$stateProvider'];

function ReviewEventStateProvider($stateProvider) {
    $stateProvider
    .state('reviewEvent', {
        url: '/reviewEvent/{id}',
        templateUrl: '/./../../scripts/app/event/reviewEvent/reviewEvent.template.html',
        controller: 'reviewEventController',
        controllerAs: 'vm'
    });
}