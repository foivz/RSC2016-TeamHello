'use strict';

angular.module('app').factory('questionTypeService', QuestionTypeService);

QuestionTypeService.$inject = [];

function QuestionTypeService() {

    var questionTypes = new Enumeration({
        0: 'Single answer',
        1: 'Multiple answer',
        2: 'Manual input',
        3: 'Multiple manual input',
        4: 'Multimedia'
    });

    function getQuestionTypes() {
        return questionTypes;
    }

    function getQuestionType(id) {
        return questionTypes[id];
    }

    return {
        getQuestionTypes: getQuestionTypes,
        getQuestionType: getQuestionType
    };
}