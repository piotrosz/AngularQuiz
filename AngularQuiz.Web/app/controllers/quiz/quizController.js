quizApp.controller("QuizController", function ($scope, quizService, $routeParams, $filter, $location) {

    init();
    
    function init() {
        $scope.quizId = $routeParams.quizId;
        $scope.currentQuestion = {};

        if ($routeParams.questionIndex != undefined) {
            $scope.questionIndex = parseInt($routeParams.questionIndex);
        }
        else {
            $scope.questionIndex = 0;
        }

        $scope.quiz = {};
        $scope.userAnswers =
            {
                OpenQuestionsAnswers: [],
                TestQuestionsAnswers: [],
                SortQuestionsAnswers: [],
                CategoryQuestionsAnswers: []
            };


        quizService.get($scope.quizId, function (quiz) {
            $scope.quiz = quiz;

            $scope.currentQuestion = $filter('orderBy')($scope.quiz.AllQuestions, "OrderId")[$scope.questionIndex];
        });

        $scope.quiz
    }

    $scope.prevQuestion = function () {
        if ($scope.questionIndex > 0) {
            $scope.questionIndex--;
            $location.path("/quiz/" + $scope.quizId + "/" + $scope.questionIndex);
        }
    }

    $scope.nextQuestion = function () {
        if ($scope.questionIndex < $scope.quiz.QuestionCount - 1) {
            $scope.questionIndex++;
            $location.path("/quiz/" + $scope.quizId + "/" + $scope.questionIndex);
        }
    }

    $scope.checkAnswers = function () {
    }
});