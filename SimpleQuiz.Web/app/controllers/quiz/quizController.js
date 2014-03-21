quizApp.controller("QuizController", function ($scope, quizService, $routeParams) {

    init();

    function init()
    {
        $scope.quizId = $routeParams.quizId;

        quizService.get()

        $scope.quiz
    }

    $scope.prevQuestion = function()
    {
    }

    $scope.nextQuestion = function()
    {
    }
});