angular.module("quizdirectives", [])

.directive("count", function () {
    return {
        restrict: "E",
        scope: { value: "@" },
        template: "<span title='Count' class='badge'>{{value}}</span>"
    };
})

.directive("order", function () {
    return {
        restrict: "E",
        transclude: true,
        replace: true,
        template: '<span title="Order number" class="label label-primary" ng-transclude></span>'
    }
})

.directive("questionContent", function () {
    return {
        restrict: "E",
        scope: { content: "@" },
        link: function (scope, element, attrs) {
            var span = "<span>" + scope.content
                .replace(/\[\s?/g, "<strong class='text-info'>[</strong>")
                .replace(/\s?\]/g, "<strong class='text-info'>...]</strong>") + "</span>";
            element.append(span);
        }
    };
})

/*
.directive('angularIcon', function () {
    return {
        restrict: "E",
        link: function (scope, elem, attrs) {
            var img = document.createElement("img");
            img.src = "http://goo.gl/ceZGf";

            elem[0].appendChild(img);
        }
    };
})

.directive("compileCheck", function () {
    return {
        restrict: "A",
        compile: function (tElement, tAttrs) {
            tElement.append("Added during compilation!");
        }
    };
})

.directive("dirTest", function ($http) {
    return {
        restrict: "A",
        replace: true,
        template: "<span>{{data.name}}</span>",
        link: function (scope, elem, attrs) {
            $http.get("https://api.github.com/repos/angular/angular.js").success(function (data) {
                scope.data = data;
            });
        }
    };
})

.directive('btn', function () {
    return {
        restrict: "A",
        priority: 0,
        link: function (scope, elem, attrs) {
            elem.addClass("btn");

        }
    };
})

.directive('success', function () {
    return {
        restrict: "A",
        priority: 1,
        link: function (scope, elem, attrs) {
            if (elem.hasClass('btn')) {
                elem.addClass('btn-success')
            }
        }
    }
})

.directive("powerSwitch", function () {
    return {
        restrict: "A",
        controller: function ($scope, $element, $attrs) {
            $scope.state = "on";

            $scope.toggle = function () {
                $scope.state = ($scope.state === "on") ? "off" : "on";
            };

            this.getState = function () { return $scope.state;}
        },
        link: function (scope, element, attrs) {
            element.bind("click", function () { scope.toggle(); });

            scope.$watch("state", function (newVal, oldVal) {
                if (newVal === "off") {
                    element.addClass("disabled");
                }
                else {
                    element.removeClass("disabled");
                }
            });
        }
    };
})

.directive('lightbulb', function () {
    return {
        restrict: 'A',
        require: '^powerSwitch',
        link: function (scope, element, attrs, controller) {
            scope.$watch(function () {
                scope.bulb = controller.getState();
            });
        }
    };
});
*/