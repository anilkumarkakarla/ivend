var app = angular.module('PosApp');
app.directive('positioner', function () {
    return {
        restrict: 'A',
        scope: true,
        link: function (scope, element, attr) {
            if (attr.position) {
                var pos = angular.element('<div class="positioner-div"></div>');
                pos.attr('style', attr.position.replace(new RegExp('\"|{|}', 'g'), "").replace(new RegExp(',', 'g'), ';'));
                $($(element).children()[0]).wrap(pos);
            }
        },
        priority: -99999
    };
});