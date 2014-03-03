'use strict';

quizApp.controller("QuizPackagesController", function ($scope, quizPackageService, $modal, toaster, $location) {
    $scope.searchPhrase = null;

    // paging 
    $scope.totalCount = 0;
    $scope.pageSize = 10;
    $scope.currentPage = 1;

    init();

    function init() {
        getPackages();
    }

    function getPackages() {
        var offset = ($scope.pageSize) * ($scope.currentPage - 1);
        quizPackageService.query({ searchPhrase: $scope.searchPhrase, pageSize: $scope.pageSize, offset: offset }, function (result) {

            $scope.totalCount = result.TotalCount;
            $scope.packages = result.List;

        },
        function (err) {
            toaster.pop("error", "Fetch error", "Failed to get quiz packages");
        });
    }

    $scope.search = function () {
        $scope.currentPage = 1;
        getPackages();
    }

    $scope.pageChanged = function (page) {
        $scope.currentPage = page;
        getPackages();
    }

    $scope.openEditModal = function (item) {
        var modalInstance = $modal.open({
            templateUrl: "app/views/packageEdit.html",
            controller: "QuizPackageEditController",
            resolve: {
                quizPackage: function () { return item; }
            }
        });
    }

    $scope.openDeleteModal = function (item) {
        var modalInstance = $modal.open({
            templateUrl: "app/views/packageDelete.html",
            controller: "QuizPackageDeleteController",
            resolve: {
                quizPackage: function () { return item; }
            }
        });

        modalInstance.result.then(function () {
            $scope.currentPage = 1;
            getPackages();
        }, function () {
            // Do nothing when dismissed 
        });
   }

    $scope.openAddModal = function()
    {
        var modalInstance = $modal.open({
            templateUrl: "app/views/packageAdd.html",
            controller: "QuizPackageAddController"
        });

        modalInstance.result.then(function () {
            $scope.currentPage = 1;
            getPackages();
        });
    }

    $scope.details = function (item) {
        $location.path("/quizes/" + item.Id);
    }
});
