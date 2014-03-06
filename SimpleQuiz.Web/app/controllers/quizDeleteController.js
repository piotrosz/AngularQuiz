'use strict';

quizApp.controller("QuizDeleteController", function ($scope, $controller, $modalInstance, quiz, quizService, toaster) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance });

    $scope.quiz = quiz;

    $scope.delete = function () {
        quizService.delete($scope.quiz,
            function (item) {
                toaster.pop('success', "Deleted successfully", "Quiz " + item.Name + " was deleted successfully.");
                $modalInstance.close();
            },
            function (item) {
                toaster.pop('error', "Failed to delete", "Something went wrong while deleting " + item.Name + ".");
            });
    };
});