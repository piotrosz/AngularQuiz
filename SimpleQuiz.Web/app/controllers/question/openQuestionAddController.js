'use strict';

quizApp.controller("OpenQuestionAddController", function ($scope, $controller, questionService, $log, quizId, modalService, $modalInstance) {

    $scope.question = {
        QuizId: quizId,
        Content: "",
        CorrectAnswers:
            [
                { OrderId: 1, CorrectAnswerOptions: [{ Content: "" }] }
            ]
    };

    $scope.currentOrderId = 1;

    $scope.add = function () {
        questionService.add('open', $scope.question,
            function (result) {
                modalService.showAddSuccess("Open question");
                $modalInstance.close();
            },
            function (result) {
                modalService.showAddError("Open question");
            });
    };

    $scope.addAnswer = function () {
        $scope.currentOrderId++;
        $scope.question.CorrectAnswers.push({ OrderId: $scope.currentOrderId, CorrectAnswerOptions: [{ Content: "" }] });
    };

    $scope.deleteAnswer = function () {

        if ($scope.question.CorrectAnswers.length > 1) {
            $scope.currentOrderId--;
            $scope.question.CorrectAnswers.pop();
        }
    };

    $scope.addOption = function (answer) {
        answer.CorrectAnswerOptions.push({ Content: "" });
    };

    $scope.deleteOption = function (answer) {
        if (answer.CorrectAnswerOptions.length > 1) {
            answer.CorrectAnswerOptions.pop();
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})