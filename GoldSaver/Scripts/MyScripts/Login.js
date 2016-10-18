$("#log-to-reg").click(function () {
    $("#login").addClass("waves-effect").css("display", "none");
    $("#register").removeClass("waves-effect").css("display", "block");
});

$("#reg-to-log").click(function () {
    $("#register").addClass("waves-effect").css("display", "none");
    $("#login").removeClass("waves-effect").css("display", "block");
});