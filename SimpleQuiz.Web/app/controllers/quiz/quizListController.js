'use strict';

quizApp.controller("QuizListController", function ($scope, $modal, quizService, packageService, toaster, $routeParams, $location, $controller) {

    $controller("ListControllerBase", { $scope: $scope });

    init();

    function init() {
        $scope.packageId = $routeParams.packageId;
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
            templateUrl: $scope.getModalTemplateUrl("quiz", "edit"),
            controller: $scope.getModalControllerName("quiz", "edit"),
            resolve: {
                quiz: function () { return item; }
            }
        });
    }

    $scope.openDeleteModal = function (item) {
        var modalInstance = $modal.open({
            templateUrl: $scope.getModalTemplateUrl("quiz", "delete"),
            controller: $scope.getModalControllerName("quiz", "delete"),
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
            templateUrl: $scope.getModalTemplateUrl("quiz", "add"),
            controller: $scope.getModalControllerName("quiz", "add"),
            resolve: {
                packageId: function () { return packageId; }
            }
        });

        modalInstance.result.then(function () {
            getQuizes();
        });
    }

    $scope.details = function (item) {
        $location.path("/admin/questions/" + item.Id);
    }

});