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

                $scope.areOpenQuestionsCollapsed = true;
                $scope.areTestQuestionsCollapsed = true;
                $scope.areCategoryQuestionsCollapsed = true;
                $scope.areSortQuestionsCollapsed = true;
            },
            function (result) {

            });
    }

});