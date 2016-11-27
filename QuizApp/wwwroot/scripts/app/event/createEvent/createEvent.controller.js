'use strict';

angular.module('app').controller('createEventController', CreateEventController);

CreateEventController.$inject = ['$state', 'eventService', 'loginService', 'questionService', '$stateParams', 'questionTypeService'];

function CreateEventController($state, eventService, loginService, questionService, $stateParams, questionTypeService) {
    var vm = this;

    vm.event = {};
    vm.questions = [];

    vm.questionTypes = questionTypeService.getQuestionTypes();

    vm.createEvent = function () {
        vm.event.ModeratorID = $stateParams.userId;
        console.log(event);

        questionService.createQuestionsWithAnswers(vm.questions);

        eventService.createEvent(vm.event)
        .then(function (result) {
            var eventID = result.data;

            return $state.go('getEvent', { id: eventID });
        });
    }

    vm.addQuestionField = function () {
        vm.questions.push({});
        vm.questions[vm.questions.length - 1].EventId = vm.event.ID;
        vm.questions[vm.questions.length - 1].Answers = [];
    }

    vm.addAnswerField = function (question) {
        question.Answers.push({});
        question.Answers[question.Answers.length - 1] = {};
    }
};