'use strict';

quizApp.controller("OpenQuestionController", function ($scope, $controller, questionService, question, view, modalService, $modalInstance) {

    $scope.question = question;

    var questionType = "open";
    var questionTypeName = "Open question";

    $scope.currentOrderId = 1;
    $scope.view = view;

    $scope.add = function () {
        questionService.add(questionType, $scope.question,
            function (result) {
                modalService.showAddSuccess(questionTypeName);
                $modalInstance.close();
            },
            function (result) {
                modalService.showAddError(questionTypeName);
            });
    };

    $scope.save = function () {
        questionService.save(questionType, $scope.question,
            function (item) {
                modalService.showSaveSuccess(questionTypeName);
                $modalInstance.close();
            },
            function (item) {
                modalService.showSaveError(questionTypeName);
            });
    };

    $scope.delete = function () {
        questionService.delete(questionType, $scope.question,
            function (question) {
                modalService.showDeleteSuccess(questionTypeName);
                $modalInstance.close();
            },
            function (item) {
                modalService.showDeleteError(questionTypeName);
            });
    };

    $scope.addAnswer = function () {
        $scope.currentOrderId++;
        $scope.question.Answers.push({ OrderId: $scope.currentOrderId, CorrectAnswerOptions: [{ Content: "" }] });
    };

    $scope.deleteAnswer = function (form) {

        if ($scope.question.Answers.length > 1) {
            $scope.currentOrderId--;
            $scope.question.Answers.pop();
            form.$setDirty();
        }
    };

    $scope.addOption = function (answer) {
        answer.CorrectAnswerOptions.push({ Content: "" });
    };

    $scope.deleteOption = function (answer, form) {
        if (answer.CorrectAnswerOptions.length > 1) {
            answer.CorrectAnswerOptions.pop();
            form.$setDirty();
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})