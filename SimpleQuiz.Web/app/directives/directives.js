quizApp.directive("question", function () {
    return {
        restrict: "E",
        scope: { content: "@" },
        replace: true,
        //link: function (scope) {
            
        //},
        template: "<p>{{content}}</p>"
    };
});