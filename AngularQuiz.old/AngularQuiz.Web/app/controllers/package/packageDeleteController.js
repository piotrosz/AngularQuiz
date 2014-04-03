'use strict';

quizApp.controller("PackageDeleteController", function ($scope, $controller, quizPackage, packageService, modalService, $modalInstance) {

    $scope.quizPackage = quizPackage;

    $scope.delete = function () {
        packageService.delete($scope.quizPackage,
            function (quizPackage) {
                modalService.showDeleteSuccess("Quiz package", quizPackage.Name);
                $modalInstance.close();
            },
            function (quizPackage) {
                modalService.showDeleteError(quizPackage.Name);
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
});