'use strict';

quizApp.controller("QuizPackageDeleteController", function ($scope, $modalInstance, quizPackage, quizPackageService, toaster) {

    $scope.quizPackage = quizPackage;

    $scope.delete = function () {
        quizPackageService.delete($scope.quizPackage,
            function (item) {
                toaster.pop('success', "Deleted successfully", "Package " + item.Name + " was deleted successfully.");
                $modalInstance.close();
            },
            function (item) {
                toaster.pop('error', "Failed to delete", "Something went wrong while deleting " + item.Name + ".");
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    };
});