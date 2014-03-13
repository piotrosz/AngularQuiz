quizApp.directive("count", function () {
    return {
        restrict: "E",
        scope: { value: "@" },
        template: "<span class='badge'>{{value}}</span>"
    };
});

quizApp.directive("order", function () {
    return {
        restrict: "E",
        scope: { value: "@" },
        template: "<span class='label label-primary'>{{value}}</span>"
    };
});