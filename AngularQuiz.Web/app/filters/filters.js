quizApp.filter("formatQuestion", function () {
    return function (text) {
        return text.replace("[]", "<span class='label label-info'>[]</span>");
    }
});