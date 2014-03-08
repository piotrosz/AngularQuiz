'use strict';

quizApp.controller("QuizQuestionsController", function ($scope, quizService, toaster, $routeParams) {

    init();

    function init()
    {
        $scope.quizId = $routeParams.quizId;

        getQuiz();
    }

    function getQuiz()
    {
        quizService.get($scope.quizId,
            function (result) {
                $scope.quiz = result;

                $scope.areOpenQuestionsCollapsed = $scope.quiz.OpenQuestions.length == 0;
                $scope.areTestQuestionsCollapsed = $scope.quiz.TestQuestions.length == 0;
                $scope.areCategoryQuestionsCollapsed = $scope.quiz.CategoryQuestions.length == 0;
                $scope.areSortQuestionsCollapsed = $scope.quiz.SortQuestions.length == 0;
            },
            function (result) {

            });
    }

});