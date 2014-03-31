quizApp.factory("dataService", ['$http', function ($http) {

    var urlBase = "/api/";
    var dataFactory = {};

    dataFactory.insert = function (url, entity) {
        return $http.post(urlBase + url, entity);
    }

    dataFactory.update = function (url, entity) {
        return $http.put(urlBase + url + "/" + entity.Id, entity);
    }

    dataFactory.delete = function (url, id) {
        return $http.delete(urlBase + url + '/' + id);
    };

    return dataFactory;
}]);