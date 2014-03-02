'use strict';

quizApp.controller("QuizPackageDeleteController", function ($scope, $modalInstance, quizPackage, quizPackageService, toaster) {

    $scope.quizPackage = quizPackage;

    $scope.delete = function () {
        quizPackageService.delete($scope.quizPackage,
            function (arg1) {
                toaster.pop('success', "Deleted successfully", "Quiz package has been deleted.");
                $modalInstance.close();
            },
            function (arg1) {
                toaster.pop('error', "Failed to delete", "Something went wrong while deleting.");
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    };
});