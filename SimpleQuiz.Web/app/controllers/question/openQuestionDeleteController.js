'use strict';

quizApp.controller("OpenQuestionDeleteController", function ($scope, $controller, question, questionService, modalService, $modalInstance) {

    $scope.question = question;

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


    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
});