'use strict';

quizApp.controller("QuestionListController", function ($scope, quizService, toaster, $routeParams, $modal, $controller, modalService) {

    init();

    function init()
    {
        $scope.quizId = $routeParams.quizId;

        getQuiz(true);
    }

    function getQuiz(expandAll)
    {
        quizService.get($scope.quizId,
            function (result) {
                $scope.quiz = result;
                if(expandAll) {
                    expandAll();
                }
            },
            function (result) {

            });
    }

    function expandAll()
    {
        $scope.areOpenQuestionsCollapsed = true;
        $scope.areTestQuestionsCollapsed = true;
        $scope.areCategoryQuestionsCollapsed = true;
        $scope.areSortQuestionsCollapsed = true;
    }

    $scope.openAddModal = function(questionType)
    {
        var modalInstance = $modal.open({
            templateUrl: modalService.getModalTemplateUrl("question/" + questionType, "add"),
            controller: modalService.getModalControllerName(questionType + "Question", "add"),
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
            templateUrl: modalService.getModalTemplateUrl("question/" + questionType, "edit"),
            controller: modalService.getModalControllerName(questionType + "Question", "edit"),
            resolve: {
                question: function () { return question; }
            }
        });
    }

    $scope.openDeleteModal = function(questionType, question)
    {
        var modalInstance = $modal.open({
            templateUrl: modalService.getModalTemplateUrl("question/" + questionType, "delete"),
            controller: modalService.getModalControllerName(questionType + "Question", "delete"),
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