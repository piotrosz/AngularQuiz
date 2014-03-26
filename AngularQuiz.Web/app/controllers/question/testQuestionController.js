'use strict';

quizApp.controller("TestQuestionController", function ($scope, $controller, questionService, question, view, modalService, $modalInstance) {

    var questionType = "test";
    var questionTypeName = "Test question";

    $scope.question = question;
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


    $scope.addOption = function () {
        $scope.question.Answers.push({ Content: "", IsCorrect: false });
    };

    $scope.deleteOption = function () {
        if ($scope.question.Answers.length > 1) {
            $scope.question.Answers.pop();
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})