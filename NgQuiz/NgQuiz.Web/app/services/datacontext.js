(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', 'entityManagerFactory', 'breeze', datacontext]);

    function datacontext(common, entityManagerFactory, breeze) {
        var $q = common.$q;
        var $entityManagerFactory = entityManagerFactory;
        var $breeze = breeze;

        var manager = $entityManagerFactory.newManager();

        var service = {
            getPhrases: getPhrases,
            newPhrase: newPhrase,
            saveChanges: saveChanges
        };
        return service;

        function getPhrases() {

            var query = $breeze.EntityQuery
                .from("Phrases");

            return manager.executeQuery(query);
        }

        function newPhrase(initialValues) {
            return manager.createEntity('Phrase', initialValues);
        }

        function saveChanges() {
            return manager.saveChanges();
        }
    }
})();