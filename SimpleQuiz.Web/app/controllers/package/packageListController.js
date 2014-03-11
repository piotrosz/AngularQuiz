'use strict';

quizApp.controller("PackageListController", function ($scope, packageService, $modal, toaster, $location, $controller) {

    $controller("ListControllerBase", { $scope: $scope });

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
        packageService.query({ searchPhrase: $scope.searchPhrase, pageSize: $scope.pageSize, offset: offset },
            function (result) {
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
            templateUrl: $scope.getModalTemplateUrl("package", "edit"),
            controller: $scope.getModalControllerName("package", "edit"),
            resolve: {
                quizPackage: function () { return item; }
            }
        });
    }

    $scope.openDeleteModal = function (item) {
        var modalInstance = $modal.open({
            templateUrl: $scope.getModalTemplateUrl("package", "delete"),
            controller: $scope.getModalControllerName("package", "delete"),
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
            templateUrl: $scope.getModalTemplateUrl("package", "add"),
            controller: $scope.getModalControllerName("package", "add")
        });

        modalInstance.result.then(function () {
            $scope.currentPage = 1;
            getPackages();
        });
    }

    $scope.details = function (item) {
        $location.path("/admin/quizes/" + item.Id);
    }
});
