var quizApp = angular.module("quiz", ["ngRoute", "ngResource", "ngAnimate" , "ui.bootstrap", "chieffancypants.loadingBar", "toaster"]);

quizApp.config(function ($routeProvider) {

    $routeProvider
        .when("/packages",
        {
            controller: "QuizPackagesController",
            templateUrl: "/app/views/quizpackages.html"
        })
        .when("/quizes/:packageId",
        {
            controller: "QuizController",
            templateUrl: "/app/views/packageQuizes.html"
        })
        .when("/questions/:quizId",
        {
            controller: "QuestionController",
            templateUrl: "/app/views/quizQuestions.html"
        })
        .otherwise({ redirectTo: "/packages" });
});