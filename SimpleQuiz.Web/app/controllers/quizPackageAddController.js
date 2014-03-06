'use strict';

quizApp.controller("QuizPackageAddController", function ($scope, $controller, $modalInstance, quizPackageService, toaster) {

    $controller("ModalControllerBase", { $scope: $scope, $modalInstance: $modalInstance });

    $scope.quizPackage = {};

    $scope.add = function () {
        quizPackageService.add({ Name: $scope.quizPackage.Name},
            function (arg1) {
                toaster.pop('success', "Added successfully", "Quiz package has been added.");
                $modalInstance.close();
            },
            function (arg1) {
                toaster.pop('error', "Failed to add", "Something went wrong while adding.");
            });
    };
})