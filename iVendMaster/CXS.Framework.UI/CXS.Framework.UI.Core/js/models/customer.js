(function () {
    'use strict';

    var Customer = function() { };

    var customersDataService = function (modelTransformer, Customer, $q) {
        var _customers = [];
        var _selectedCustomer = {};

        function update () {
            var deferred = $q.defer();
            //C# callback should be here
            if (_customers.length == 0) {
                _customers = modelTransformer.transform(JSON.parse('[{"id": "C000001", "name": "Lisa", "contact": "8765432190", "creditLimit": 0, "balance": 0, "availablePoints": 0, "img": "Components/image/u217.png"},{"id": "C000002", "name": "Mark", "contact": "8765432190", "creditLimit": 0, "balance": 0, "availablePoints": 0, "img": "http://placehold.it/67x69"}]'), Customer);
               _selectedCustomer = _customers[0] || {};
            }
            deferred.resolve(model);
            return deferred.promise;
        };

        var model = {
            get customers() { return _customers; },
            get selectedCustomer() { return _selectedCustomer; },
            update: update
        };

        return {
            model: model
        };
    };

    var module = angular.module("PosApp");
    module.value("Customer", Customer);
    module.factory("customersDataService", customersDataService);
}());