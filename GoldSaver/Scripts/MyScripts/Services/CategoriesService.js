var CategoriesServices = function() {
    var getCategories = function (success, error) {
        $.ajax({
            type: "GET",
            url: "/api/categories",
            data: "",
            success: (data) => success(data),
            error: error
        });
    }

    return {
        getCategories: getCategories
    }
}();