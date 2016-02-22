var app = angular.module("transactionItemGrid", ['kendo.directives', 'PosApp']);

app.constant('MODULE_VERSION', '0.0.1');

app.value('defaults', {

});

app.directive('transactionItemGrid', [function () {
    return {
        restrict: 'E',
        scope: true,
        templateUrl: function(element, attrs){
            return attrs.templatesrc;
        },
        controller: ['$scope', 'transactionItemsDataService', function ($scope, transactionItemsDataService) {
            $scope.transactionItemGridOptions = {
                sortable: true,
                selectable: true,
                height: 450,
                dataSource: transactionItemsDataService.model.items,
                columns: transactionItemsDataService.model.columns
            };
            $scope.selectionChanged = function (data) {
                transactionItemsDataService.model.selectedItem = data;
            };
        }]
    }
}]);