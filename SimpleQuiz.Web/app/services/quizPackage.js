'use strict';

quizApp.factory("quizPackageService", function ($resource, toaster) {

    var requestUri = "/api/QuizPackage";

    var _save = function (item) {

    };

    var _query = function (settings, handler) {
        $resource(requestUri).get(settings, handler, function (err) {
            toaster.pop("error", "Failed to get quiz packages", "Fetch error");
        });
    };

    var packagesFactory = {};
    packagesFactory.save = _save;
    packagesFactory.query = _query;

    return packagesFactory;
});