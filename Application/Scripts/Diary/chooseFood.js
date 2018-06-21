$(document).ready(function () {
    $('.Food').click(function () {
        if (!$(this).hasClass('selectedItem')) {
            $(this).addClass('selectedItem');
            let name = $(this).find("td:first").text();
            let id = $(this).attr("id");
            $('#foodHolder').append(
                "<li id='L" + id + "' class='listedFood'>" + name + "</li>"
            );
            checkIfActualMeal();
            rebindClicks();
        }
    });

});

function rebindClicks() {
    $('.listedFood').unbind('click');
    $('.listedFood').click(function () {
        $('#' + $(this).attr('id').slice(1)).removeClass('selectedItem');
        $(this).remove();
        checkIfActualMeal();
    });
}

function checkIfActualMeal() {
    if ($('#foodHolder').children('li').length > 0) {
        $('#shoppingCart').css('color', 'white');
        $('#shoppingCart').unbind('click');
        $('#shoppingCart').click(createMeal);
    } else {
        $('#shoppingCart').css('color', '#AAA');
        $('#shoppingCart').removeAttr('href');
        $('#shoppingCart').unbind('click');
    }
}

function createMeal() {
    alert("Étkezés felvéve");
}
