window.relativeDay = function (date, offset) {
    return new Date(date.getFullYear(), date.getMonth(), date.getDate() + offset);
};

window.initToggleButtons = function (apiUrl, dataId) {
    $("body").on("click", ".btn-primary", function (event) {
        var button = $(event.target).closest(".btn-primary");
        button.attr("disabled", true);

        $.ajax({
            type: "PUT",
            url: apiUrl + "/" + button.data(dataId),
            success: function () {
                button.toggleClass("btn-primary btn-success");
                button.children(".glyphicon-unchecked").toggleClass("glyphicon-unchecked glyphicon-check");
                button.attr("disabled", false);
            },
            error: function () {
                button.attr("disabled", false);
            }
        });
    });

    $("body").on("click", ".btn-success", function (event) {
        var button = $(event.target).closest(".btn-success");
        button.attr("disabled", true);

        $.ajax({
            type: "DELETE",
            url: apiUrl + "/" + button.data(dataId),
            success: function () {
                button.toggleClass("btn-success btn-primary");
                button.children(".glyphicon-check").toggleClass("glyphicon-check glyphicon-unchecked");
                button.attr("disabled", false);
            },
            error: function () {
                button.attr("disabled", false);
            }
        });
    });
};
