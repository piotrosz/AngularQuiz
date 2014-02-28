'use strict';

quizApp.factory("quizPackageService", function ($resource) {

    var requestUri = "/api/QuizPackage/:id";

    var _save = function (item, success, error) {
        return $resource(requestUri,
            { id: "@Id" }, /* paramDefaults */
            { "update": { method: "PUT" } }) /* actions */
                .update(null, item, success, error);
    };

    var _query = function (settings, success, error) {
        $resource(requestUri).get(settings, success, error);
    };

    var packagesFactory = {};
    packagesFactory.save = _save;
    packagesFactory.query = _query;

    return packagesFactory;
});