quizApp.controller('ListControllerBase', function ($scope) {

    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    };

    $scope.getModalTemplateUrl = function (entity, action) {
        return "app/views/admin/" + entity + "/" + action + ".html";
    };

    $scope.getModalControllerName = function (entity, action) {
        return entity.capitalize() + action.capitalize() + "Controller";
    };
});