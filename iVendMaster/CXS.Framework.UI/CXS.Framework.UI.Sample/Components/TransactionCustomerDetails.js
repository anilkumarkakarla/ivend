var app = angular.module("transactionCustomerDetails", ["PosApp"]);

app.constant('MODULE_VERSION', '0.0.1');

app.directive('transactionCustomerDetails', [function () {
    return {
        restrict: 'E',
        scope: true,
        templateUrl: function(elem, attrs) {
            return attrs.templatesrc;
        },
        controller: ['$scope', 'customersDataService', function ($scope, customersDataService) {
            $scope.model = customersDataService.model;
            customersDataService.model.update();
        }]
    }
}]);
