$(function (animal, $, undefined) {

    $('#homelessAnimalAdopt').hide();
    $('#homelessAnimalTemp').hide();
    $('#homelessAnimalVet').hide();

    animal.adoptOrDonateFromVet = function () {

        $('#adoptHomelessAnimal').on('click', function () {
            $('#homelessAnimalAdopt').show();
            $('#homelessAnimalTemp').hide();
            $('#homelessAnimalVet').hide();
        });

        $('#tempHomelessAnimal').on('click', function () {
            $('#homelessAnimalAdopt').hide();
            $('#homelessAnimalTemp').show();
            $('#homelessAnimalVet').hide();
        });

        $('#vetHomelessAnimal').on('click', function () {
            $('#homelessAnimalAdopt').hide();
            $('#homelessAnimalTemp').hide();
            $('#homelessAnimalVet').show();
        });

        $('#homelessAdoptCansel').on('click', function () {
            var desc = $('#Description')[0];
            desc.value = "";
            $('#homelessAnimalAdopt').hide();
        });

        $('#homelessTempCansel').on('click', function () {
            var desc = $('#Description')[0];
            desc.value = "";
            $('#homelessAnimalTemp').hide();
        });

        $('#homelessVetCansel').on('click', function () {
            var desc = $('#Description')[0];
            desc.value = "";
            var cost = $('#CostAmount')[0];
            cost.value = "";
            $('#homelessAnimalVet').hide();
        });
    }
    animal.adoptOrDonateFromVet();
}(window.animal = window.animal || {}, jQuery));