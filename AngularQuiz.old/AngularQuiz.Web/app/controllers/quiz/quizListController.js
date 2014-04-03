'use strict';

quizApp.controller("QuizListController", function ($scope, $modal, quizService, packageService, toaster, $stateParams, $location, $controller, modalService) {

    init();

    function init() {
        $scope.packageId = $stateParams.packageId;
        getQuizPackage();
        getQuizes();
    }

    function getQuizPackage()
    {
        packageService.get($scope.packageId,
            function (result) {
                $scope.quizPackage = result;
            },
            function (result) {
                toaster.pop("Error", "Cannot get quiz package")
            });
    }

    function getQuizes() {
        quizService.query($scope.packageId,
            function (result) {
                $scope.quizes = result;
        },
        function (result) {
        });
    }

    $scope.openEditModal = function (item) {
        var modalInstance = $modal.open({
            templateUrl: modalService.getModalTemplateUrl("quiz", "edit"),
            controller: modalService.getModalControllerName("quiz", "edit"),
            resolve: {
                quiz: function () { return item; }
            }
        });
    }

    $scope.openDeleteModal = function (item) {
        var modalInstance = $modal.open({
            templateUrl: modalService.getModalTemplateUrl("quiz", "delete"),
            controller: modalService.getModalControllerName("quiz", "delete"),
            resolve: {
                quiz: function () { return item; }
            }
        });

        modalInstance.result.then(function () {
            getQuizes();
        }, function () {
            // Do nothing when dismissed 
        });
    }

    $scope.openAddModal = function (packageId) {
        var modalInstance = $modal.open({
            templateUrl: modalService.getModalTemplateUrl("quiz", "add"),
            controller: modalService.getModalControllerName("quiz", "add"),
            resolve: {
                packageId: function () { return packageId; }
            }
        });

        modalInstance.result.then(function () {
            getQuizes();
        });
    }
});