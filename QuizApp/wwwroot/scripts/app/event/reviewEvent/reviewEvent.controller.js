'use strict';

angular.module('app').controller('reviewEventController', ReviewEventController);

ReviewEventController.$inject = ['$state', 'stateParams', 'eventService'];

function ReviewEventController($state, $stateParams, eventService) {
    var vm = this;

    eventService.getEvent($stateParams.id)
    .then(function (result) {
        vm.event = result.data;

        vm.questionsToReview = vm.event.Questions.filter(question => (question.Type == 2 || question.Type == 3));
    });
}