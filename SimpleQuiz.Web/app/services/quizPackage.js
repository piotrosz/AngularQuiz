'use strict';

quizApp.factory("quizPackageService", function ($resource) {

    var requestUri = "/api/QuizPackage";

    return $resource(requestUri);

});