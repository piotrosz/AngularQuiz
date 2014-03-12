'use strict';

quizApp.controller("OpenQuestionAddController", function ($scope, $controller, $modalInstance, questionService, packageId, toaster, $log) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance, toaster: toaster, $log: $log });

    $scope.question = {
        Content: "",
        CorrectAnswers:
            [
                { CorrectAnswerOptions: { Content: "Content" } }
            ]
    };

    $scope.add = function () {
        questionService.add('open', { Name: $scope.quiz.Name, View: $scope.quiz.View, QuizPackageId: packageId },
            function (result) {
                toaster.pop('success', "Added successfully", "Open question has been added.");
                $modalInstance.close();
            },
            function (result) {
                toaster.pop('error', "Failed to add", "Something went wrong while adding.");

                $scope.logError(result);
            });
    };
})