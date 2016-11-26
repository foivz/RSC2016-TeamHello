'use strict';

angular.module('app').factory('questionService', QuestionService);

QuestionService.$inject = ['$http', 'loginService'];

function QuestionService($http, loginService) {

    $http.defaults.headers.common['Authorization'] = loginService.getCurrentToken();

    function createQuestionsWithAnswers(questions) {
        return $http.post('/api/questions/create', questions);
    };

    function getQuestion(id) {
        return $http.get('api/questions/get/' + id);
    };

    function getQuestions() {
        return $http.get('api/questions/getAll');
    };

    return {
        createQuestionsWithAnswers: createQuestionsWithAnswers,
        getQuestion: getQuestion,
        getQuestions: getQuestions,
    };
};