
var app = angular.module("containerWidget", []);

app.factory('ContainerComponent_Factory', function () {
    return {
        constructControl: function ($compile, $scope, templateUrl)
        {

            var innerComponents = "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>" + 
            "<button style='width: 100px; height: 100%'>Button TEST</button>";
            var compileFunction = $compile("<div id='controlv16' style='border-style: solid;' container-widget>" + innerComponents +"</div>")

            //Get html output from directive after applying $scope
            var htmloutputFromDirective = compileFunction($scope);
            return htmloutputFromDirective;
        }
    }
});

app.directive('containerWidget', function () {
    return {
        restrict: 'A',
        scope: true,
        transclude: true,
        templateUrl: 'Content/Templates/ContainerWidgetView.html',
        link: function(scope, element, attrs) {

            var widthDropdownArrow = 20;
            var numberElements = element[0].children[0].children.length;

            var buttonArray = element[0].children[0].children[0].children;
            var containerWidth = element[0].clientWidth;

            var elementsArraySum = 0;
            var toDropdownArray = [];
            for (var i = 0; i < buttonArray.length; i++) {
                if (elementsArraySum + buttonArray[i].clientWidth + widthDropdownArrow < containerWidth) {
                    elementsArraySum += buttonArray[i].offsetWidth;
                } else {
                    toDropdownArray.push($(buttonArray[i])[0].outerHTML);
                    buttonArray[i].style.display = 'none';
                }
            };

            if (toDropdownArray.length > 0) {
                scope.dropdownOptions = {
                    template: toDropdownArray.join(""),
                    dataSource: [" "]
                }
            }
        },
        controller: ['$scope', function ($scope) {

        }]
    }
});