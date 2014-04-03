(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', dashboard]);

    function dashboard(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'News title',
            description: 'No news.'
        };

        vm.people = [];
        vm.title = 'My phrases';

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
    }
})();