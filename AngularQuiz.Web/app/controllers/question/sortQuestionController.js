'use strict';

quizApp.controller("SortQuestionController", function ($scope, $controller, questionService, question, view, modalService, $modalInstance) {

    var questionType = "sort";
    var questionTypeName = "Sort question";

    $scope.view = view;
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
})