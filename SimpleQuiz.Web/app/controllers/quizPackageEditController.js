'use strict';

quizApp.controller("QuizPackageEditController", function ($scope, $modalInstance, quizPackage) {

    $scope.quizPackage = quizPackage;

    $scope.save = function () {
        $modalInstance.close();
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    };
})