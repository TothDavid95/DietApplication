$(document).ready(function () {

    $('.checkers input').click(function () {
        if ($(this).hasClass('checkedCHB')) {
            $(this).removeClass('checkedCHB');
        } else {
            $(this).addClass('checkedCHB');
        }
    });

    $('#AccountEditFormSubmitter').click(function () {
        var email = $('#Email').val();
        var allergyCount = $('.checkers input').length;
        var allergies = [];
        for (var i = 1; i <= allergyCount; i++) {
            if ($('#allergyCheckboxes div:nth-child(' + i + ') label input').hasClass('checkedCHB')) {
                allergies.push(i);
            }
        }
        $.ajax({
            traditional: true,
            type: "POST",
            url: "/Account/Edit",
            data: {
                Email: email,
                Allergies: allergies,
                __RequestVerificationToken: $("input[name=__RequestVerificationToken").val()
            },
            dataType: "text",
            success: function (data) {
                alert('Változtatások mentése sikeres.');
            },
            error: function () {
                alert('Változtatások mentése sikertelen.');
            }
        });
    });
});