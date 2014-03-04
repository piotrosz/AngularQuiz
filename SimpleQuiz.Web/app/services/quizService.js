'use strict';

quizApp.factory("quizService", function ($resource) {
    var requestUrl = "/api/quizesbypackage/:packageId";

    var _query = function (packageId, success, error) {
        $resource(requestUrl).query({ packageId: packageId }, success, error);
    }

    return {
        query: _query
    };
});