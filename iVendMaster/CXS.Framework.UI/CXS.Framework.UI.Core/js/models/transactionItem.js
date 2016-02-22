(function() {
    'use strict';

    var TransactionItem = function () { };

    var transactionItemsDataService = function (modelTransformer, TransactionItem) {
        var _items = new kendo.data.ObservableArray([]);
        var _selectedItem = {};
        var _columns = [];
        var _existingColumns = [];

        function _updateColumns(data) {
            for (var field in data) {
                if (data.hasOwnProperty(field) && _existingColumns.indexOf(field) == -1) {
                    _existingColumns.push(field);
                    _columns.push({field: field, title: field.charAt(0).toUpperCase() + field.slice(1)});
                }
            }
        }

        function addItem (data) {
            _items.push(modelTransformer.transform(data, TransactionItem));
            _updateColumns(data);
        }

        function removeSelectedItem () {
            var index = _items.indexOf(_selectedItem);
            if (index > -1) {
                _items.splice(index, 1);
                _selectedItem = _items[index] || {};
            }
        }

        function clear () {
            _items.empty();
            _selectedItem = {};
        }

        function _setSelected(item) {
            if (_items.indexOf(item) > -1) {
                _selectedItem = item;
            }
        }

        (function fake() {
            addItem(JSON.parse('{ "type": "Sale", "code": 100102, "description":"Men\'s Solid Polo", "quantity":2, "price":16.5, "discount":0, "total":33.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100103, "description":"Men\'s Ralp Lauren Suit", "quantity":1, "price":5.5, "discount":0, "total":5.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100104, "description":"Men\'s Levis Jean", "quantity":1, "price":9.5, "discount":0, "total":9.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100105, "description":"Womens tank", "quantity":1, "price":9.5, "discount":0, "total":9.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100106, "description":"Womens Tee", "quantity":1, "price":9.5, "discount":0, "total":9.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100107, "description":"Womens Champagne Suit", "quantity":1, "price":9.5, "discount":0, "total":9.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100108, "description":"Womens Dojo Jean", "quantity":1, "price":9.5, "discount":0, "total":9.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100109, "description":"Men\'s Adidas Running", "quantity":1, "price":9.5, "discount":0, "total":9.5 }'));
            addItem(JSON.parse('{ "type": "Sale", "code": 100110, "description":"Men\'s Walkstar Sandal", "quantity":1, "price":9.5, "discount":0, "total":9.5 }'));
        }());

        var model = {
            get items() { return _items; },
            get selectedItem() { return _selectedItem; },
            set selectedItem(value) { _setSelected(value) },
            get columns() { return _columns; },
            addItem: addItem,
            removeSelectedItem: removeSelectedItem,
            clear: clear
        };

        return {
            model: model
        }
    };

    var module = angular.module("PosApp");
    module.value("TransactionItem", TransactionItem);
    module.factory("transactionItemsDataService", transactionItemsDataService);
}());