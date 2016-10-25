var WalletsServices = function() {
    var getWallets = function(success, error) {
        $.ajax({
            type: "GET",
            url: "/api/wallets",
            data: "",
            success: (data) => success(data),
            error: error
        });
    }

    return {
        getWallets: getWallets
    }
}();