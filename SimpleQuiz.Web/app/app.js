var quizApp = angular.module("quiz", ["ngRoute", "ngResource", "ui.bootstrap"]);

quizApp.config(function ($routeProvider) {
    $routeProvider.when("/packages",
    {
        controller: "QuizPackageController",
        templateUrl: "/app/views/quizpackages.html"
    })
    .otherwise({ redirectTo: "/packages" });
});