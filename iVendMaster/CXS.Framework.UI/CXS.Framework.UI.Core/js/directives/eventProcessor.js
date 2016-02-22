var app = angular.module('PosApp');
app.directive('eventProcessor', function() {
    return {
        restrict: 'A',
        scope: true,
        controller: ['$scope', function ($scope) {
            $scope.fire = function () {
            }
            if ($scope.eventCallbacks) {
                $scope.eventCallbacks.forEach(function (callback) {
                });

                $scope.fire = function (event, parameter) {
                }

            }
        }],
        priority: -99999
    };
});