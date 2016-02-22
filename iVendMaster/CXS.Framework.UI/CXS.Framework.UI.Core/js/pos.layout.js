/**
 * Created by jojo.peter on 1/27/2016.
 */

var posApp = angular.module('DemoLayout', ['oc.lazyLoad']);

posApp.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
}
]);

posApp.controller("LayoutController", function ($scope) {
    $scope.HoldGridsterInstance = function (gridsterInstance) {
        $scope.gridsterHandle = gridsterInstance;
    }
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
    this.getHighLevelHtml = function (pageId, baseElement, scope) {
        $http.get('http://localhost:53385/api/renderer/' + pageId) //Correct API endpoint here
            .success(function (response) {
                $(baseElement).replaceWith($compile(response.HtmlString)(scope));
                //angular.element(baseElement).html($compile(response.HtmlString)(scope))
            })
        //.error(function (response) {
        //    angular.element(baseElement).append(null);//Handle this error in a better way
        //});
    }
}]);

posApp.directive("pageWrapper", function () {
    return {
        restrict: 'E',
        link: function (scope, element, attrs) {
            scope.Execute();
        },
        controller: ['$scope', '$ocLazyLoad', '$injector', '$compile', function ($scope, $ocLazyLoad, $injector, $compile) {
            $scope.controls = [];
            $scope.dependencies = [];
            $scope.Execute = function () {
                $ocLazyLoad.load({
                    insertBefore: 'base-directive',
                    files: $scope.dependencies
                }).then(function () {
                    $scope.controls.forEach(function (control) {
                        $ocLazyLoad.load({
                            insertBefore: 'page-wrapper',
                            files: [control.moduleUrl]
                        }).then(function (result) {
                            var controlFactory = $injector.get(control.factory);
                            var controlHtml = controlFactory.constructControl($compile, $scope, control.templateUrl);
                            //controlHtml.attr("style", control.element.attr("style"));
                            //$(control.element).replaceWith(controlHtml);

                            var colspan = control.element.attr('columnspan');
                            var rowspan = control.element.attr('rowspan');
                            var widgetindex = control.element.attr('widgetindex');
                            $scope.$parent.gridsterHandle.$widgets.eq(widgetindex).html(controlHtml);
                            $scope.$parent.gridsterHandle.$widgets.eq(widgetindex).attr('data-sizex', colspan);
                        });
                    });
                }, function (error) {
                    console.log('Promise failed', error);
                })
            }
        }]
    }
});

posApp.directive('iVendComponent', function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {},
        link: function (scope, element, attrs) {
            scope.Execute(element, attrs.modulesrc, attrs.templatesrc, attrs.interface)
        },
        controller: ['$scope', function ($scope) {
            $scope.Execute = function (element, moduleUrl, templateUrl, factory) {
                $scope.$parent.controls.push({
                    moduleUrl: moduleUrl,
                    templateUrl: templateUrl,
                    element: element,
                    factory: factory
                });
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