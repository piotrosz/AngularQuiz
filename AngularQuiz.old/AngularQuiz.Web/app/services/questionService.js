'use strict';

quizApp.factory("questionService", function ($resource) {

    function getRequestUrl(type)
    {
        return "/api/" + type.capitalize() + "Question/:id";
    }

    var _save = function (type, item, success, error) {
        return $resource(getRequestUrl(type),
            { id: "@Id" }, /* paramDefaults */
            { "update": { method: "PUT" } }) /* actions */
                .update(null, item, success, error);
    };

    var _delete = function (type, item, success, error) {
        $resource(getRequestUrl(type)).delete(item, success, error);
    }

    var _add = function (type, item, success, error) {
        $resource(getRequestUrl(type)).save(item, success, error);
    }

    var _get = function (id, success, error) {
        $resource(getRequestUrl(type), { id: "@Id" }).get({ id: id }, success, error);
    }

    return {
        save: _save,
        delete: _delete,
        add: _add,
        get: _get
    };
});