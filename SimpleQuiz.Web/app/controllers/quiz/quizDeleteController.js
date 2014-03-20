'use strict';

quizApp.controller("QuizDeleteController", function ($scope, $controller, quiz, quizService, modalService, $modalInstance) {

    $scope.quiz = quiz;

    $scope.delete = function () {
        quizService.delete($scope.quiz,
            function (item) {
                modalService.showDeleteSuccess("Quiz", quiz.Name);
                $modalInstance.close();
            },
            function (item) {
                modalService.showDeleteError(quiz.Name);
            });
    };


    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    }
});