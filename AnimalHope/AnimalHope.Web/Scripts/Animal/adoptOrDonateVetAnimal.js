$(function (animal, $, undefined) {

    $('#vetAnimalAdopt').hide();
    $('#vetAnimalDonate').hide();
    $('#vetAnimalTemp').hide();

    animal.adoptOrDonateFromVet = function () {

        $('#adoptVetAnimal').on('click', function () {
            $('#vetAnimalDonate').hide();
            $('#vetAnimalTemp').hide();
            $('#vetAnimalAdopt').show();
        });

        $('#donateVetAnimal').on('click', function () {
            $('#vetAnimalAdopt').hide();
            $('#vetAnimalTemp').hide();
            $('#vetAnimalDonate').show();
        });

        $('#tempVetAnimal').on('click', function () {
            $('#vetAnimalAdopt').hide();
            $('#vetAnimalTemp').show();
            $('#vetAnimalDonate').hide();
        });

        $('#vetAdoptCansel').on('click', function () {
            var desc = $('#Description')[0];
            desc.value = "";
            $('#vetAnimalAdopt').hide();
        });

        $('#vetDonateCansel').on('click', function () {
            var amount = $('#DonationAmount')[0];
            amount.value = "";
            $('#vetAnimalDonate').hide();
        });

        $('#tempAdoptCansel').on('click', function () {
            var desc = $('#Description')[0];
            desc.value = "";
            $('#vetAnimalTemp').hide();
        });
    }
    animal.adoptOrDonateFromVet();
}(window.animal = window.animal || {}, jQuery));