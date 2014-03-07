'use strict';

quizApp.controller("QuizQuestionsController", function ($scope, quizService, toaster) {

    init();

    function init()
    {
        $scope.areOpenQuestionsCollapsed = true;
        $scope.areTestQuestionsCollapsed = true;
        $scope.areCategoryQuestionsCollapsed = false;
        $scope.areSortQuestionsCollapsed = false;

        //$scope.quiz = quizService.get();
    }

});