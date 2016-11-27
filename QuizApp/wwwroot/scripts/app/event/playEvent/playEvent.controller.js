'use strict';

angular.module('app').controller('playEventController', PlayEventController);

PlayEventController.$inject = ['eventService', '$stateParams'];

function PlayEventController(eventService, $stateParams) {
    var vm = this;

    var userID = userService.getUserId();

    eventService.getEvent($stateParams.token)
    .then(function (result) {
        vm.event = result.data;
        console.log(vm.event);

        vm.questionNumber = 1;

        vm.secondsLeft = 15;

        var interval = setInterval(function () {
            vm.secondsLeft--;
            if (vm.secondsLeft == 0) {
                vm.secondsLeft = 15;
                vm.questionNumber++;
                if (vm.questionNumber == vm.event.questions.Count()) {
                    clearInterval(interval);
                }
            }
        }, 1000);
    });

    vm.answer = function(question, answer){
        if (answer.isCorrect) {
            var userAnswer = {
                IsCorrect: true,
                QuestionId: question.id,
                UserId: userID
            }
        }
    };
};