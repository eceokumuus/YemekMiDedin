$().ready(function () {

    $("#tostmenu").click(function () {
        if ($(".menu>ul").is(":visible")) {
            $(".menu>ul").css("display", "none");
        }
        else {
            $(".menu>ul").css("display", "block");
            $(".menu>ul>li>ul").css("display", "none");
        }
    });

    $(window).resize(function () {
        if (this.window.innerWidth > 768) {
            $(".menu>ul").css("display", "block");
        }
    });
});