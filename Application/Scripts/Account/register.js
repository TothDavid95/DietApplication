$(document).ready(function () {

    $("#UserName").on('focusout', function () {
        $("#UniqueUsernameValidation").css('display', 'block');
        if ($(this).val() !== '') {
            let text = $(this).val().toString();
            $.ajax({
                traditional: true,
                type: "POST",
                url: "/Account/UniqueUsernameValidation",
                data: { uname: text },
                dataType: "text",
                success: function (data) {
                    UserNameAjaxSuccess(data);
                },
                error: function () {
                    UserNameAjaxError();
                }
            });
        }
    });

    $("#Email").on('focusout', function () {
        $("#UnusedEmailAddressValidation").css('display', 'block');
        if ($(this).val() !== '') {
            let text = $(this).val().toString();
            $.ajax({
                traditional: true,
                type: "POST",
                url: "/Account/UnusedEmailValidation",
                data: { email: text },
                dataType: "text",
                success: function (data) {
                    EmailAjaxSuccess(data);
                },
                error: function () {
                    EmailAjaxError();
                }
            });
        }
    });
});

function UserNameAjaxSuccess(data) {
    if (data === "taken") {
        $(this).removeClass('valid');
        $(this).addClass('input-validation-error');
        $(this).attr('aria-invalid', 'true');
        $('#UniqueUsernameValidation').removeClass('field-validation-valid');
        $('#UniqueUsernameValidation').addClass('input-validation-error');
        $('#UniqueUsernameValidation').text('Ez a felhasználónév már foglalt.');
        $('.btn').addClass("disableOne");
    } else if (data === "unused") {
        $(this).removeClass('input-validation-error');
        $(this).addClass('valid');
        $(this).attr('aria-invalid', 'false');
        $('#UniqueUsernameValidation').removeClass('input-validation-error');
        $('#UniqueUsernameValidation').addClass('field-validation-valid');
        $('#UniqueUsernameValidation').text('');
        $('.btn').removeClass('disableOne');
    }
    CheckAndSetDisability();
}

function EmailAjaxSuccess(data) {
    if (data === "used") {
        $(this).removeClass('valid');
        $(this).addClass('input-validation-error');
        $(this).attr('aria-invalid', 'true');
        $('#UnusedEmailAddressValidation').removeClass('field-validation-valid');
        $('#UnusedEmailAddressValidation').addClass('input-validation-error');
        $('#UnusedEmailAddressValidation').text('Ez az email cím már használatban van.');
        $('.btn').addClass("disableTwo");
    } else if (data === "unused") {
        $(this).removeClass('input-validation-error');
        $(this).addClass('valid');
        $(this).attr('aria-invalid', 'false');
        $('#UnusedEmailAddressValidation').removeClass('input-validation-error');
        $('#UnusedEmailAddressValidation').addClass('field-validation-valid');
        $('.btn').removeClass('disableTwo');
    }
    CheckAndSetDisability();
}

function UserNameAjaxError() {

}

function EmailAjaxError() {

}

function CheckAndSetDisability() {
    if ( $('.btn').hasClass('disableOne') || $('.btn').hasClass('disableTwo') ) {
        $('.btn').attr('disabled', 'disabled');
    } else {
        $('.btn').removeAttr('disabled');
    }
}