var quizApp = angular.module("quiz", ["ngRoute", "ngResource", "ui.bootstrap", "chieffancypants.loadingBar", "toaster"]);

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
            templateUrl: "/app/views/quizes.html"
        })
        .when("/questions/:quizId",
        {
            controller: "QuestionController",
            templateUrl: "/app/views/questions.html"
        })
        .otherwise({ redirectTo: "/packages" });
});