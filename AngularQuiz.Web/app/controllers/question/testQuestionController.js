'use strict';

quizApp.controller("TestQuestionController", function ($scope, $controller, questionService, dataService, question, view, modalService, $modalInstance) {

    var questionType = "test";
    var questionTypeName = "Test question";
    
    init();

    function init()
    {
        $scope.question = question;
        $scope.view = view;

        angular.forEach($scope.question.Answers, function(value, key) {
            value.State = "Edited";
        });
    }

    $scope.deletedAnswers = [];

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

        // Update question options
        angular.forEach(_.where($scope.question.Answers, { State: "Edited" }),
            function (value, key) {
                dataService.update("TestQuestionOption", value).error(function (error) {
                    modalService.showSaveError("Question option");
                });
            });

        // Delete question options
        angular.forEach($scope.deletedAnswers, function (value, key) {
            dataService.delete("TestQuestionOption", value.Id).error(function (error) {
                modalService.showDeleteError("Question option");
            });
        });

        // Insert question options
        angular.forEach(_.where($scope.question.Answers, { State: "New" }),
            function (value, key) {
                dataService.insert("TestQuestionOption", value).error(function (error) {
                    modalService.showAddError("Question options");
                });
            });


        // Update question
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
        $scope.question.Answers.push({ Content: "", TestQuestionId: $scope.question.Id, IsCorrect: false, State: "New" });
    };

    $scope.deleteOption = function (form) {
        if ($scope.question.Answers.length > 1) {
            var removedItem = $scope.question.Answers.pop();
            $scope.deletedAnswers.push(removedItem);
            form.$setDirty();
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})