
$(document).ready(function () {
    var numBalls = 10; // Adjust the number of balls as per your preference

    for (var i = 0; i < numBalls; i++) {
        var size = Math.random() * 40 + 5; // Randomize the ball size between 5 and 25 pixels
        var xPos = Math.random() * 100; // Randomize the initial X position of the ball
        var yPos = Math.random() * 100; // Randomize the initial Y position of the ball
        var speed = Math.random() * 50 + 1; // Randomize the speed of the ball

        var $ball = $("<div></div>").addClass("ball").css({
            width: size + "px",
            height: size + "px",
            left: xPos + "%",
            top: yPos + "%",
            animationDuration: speed + "s",
            animationDelay: speed + "s"
        });

        $("#balls-container").append($ball);
    }
});



