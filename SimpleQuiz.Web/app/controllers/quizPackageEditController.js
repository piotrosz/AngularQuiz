'use strict';

quizApp.controller("QuizPackageEditController", function ($scope, $modalInstance, quizPackage, quizPackageService, toaster) {

    $scope.quizPackage = quizPackage;

    $scope.save = function () {
        quizPackageService.save($scope.quizPackage,
            function (item) {
                toaster.pop('success', "Updated successfully", "Package " + item.Name + " was updated successfully.");
                $modalInstance.close();
            }, 
            function (item) {
                toaster.pop('error', "Failed to save", "Something went wrong while saving " + item.Name + ".");
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    };
})