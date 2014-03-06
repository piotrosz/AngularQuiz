'use strict';

quizApp.controller("QuizAddController", function ($scope, $controller, $modalInstance, quizService, packageId, toaster, $log) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance, toaster: toaster, $log: $log });

    $scope.quiz = {};

    $scope.add = function () {
        quizService.add({ Name: $scope.quiz.Name, QuizPackageId: packageId },
            function (result) {
                toaster.pop('success', "Added successfully", "Quiz has been added.");
                $modalInstance.close();
            },
            function (result) {
                toaster.pop('error', "Failed to add", "Something went wrong while adding.");

                $scope.logError(result);
            });
    };
})