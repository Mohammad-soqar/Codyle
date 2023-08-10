$(document).ready(function () {
    // Get the current date and time
    var currentDate = new Date();

    // Format the date and time as a string in the format accepted by the input element
    var dateString = currentDate.toISOString().slice(0, 10);

    // Set the value of the input element to the current date and time
    $(".datetime").val(dateString);
});


$(document).ready(function () {

    $('.dropdown-label').click(function () {
        $(this).toggleClass('open');
        $(this).next('.dropdown-checkbox').toggleClass('show');
    });

    $('.dropdown-checkbox').click(function (e) {
        e.stopPropagation();
    });


});

$(document).ready(function () {
    $('#eventType').change(function () {
        var selectedType = $(this).val();

        if (selectedType === 'Online' || selectedType === 'Both') {
            $('#youtubeInput').show();
        } else {
            $('#youtubeInput').hide();
        }
    });
});