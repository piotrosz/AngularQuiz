quizApp.controller("QuizController", function ($scope, quizService, $routeParams, $filter) {

    init();

    function init() {
        $scope.quizId = $routeParams.quizId;
        $scope.currentQuestion = {};
        $scope.currentQuestionIndex = 0;
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

            if (quiz.TestQuestions.length > 0) {
                $scope.currentQuestion = $filter('orderBy')(quiz.TestQuestions, "OrderId")[0];
            }
            else if (quiz.OpenQuestions.length > 0) {
                $scope.currentQuestion = quiz.OpenQuestions[0];
            }
            else if (quiz.SortQuestions.length > 0) {
                $scope.currentQuestion = quiz.SortQuestions[0];
            }
            else if (quiz.CategoryQuestions, length > 0) {
                $scope.currentQuestion = quiz.CategoryQuestions[0];
            }
            
            
        });

        $scope.quiz
    }

    $scope.testQuestionHasManyAnswers = function (question) {
        return _.filter(question.Answers, function (o) { return o.IsCorrect }).length > 1;
    }

    $scope.prevQuestion = function () {

    }

    $scope.nextQuestion = function () {

        // TODO: Save users answers

        $scope.userAnswers.TestQuestionsAnswers.push({ QuestionId: $scope.currentQuestion.Id, Answers: [] });

        // TODO: Get next question


    }

    $scope.showResults = function () {

    }

    $scope.checkAnswers = function () {

    }
});