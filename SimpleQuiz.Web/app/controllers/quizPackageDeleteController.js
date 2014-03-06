'use strict';

quizApp.controller("QuizPackageDeleteController", function ($scope, $controller, $modalInstance, quizPackage, quizPackageService, toaster) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance });

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
});