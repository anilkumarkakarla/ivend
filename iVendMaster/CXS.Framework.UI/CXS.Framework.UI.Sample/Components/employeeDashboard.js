var app = angular.module("employeeDashboard", ['kendo.directives']);

app.constant('MODULE_VERSION', '0.0.1');

app.value('defaults', {

});

app.directive('employeeDashboard', [function () {
    return {
        restrict: 'E',
        scope: true,
        transclude: true,
        templateUrl: function(elem, attr) {
            return attr.templatesrc;
        },
        controller: ['$scope', '$element', function ($scope, $element) {
            $scope.employee = {
                id: 'SA00238',
                firstName: 'Dale',
                lastName: 'Hooper',
                contact: '+00 XXX-XXX-XXX',
                premise: 'XXX',
                street: 'Street 1',
                addressLine1: 'Address Line 1',
                addressLine2: 'Address Line 2',
                country: 'Country',
                storeName: 'Store Name',
                storeLocation: 'Store Location',
                code: 'Code'
            };
            $scope.salesStatistics = {
                currency: "$",
                todaySale: 1972.68,
                comission: 47.52,
                target: 73
            }

            $scope.targetSaleOptions = {
                type: "percent"
            }

            $scope.currentPeriod = "daily";
            $scope.changePeriod = function (period) {
                $scope.currentPeriod = period; 
                if ($scope.salesBarChart) {
                    $scope.salesBarChart.options.series[0].data = getSalesData(); 
                    $scope.salesBarChart.options.series[1].data = getComissionData(); 
                    $scope.salesBarChart.options.categoryAxis.categories = getAxisData(); 
                    $scope.salesBarChart.refresh();
                }
            }
            
            $scope.chartOptions = {
                legend: {
                    position: "top"
                },
                seriesDefaults: {
                    type: "column"
                },
                series: [{
                    name: "Sales",
                    data: getSalesData(),
                    color: "#ccc"
                }, {
                    name: "Comission",
                    data: getComissionData(),
                    color: "#000"
                }],
                valueAxis: {
                    labels: {
                        format: "{0}%"
                    },
                    line: {
                        visible: false
                    },
                    axisCrossingValue: 0
                },
                categoryAxis: {
                    categories: getAxisData(),
                    line: {
                        visible: false
                    },
                    labels: {
                        padding: {
                            top: 5
                        }
                    }
                },
                tooltip: {
                    visible: true,
                    format: "{0}%",
                    template: "#= series.name #: #= value #"
                }
            };

            function getSalesData() {
                switch ($scope.currentPeriod) {
                    case "daily": return [50, 84.2, 74.1, 67.3, 68.4, 72.1, 73.2, 75.8, 77.31, 69.89, 75.4, 77.34, 50, 84.2, 74.1, 67.3, 68.4, 72.1, 73.2, 75.8, 77.31, 69.89, 75.4, 77.34];
                    case "monthly": return [50, 84.2, 74.1, 67.3, 68.4, 72.1, 73.2, 75.8, 77.31, 69.89, 75.4, 77.34, 50, 84.2, 74.1, 67.3, 68.4, 72.1, 73.2, 75.8, 77.31, 69.89, 75.4, 77.34, 75.8, 80.4, 75.3, 69.3, 68.3, 66.3];
                    case "yearly": return [52, 74.2, 56.1, 74.3, 67.4, 75.1, 80.6, 73.8, 72.1, 52.89, 76.4, 80.34];
                }
            }
            function getComissionData() {
                switch ($scope.currentPeriod) {
                    case "daily": return [20.4, 19.8, 22.45, 18.6, 25.8, 26.87, 23.99, 30.1, 31.12, 33.71, 23.12, 24.12, 20.4, 19.8, 22.45, 18.6, 25.8, 26.87, 23.99, 30.1, 31.12, 33.71, 23.12, 24.12];
                    case "monthly": return [20.4, 19.8, 22.45, 18.6, 25.8, 26.87, 23.99, 30.1, 31.12, 33.71, 23.12, 24.12, 20.4, 19.8, 22.45, 18.6, 25.8, 26.87, 23.99, 30.1, 31.12, 33.71, 23.12, 24.12, 23.99, 30.1, 31.12, 33.71, 23.12, 24.12];
                    case "yearly": return [20.4, 19.8, 22.45, 18.6, 25.8, 26.87, 23.99, 30.1, 31.12, 33.71, 23.12, 24.12];
                }
            }
             function getAxisData() {
                switch ($scope.currentPeriod) {
                    case "daily": return [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23];
                    case "monthly": return [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30];
                    case "yearly": return ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                }
            }

             $scope.eventCallbacks = [];
             $scope.eventCallbacks.push({
                 event: 'employeeEvent',
                 callback: function () { }
             });
        }]
    }
}]);