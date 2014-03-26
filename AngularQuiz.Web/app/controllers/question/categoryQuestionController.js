'use strict';

quizApp.controller("CategoryQuestionController", function ($scope, $controller, questionService, question, modalService, $modalInstance) {

    var questionType = "category";
    var questionTypeName = "Category question"

    $scope.currentOrderId = 1;

    $scope.question = question;

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

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }

    $scope.addAnswer = function() {
        $scope.currentOrderId++;
        $scope.question.Answers.push({ OrderId: $scope.currentOrderId, Content: "" });
    }

    $scope.deleteAnswer = function () {
        if ($scope.question.Answers.length > 1) {
            $scope.currentOrderId--;
            $scope.question.Answers.pop();
        }
    }
})