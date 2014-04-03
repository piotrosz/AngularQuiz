quizApp.controller("QuizController", function ($scope, $state, quizService, $stateParams, $filter, $location) {

    init();
    
    function init() {
        $scope.quizId = $stateParams.quizId;
        $scope.currentQuestion = {};

        if ($stateParams.questionIndex != undefined) {
            $scope.questionIndex = parseInt($stateParams.questionIndex);
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
            $state.go("userquiz", { quizId: $scope.quizId, questionIndex: $scope.questionIndex});
        }
    }

    $scope.nextQuestion = function () {

        // TODO: Store answers (?)


        if ($scope.questionIndex < $scope.quiz.QuestionCount - 1) {
            $scope.questionIndex++;
            $state.go("userquiz", { quizId: $scope.quizId, questionIndex: $scope.questionIndex });
        }
    }

    $scope.checkAnswers = function () {
    }
});