$(document).ready(function () {
    $(".service1").hover(
        function () {
            $(this).find("h3").css({ "margin-top": "0", });
            $(this).css({ "background-color": "#ff2e62", "border-radius": "1rem" });
        },
        function () {
            $(this).find("h3").css({ "margin-top": "10rem" });
            $(this).css({ "background-color": "#262a35", "border-radius": "0rem", "disply": "none" });
        }
    );
});

