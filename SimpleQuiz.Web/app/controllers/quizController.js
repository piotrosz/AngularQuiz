'use strict';

quizApp.controller("QuizController", function ($scope, quizService, quizPackageService, toaster, $routeParams) {

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
            function () { })
    }

    function getQuizes() {

    }

});