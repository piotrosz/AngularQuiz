(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', 'entityManagerFactory', 'breeze', datacontext]);

    function datacontext(common, entityManagerFactory, breeze) {
        var $q = common.$q;
        var $entityManagerFactory = entityManagerFactory;
        var $breeze = breeze;

        var service = {
            getPhrases: getPhrases,
        };

        return service;

        function getPhrases() {

            var manager = $entityManagerFactory.newManager();

            var query = $breeze.EntityQuery
                .from("Phrases");

            return manager.executeQuery(query);
        }
    }
})();