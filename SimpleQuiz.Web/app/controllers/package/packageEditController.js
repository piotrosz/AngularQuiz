'use strict';

quizApp.controller("PackageEditController", function ($scope, $controller, quizPackage, packageService, modalService, $modalInstance) {

    $scope.quizPackage = quizPackage;

    $scope.save = function () {
        packageService.save($scope.quizPackage,
            function (item) {
                modalService.showSaveSuccess("package", item.Name);
                $modalInstance.close();

            }, 
            function (item) {
                $scope.saveError("package", item.Name);
            });
    };

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})