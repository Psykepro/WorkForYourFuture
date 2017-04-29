(function() {
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
            // if ngModel is not defined, we don't need to do anything
            var firstPassword = $parse(attrs[directiveId]), 
                validator = function(value) {
                    var timeout;
                var temp = firstPassword(scope),
                    v = value === temp;

                ctrl.$setValidity('match', true);

                if (timeout) $timeout.cancel(timeout);

                timeout = $timeout(function() {

                        ctrl.$setValidity('match', v);

                    },
                    500);

                return value;

            }

            ctrl.$parsers.unshift(validator);

            ctrl.$formatters.push(validator);

            scope.$watch(attrs[directiveId],
                function() {

                    validator(ctrl.$viewValue);

                });

        }
    }
})();