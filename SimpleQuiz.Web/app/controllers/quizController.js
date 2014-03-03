'use strict';

quizApp.controller("QuizController", function ($scope, quizService, toaster, $routeParams) {

    init();

    function init() {
        $scope.packageId = $routeParams.packageId;
        getQuizes();
    }

    function getQuizes() {

    }

});