'use strict';

quizApp.controller("QuizController", function ($scope, $modal, quizService, quizPackageService, toaster, $routeParams) {

    init();

    function init() {
        $scope.packageId = $routeParams.packageId;
        getQuizPackage();
        getQuizes();
    }

    function getQuizPackage()
    {
        quizPackageService.get($scope.packageId, function (result) {
            $scope.quizPackage = result;
        },
            function () { });
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
            templateUrl: "app/views/quizEdit.html",
            controller: "QuizEditController",
            resolve: {
                quiz: function () { return item; }
            }
        });
    }

    $scope.openDeleteModal = function (item) {
        var modalInstance = $modal.open({
            templateUrl: "app/views/quizDelete.html",
            controller: "QuizDeleteController",
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
            templateUrl: "app/views/quizAdd.html",
            controller: "QuizAddController",
            resolve: {
                packageId: function () { return packageId; }
            }
        });

        modalInstance.result.then(function () {
            getQuizes();
        });
    }

    $scope.details = function (item) {
        $location.path("/questions/" + item.Id);
    }

});