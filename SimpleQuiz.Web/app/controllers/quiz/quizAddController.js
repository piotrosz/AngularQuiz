'use strict';

quizApp.controller("QuizAddController", function ($scope, $controller, quizService, packageId, modalService, $modalInstance) {

    $scope.quiz = { View: "Standard" };

    $scope.add = function () {
        quizService.add({ Name: $scope.quiz.Name, View: $scope.quiz.View, QuizPackageId: packageId },
            function (result) {
                modalService.showAddSuccess("Quiz");
                $modalInstance.close();
            },
            function (result) {
                modalService.showAddError("Quiz");
            });
    };


    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})