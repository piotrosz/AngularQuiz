'use strict';

quizApp.controller("OpenQuestionAddController", function ($scope, $controller, $modalInstance, questionService, toaster, $log) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance, toaster: toaster, $log: $log });

    $scope.question = {
        QuizId: $scope.quizId,
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
                toaster.pop('success', "Added successfully", "Open question has been added.");
                $modalInstance.close();
            },
            function (result) {
                toaster.pop('error', "Failed to add", "Something went wrong while adding.");

                $scope.logError(result);
            });
    };

    $scope.addAnswer = function () {
        $scope.currentOrderId++;
        $scope.question.CorrectAnswers.push({ OrderId: $scope.currentOrderId, CorrectAnswerOptions: [{ Content: "" }] });
    };

    $scope.deleteAnswer = function () {

        if($scope.question.CorrectAnswers.length > 1)
        {
            $scope.currentOrderId--;
            $scope.question.CorrectAnswers.pop();
        }
    }

    $scope.addOption = function (answer) {
        answer.CorrectAnswerOptions.push({ Content: "" });
    };

    $scope.deleteOption = function (answer) {
        if (answer.CorrectAnswerOptions.length > 1)
        {
            answer.CorrectAnswerOptions.pop();
        }
    }
})