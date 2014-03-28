var quizApp = angular.module("quiz", ["ngResource", "ngAnimate" , "ui.bootstrap", "chieffancypants.loadingBar", "toaster", "quizdirectives", "ui.router"]);

quizApp.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/quiz/1");

    $stateProvider
        .state("adminpackages",
        {
            url: "/admin/packages",
            controller: "PackageListController",
            templateUrl: "/app/views/admin/package/list.html"
        })
        .state("adminquizes",
        {
            url: "/admin/quizes/:{packageId:[0-9]{1,4}}",
            controller: "QuizListController",
            templateUrl: "/app/views/admin/quiz/list.html"
        })
        .state("adminquestions", 
        {
            url: "/admin/questions/:{quizId:[0-9]{1,4}}",
            controller: "QuestionListController",
            templateUrl: "/app/views/admin/question/list.html"
        })
        .state("userquiz",
        {
            url: "/quiz/:{quizId:[0-9]{1,4}}/:{questionIndex:[0-9]{1,4}?}",
            templateUrl: "/app/views/user/quiz.html",
            controller: "QuizController"
        })


        

});