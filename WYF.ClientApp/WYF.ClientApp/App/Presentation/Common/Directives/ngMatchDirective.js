(function () {
    'use-strict';

    var directiveId = 'ngMatch';

    angular.module('presentation').directive(directiveId, ngMatch);

    ngMatch.$inject = ['$parse', '$timeout'];

    function ngMatch($parse, $timeout) {

        var instance = {
            link: link,
            restrict: 'A',
            require: '?ngModel'
        };

        return instance;

        function link(scope, elem, attrs, ctrl) {

            var firstPassword = $parse(attrs[directiveId]),
                validator = function (value) {
                    var temp = firstPassword(scope),
                        v = value === temp;

                    ctrl.$setValidity('match', v);

                    return value;
                }

            ctrl.$parsers.unshift(validator);

            ctrl.$formatters.push(validator);

            scope.$watch(attrs[directiveId],
                function () {
                   
                    validator(ctrl.$viewValue);

                });

        }
    }
})();