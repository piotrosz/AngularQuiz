'use strict';

quizApp.controller("OpenQuestionController", function ($scope, $controller, questionService, $log, question, modalService, $modalInstance) {

    $scope.question = question;

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

    $scope.save = function () {
        questionService.save('open', $scope.question,
            function (item) {
                modalService.showSaveSuccess("open question");
                $modalInstance.close();
            },
            function (item) {
                modalService.showSaveError("open question");
            });
    };

    $scope.delete = function () {
        questionService.delete('open', $scope.question,
            function (question) {
                modalService.showDeleteSuccess("Open question");
                $modalInstance.close();
            },
            function (item) {
                modalService.showDeleteError("Open question");
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