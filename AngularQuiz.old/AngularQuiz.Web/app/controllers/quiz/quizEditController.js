'use strict';

quizApp.controller("QuizEditController", function ($scope, $controller, quiz, quizService, modalService, $modalInstance) {

    $scope.quiz = quiz;

    $scope.save = function () {
        quizService.save($scope.quiz,
            function (quiz) {
                modalService.showSaveSuccess("quiz", quiz.Name);
                $modalInstance.close();
            },
            function (quiz) {
                modalService.showSaveError("quiz", quiz.Name);
            });
    };


    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
})