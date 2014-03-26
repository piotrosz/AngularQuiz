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

        quizService.getForUser($scope.quizId, function (quiz) {
            $scope.quiz = quiz;

            $scope.quiz.AllQuestions = quiz.OpenQuestions.concat(quiz.TestQuestions, quiz.CategoryQuestions, quiz.SortQuestions);
            $scope.quiz.QuestionCount = $scope.quiz.AllQuestions.length;

            $scope.currentQuestion = $filter('orderBy')($scope.quiz.AllQuestions, "OrderId")[$scope.questionIndex];
        });
    }

    $scope.prevQuestion = function () {
        if ($scope.questionIndex > 0) {
            $scope.questionIndex--;
            $location.path("/quiz/" + $scope.quizId + "/" + $scope.questionIndex);
        }
    }

    $scope.nextQuestion = function () {

        // TODO: Store answers (?)


        if ($scope.questionIndex < $scope.quiz.QuestionCount - 1) {
            $scope.questionIndex++;
            $location.path("/quiz/" + $scope.quizId + "/" + $scope.questionIndex);
        }
    }

    $scope.checkAnswers = function () {
    }
});