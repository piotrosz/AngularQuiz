'use strict';

quizApp.controller("QuizEditController", function ($scope, $controller, $modalInstance, quiz, quizService, toaster) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance });

    $scope.quiz = quiz;

    $scope.save = function () {
        quizService.save($scope.quiz,
            function (item) {
                toaster.pop('success', "Updated successfully", "Quiz " + item.Name + " was updated successfully.");
                $modalInstance.close();
            },
            function (item) {
                toaster.pop('error', "Failed to save", "Something went wrong while saving " + item.Name + ".");
            });
    };
})