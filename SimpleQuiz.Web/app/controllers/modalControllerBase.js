quizApp.controller('ModalControllerBase', function ($scope, $modalInstance, toaster, $log) {
    
    $scope.close = function () {
        $modalInstance.dismiss("cancel");
    };

    $scope.logError = function (errorInfo) {
        $log.error(errorInfo.status);
        $log.error(errorInfo.data.ExceptionMessage);
        $log.error(errorInfo.data.ExceptionType);
        $log.error(errorInfo.data.Message);
        $log.error(errorInfo.data.StackTrace);
    };
});