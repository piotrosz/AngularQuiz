'use strict';

quizApp.factory("quizService", function ($resource) {

    var requestUrl = "/api/quiz/:id";

    var _query = function (packageId, success, error) {
        $resource("/api/quizesbypackage/:packageId").query({ packageId: packageId }, success, error);
    }

    var _save = function (item, success, error) {
        return $resource(requestUrl,
            { id: "@Id" }, /* paramDefaults */
            { "update": { method: "PUT" } }) /* actions */
                .update(null, item, success, error);
    };

    var _add = function (item, success, error) {
        $resource("/api/quiz/").save(item, success, error);
    }

    var _delete = function (item, success, error) {
        $resource(requestUrl).delete(item, success, error);
    }

    var _get = function (id, success, error) {
        $resource(requestUrl, { id: "@Id" }).get({ id: id }, success, error);
    }

    var _getForUser = function (id, success, error) {
        $resource("/api/quizforuser/:id", { id: "@id" }).get({ id: id }, success, error);
    }

    return {
        query: _query,
        save: _save,
        add: _add,
        delete: _delete,
        get: _get,
        getForUser: _getForUser
    };
});