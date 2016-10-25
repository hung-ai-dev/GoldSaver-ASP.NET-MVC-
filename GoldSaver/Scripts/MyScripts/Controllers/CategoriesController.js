var CategoriesController = function (categoriesService) {
    var success = function (data) {
        var template = _.template($("#list_cate_template").html());
        $("#list-category").html(template({
            list: data
        }));
        $('select').material_select();
    }

    var error = function () {
        alert("Error");
    }

    var init = function() {
        categoriesService.getCategories(success, error);
    }
    return {
        init: init
    }
}(CategoriesServices)