'use strict';

quizApp.controller("QuestionListController", function ($scope, quizService, toaster, $routeParams, $modal, $controller) {

    $controller("ListControllerBase", { $scope: $scope });

    init();

    function init()
    {
        $scope.quizId = $routeParams.quizId;

        getQuiz();
    }

    function getQuiz()
    {
        quizService.get($scope.quizId,
            function (result) {
                $scope.quiz = result;

                $scope.areOpenQuestionsCollapsed = true;
                $scope.areTestQuestionsCollapsed = true;
                $scope.areCategoryQuestionsCollapsed = true;
                $scope.areSortQuestionsCollapsed = true;
            },
            function (result) {

            });
    }

    $scope.openAddModal = function(questionType)
    {
        var modalInstance = $modal.open({
            templateUrl: $scope.getModalTemplateUrl("question/" + questionType, "add"),
            controller: $scope.getModalControllerName(questionType + "Question", "add"),
            resolve: {
                quizId: function () { return $scope.quizId; }
            }
        });

        modalInstance.result.then(function () {
            getQuiz();
        });
    }

    $scope.openEditModal = function(questionType, question)
    {
        var modalInstance = $modal.open({
            templateUrl: $scope.getModalTemplateUrl("question/" + questionType, "edit"),
            controller: $scope.getModalControllerName(questionType + "Question", "add"),
            resolve: {
                question: function () { return question; }
            }
        });
    }

    $scope.openDeleteModal = function(questionType, question)
    {
        var modalInstance = $modal.open({
            templateUrl: $scope.getModalTemplateUrl("question/" + questionType, "delete"),
            controller: $scope.getModalControllerName(questionType + "Question", "delete"),
            resolve: {
                question: function () { return question; }
            }
        });

        modalInstance.result.then(function () {
            getQuiz();
        }, function () {
            // Do nothing when dismissed 
        });
    }
});