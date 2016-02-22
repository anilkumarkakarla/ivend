/**
 * Created by jojo.peter on 1/27/2016.
 */

var posApp = angular.module('PosApp', ['oc.lazyLoad']);

posApp.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
}
]);

posApp.controller("PosController", function ($scope) {
});

//Base directive here that will call the API and get the page template
posApp.directive('baseDirective', function (baseService) {
        return {
            restrict: 'E',
            transclude: true,
            scope: {},
            link: function (scope, element, attrs) {
                baseService.getHighLevelHtml(attrs.pageId, element, scope);
            }
        }
    }

);

posApp.service('baseService', ['$http', '$compile', function ($http, $compile) {
    this.getHighLevelHtml = function(pageId, baseElement, scope) {
        $http.get('http://localhost:53385/api/renderer/' + pageId) //Correct API endpoint here
            .success(function (response) {
                $(baseElement).replaceWith($compile(response.HtmlString)(scope));
            })
    }
}]);

posApp.directive("pageWrapper", function () {
    return {
        restrict: 'E',
        link: function (scope, element, attrs) {
            scope.Execute(element, attrs);
        },
        controller: ['$scope', '$ocLazyLoad', '$compile', function ($scope, $ocLazyLoad, $compile) {
            $scope.controls = [];
            $scope.dependencies = [];
            $scope.Execute = function (element, attrs) {
                $ocLazyLoad.load({
                    insertBefore: 'base-directive',
                    files: $scope.dependencies
                }).then(function () {
                    var compiledHTML = $compile($(element[0]).children("div").html())($scope);
                    $(element).replaceWith(compiledHTML);
                },function (error) {
                    console.log(error);
                })
            }
        }]
    }
});

//Directive that will add page dependencies
posApp.directive('pageDependency', function () {
    return {
        restrict: 'E',
        link: function (scope, element, attrs) {
            scope.Execute(attrs.src);
        },
        transclude: true,
        scope: {},
        controller: ['$scope', function ($scope) {
            $scope.Execute = function (url) {
                $scope.$parent.dependencies.push(url);
            }
        }]
    }
});