quizApp.factory("modalService", function ($log, toaster) {
    var _showSaveSuccess = function (entityName, name) {
        toaster.pop('success', "Updated successfully", entityName + " <i>" + name + "</i> was updated successfully.", null, 'trustedHtml');
    };

    var _showSaveError = function (entityName, name) {
        toaster.pop('error', "Failed to save", "Something went wrong while saving " + entityName + " <i>" + name + "</i>.", null, 'trustedHtml');
    };

    var _showAddSuccess = function ($modalInstance, entityName) {
        toaster.pop('success', "Added successfully", entityName + " has been added.", null, 'trustedHtml');
    };

    var _showAddError = function () {
        toaster.pop('error', "Failed to add", "Something went wrong while adding.", null, 'trustedHtml');
    };

    var _showDeleteSuccess = function (entityName, name) {
        toaster.pop('success', "Deleted successfully", entityName + " " + name + " was deleted successfully.", null, 'trustedHtml');
    };

    var _showDeleteError = function (name) {
        toaster.pop('error', "Failed to delete", "Something went wrong while deleting " + name + ".", null, 'trustedHtml');
    };

    var _logError = function (errorInfo) {
        $log.error(errorInfo.status);
        $log.error(errorInfo.data.ExceptionMessage);
        $log.error(errorInfo.data.ExceptionType);
        $log.error(errorInfo.data.Message);
        $log.error(errorInfo.data.StackTrace);
    };


    var _getModalTemplateUrl = function (entity, action) {
        return "app/views/admin/" + entity + "/" + action + ".html";
    };

    var _getModalControllerName = function (entity, action) {
        return entity.capitalize() + action.capitalize() + "Controller";
    };

    return {
        showSaveSuccess: _showSaveSuccess,
        showSaveError: _showSaveError,
        showAddSuccess: _showAddSuccess,
        showAddError: _showAddError,
        showDeleteSuccess: _showDeleteSuccess,
        showDeleteError: _showDeleteError,
        getModalTemplateUrl: _getModalTemplateUrl,
        getModalControllerName: _getModalControllerName
    };
});