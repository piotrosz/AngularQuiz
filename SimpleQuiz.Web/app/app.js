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
        .otherwise({ redirectTo: "/packages" });
});