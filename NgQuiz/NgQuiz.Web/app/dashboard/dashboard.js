(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$modal', dashboard]);

    function dashboard(common, datacontext, $modal) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'News title',
            description: 'No news.'
        };

        vm.phrases = [];
        vm.title = 'My phrases';
        vm.openAddPhraseModal = openAddPhraseModal;

        activate();

        function activate() {
            var promises = [getPhrases()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getPhrases() {
            return datacontext.getPhrases().then(function (data) {
                return vm.phrases = data.results;
            });
        }

        function openAddPhraseModal() {
            var modalInstance = $modal.open({
                templateUrl: "/app/dashboard/phraseAdd.html",
                controller: modalInstanceController,
                resolve: {
                    phrase: function () { return datacontext.newPhrase({ content: "", translation: "" }); }
                }
            });

            modalInstance.result.then(function () {
                getPhrases();
            });
        }
    }

    var modalInstanceController = 'PhraseModalInstanceController';

    angular.module('app').controller(modalInstanceController, function ($scope, $modalInstance, phrase, datacontext) {

        $scope.phrase = phrase;

        $scope.cancel = function () {
            $modalInstance.dismiss("cancel");
        }

        $scope.add = function () {
            datacontext.saveChanges()
                .then(function (saveResult) {
                    $modalInstance.close();
               });
        }
    });
})();