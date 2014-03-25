'use strict';

quizApp.controller("PackageAddController", function ($scope, $controller, packageService, modalService, $modalInstance) {

    $scope.quizPackage = {};

    $scope.add = function () {
        packageService.add({ Name: $scope.quizPackage.Name},
            function (quizPackage) {
                modalService.showAddSuccess("Quiz package");
                $modalInstance.close();
            },
            function (quizPackage) {
                modalService.showAddError();
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})