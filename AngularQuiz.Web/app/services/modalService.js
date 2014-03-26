quizApp.factory("modalService", function ($log, toaster) {
    var _showSaveSuccess = function (entityName, name) {

        var message = entityName;

        if (name != undefined) {
            message += " <i>" + name + "</i>";
        }

        toaster.pop('success', "Updated successfully", message + " was updated successfully.", null, 'trustedHtml');
    };

    var _showSaveError = function (entityName, name) {

        var message = "Something went wrong while saving " + entityName;

        if (name != undefined) {
            message += " <i>" + name + "</i>";
        }

        toaster.pop('error', "Failed to save", message, null, 'trustedHtml');
    };

    var _showAddSuccess = function (entityName) {
        toaster.pop('success', "Added successfully", entityName + " has been added.", null, 'trustedHtml');
    };

    var _showAddError = function () {
        toaster.pop('error', "Failed to add", "Something went wrong while adding.", null, 'trustedHtml');
    };

    var _showDeleteSuccess = function (entityName, name) {

        var message = entityName;

        if (name != undefined) {
            message += " <i>" + name + "</i>";
        }

        toaster.pop('success', "Deleted successfully", massage + " was deleted successfully.", null, 'trustedHtml');
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

        var name = entity.capitalize();

        if (action != undefined) {
            name += action.capitalize();
        }

        return name + "Controller";
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