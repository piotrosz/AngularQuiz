quizApp.controller("QuizController", function ($scope, quizService, $routeParams) {

    init();

    function init() {
        $scope.quizId = $routeParams.quizId;
        $scope.currentQuestion = {};
        $scope.quiz = {};
        $scope.userAnswers = {};


        quizService.get($scope.quizId, function (quiz) {
            $scope.quiz = quiz;

            $scope.currentQuestion = quiz.TestQuestions[0];
        });

        $scope.quiz
    }

    $scope.prevQuestion = function () {

    }

    $scope.nextQuestion = function() {
    }

    $scope.showResults = function () {

    }

    $scope.checkAnswers = function () {

    }
});