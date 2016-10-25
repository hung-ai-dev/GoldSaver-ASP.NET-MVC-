var WalletsController = function (walletService) {
    var success = function (data) {
        var template = _.template($("#list_wallet_template").html());
        $("#list-wallet").html(template({
            list: data
        }));
        $('select').material_select();
    }

    var error = function () {
        alert("Error");
    }

    var init = function() {
        walletService.getWallets(success, error);
    }

    return {
        init: init
    }
}(WalletsServices)