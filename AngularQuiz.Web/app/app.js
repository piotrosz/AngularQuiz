var quizApp = angular.module("quiz", ["ngRoute", "ngResource", "ngAnimate" , "ui.bootstrap", "chieffancypants.loadingBar", "toaster", 'quizdirectives']);

quizApp.config(function ($routeProvider) {

    $routeProvider
        .when("/admin/packages",
        {
            controller: "PackageListController",
            templateUrl: "/app/views/admin/package/list.html"
        })
        .when("/admin/quizes/:packageId",
        {
            controller: "QuizListController",
            templateUrl: "/app/views/admin/quiz/list.html"
        })
        .when("/admin/questions/:quizId",
        {
            controller: "QuestionListController",
            templateUrl: "/app/views/admin/question/list.html"
        })
        .when("/quiz/:quizId/:questionIndex?",
        {
            controller: "QuizController",
            templateUrl: "/app/views/user/quiz.html"
        })
        .otherwise({ redirectTo: "/quiz/:quizId" });
});