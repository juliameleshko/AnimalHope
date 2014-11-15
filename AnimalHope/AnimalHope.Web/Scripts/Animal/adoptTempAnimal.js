$(function (animal, $, undefined) {

    $('#temporaryAnimalDetails').hide();

    animal.adoptFromTemporary = function () {
        $('#adoptTempAnimal').on('click', function () {
            $('#temporaryAnimalDetails').show();
        });
        $('#tempAdoptCansel').on('click', function () {
            var desc = $('#Description')[0];
            desc.value = "";
            $('#temporaryAnimalDetails').hide();
        });
    }
    animal.adoptFromTemporary();
}(window.animal = window.animal || {}, jQuery));