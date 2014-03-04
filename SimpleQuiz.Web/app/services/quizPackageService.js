'use strict';

quizApp.factory("quizPackageService", function ($resource) {

    var requestUrl = "/api/QuizPackage/:id";

    var _save = function (item, success, error) {
        return $resource(requestUrl,
            { id: "@Id" }, /* paramDefaults */
            { "update": { method: "PUT" } }) /* actions */
                .update(null, item, success, error);
    };

    var _query = function (settings, success, error) {
        $resource(requestUrl).get(settings, success, error);
    };

    var _delete = function (item, success, error) {
        $resource(requestUrl).delete(item, success, error);
    }

    var _add = function (item, success, error) {
        $resource(requestUrl).save(item, success, error);
    }

    var _get = function (id, success, error) {
        $resource(requestUrl, { id: "@Id" }).get({id: id}, success, error);
    }

    return {
        save: _save,
        query: _query,
        delete: _delete,
        add: _add,
        get: _get
    };
});