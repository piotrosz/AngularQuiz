var quizApp = angular.module("quiz", ["ngRoute", "ngResource", "ui.bootstrap", "chieffancypants.loadingBar", "toaster"]);

quizApp.config(function ($routeProvider/*, cfpLoadingBarProvider */) {

    //cfpLoadingBarProvider.includeSpinner = true;
    //cfpLoadingBarProvider.includeBar = true;

    $routeProvider.when("/packages",
    {
        controller: "QuizPackagesController",
        templateUrl: "/app/views/quizpackages.html"
    })
    .otherwise({ redirectTo: "/packages" });
});