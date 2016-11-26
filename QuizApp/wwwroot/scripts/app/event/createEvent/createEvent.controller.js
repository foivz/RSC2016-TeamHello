'use strict';

angular.module('app').controller('createEventController', CreateEventController);

CreateEventController.$inject = ['$state', 'eventService', 'loginService'];

function CreateEventController($state, eventService, loginService) {
    var vm = this;

    vm.event = {};
    vm.questions = [];

    vm.createEvent = function () {
        event.ModeratorID = loginService.getCurrentUser();

        vm.questions.forEach(question => {
            if (question.Type == 2 || question.Type == 3) {
                question.Answers.forEach(answer => answer.IsCorrect = true)
            }
        });

        eventService.createEvent(vm.event)
        .then(function (result) {
            var eventID = result.data;

            return $state.go('getEvent', { id: eventID });
        });
    }

    vm.addQuestionField = function () {
        vm.questions.push({});
        vm.questions[vm.questions.length() - 1].Answers = [];
    }

    vm.addAnswerField = function (question) {
        question.Answers.push({});
        question.Answers[question.Answers.length() - 1] = {};
    }
};