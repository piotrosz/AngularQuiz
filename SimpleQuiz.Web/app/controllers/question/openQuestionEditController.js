'use strict';

quizApp.controller("OpenQuestionEditController", function ($scope, $controller, question, questionService, modalService, $modalInstance) {

    $scope.question = question;

    $scope.save = function () {
        questionService.save('open', $scope.question,
            function (item) {
                modalService.showSaveSuccess("open question", item.Content);
                $modalInstance.close();
            },
            function (item) {
                modalService.showSaveError("open question", item.Content);
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})