'use strict';

quizApp.controller("OpenQuestionDeleteController", function ($scope, $controller, $modalInstance, question, questionService, toaster) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance });

    $scope.question = question;

    $scope.delete = function () {
        questionService.delete('open', $scope.question,
            function (item) {
                toaster.pop('success', "Deleted successfully", "Question " + item.Name + " was deleted successfully.");
                $modalInstance.close();
            },
            function (item) {
                toaster.pop('error', "Failed to delete", "Something went wrong while deleting " + item.Name + ".");
            });
    };
});