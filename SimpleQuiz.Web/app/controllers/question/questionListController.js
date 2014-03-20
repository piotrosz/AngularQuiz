'use strict';

quizApp.controller("QuestionListController", function ($scope, quizService, toaster, $routeParams, $modal, $controller, modalService) {

    init();

    function init()
    {
        $scope.quizId = $routeParams.quizId;

        getQuiz(true);
    }

    function getQuiz(shouldExpandAll)
    {
        quizService.get($scope.quizId,
            function (result) {
                $scope.quiz = result;
                if(shouldExpandAll) {
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
            controller: modalService.getModalControllerName(questionType + "Question"),
            resolve: {
                question: function () { return {
                        QuizId: $scope.quizId,
                        Content: "",
                        View: "Standard",
                        CorrectAnswers:
                            [
                                { OrderId: 1, CorrectAnswerOptions: [{ Content: "" }] }
                            ]
                    }; }
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
            controller: modalService.getModalControllerName(questionType + "Question"),
            resolve: {
                question: function () { return question; }
            }
        });

        modalInstance.result.then(function () {
            getQuiz();
        });
    }

    $scope.openDeleteModal = function(questionType, question)
    {
        var modalInstance = $modal.open({
            templateUrl: modalService.getModalTemplateUrl("question/" + questionType, "delete"),
            controller: modalService.getModalControllerName(questionType + "Question"),
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