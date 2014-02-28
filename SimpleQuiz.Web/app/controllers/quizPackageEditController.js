'use strict';

quizApp.controller("QuizPackageEditController", function ($scope, $modalInstance, quizPackage, quizPackageService, toaster) {

    $scope.quizPackage = quizPackage;

    $scope.save = function () {
        quizPackageService.save($scope.quizPackage,
            function (arg1) {
                toaster.pop('success', "Saved successfully", "Quiz package has been updated.");
                $modalInstance.close();
            }, 
            function (arg1) {
                toaster.pop('error', "Failed to save", "Something went wrong while saving.");
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    };
})