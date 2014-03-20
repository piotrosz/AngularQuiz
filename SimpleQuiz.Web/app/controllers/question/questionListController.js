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

                angular.forEach($scope.quiz.CategoryQuestions, function (value, key) {
                    value.OptionsGrouped = _.groupBy(value.Options, "Category");
                });
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
        var question = {
            QuizId: $scope.quizId,
            Content: "",
            View: "Standard",
        };

        switch(questionType)
        {
            case "Open":
                question.CorrectAnswers = [{ OrderId: 1, CorrectAnswerOptions: [{ Content: "" }] }];
                break;
            case "Test":
                question.Options = [{ Content: "", IsCorrect: false}];
                break;
        }

        var modalInstance = $modal.open({
            templateUrl: modalService.getModalTemplateUrl("question/" + questionType, "add"),
            controller: modalService.getModalControllerName(questionType + "Question"),
            resolve: {
                question: function () { return question }
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
            templateUrl: modalService.getModalTemplateUrl("question/", "delete"),
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