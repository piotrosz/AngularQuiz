quizApp.controller("QuizController", function ($scope, quizService, $routeParams, $filter) {

    init();
    
    function init() {
        $scope.quizId = $routeParams.quizId;
        $scope.currentQuestion = {};
        $scope.currentQuestionIndex = 0;
        $scope.questionIndex = 0;
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

            $scope.currentQuestion = $filter('orderBy')(quiz.AllQuestions, "OrderId")[0];
        });

        $scope.quiz
    }

    $scope.testQuestionHasManyAnswers = function (question) {
        return _.filter(question.Answers, function (o) { return o.IsCorrect }).length > 1;
    }

    $scope.prevQuestion = function () {
        if ($scope.questionIndex > 0) {
            $scope.questionIndex--;
            setCurrentQuestion();
        }
    }

    $scope.nextQuestion = function () {

        // TODO: Save users answers
        //if ($scope.currentQuestion.QuestionType == "Test") {
        //    $scope.userAnswers.TestQuestionsAnswers.push({ QuestionId: $scope.currentQuestion.Id, Answers: [] });
        //}

        // TODO: Get next question
        if ($scope.quiz.QuestionCount > $scope.questionIndex) {
            $scope.questionIndex++;
            setCurrentQuestion();
        }
    }

    $scope.checkAnswers = function () {
        
    }

    function setCurrentQuestion() {
        $scope.currentQuestion = $filter('orderBy')($scope.quiz.AllQuestions, "OrderId")[$scope.questionIndex];
    }
});