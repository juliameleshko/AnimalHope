$(function (animal, $, undefined) {
    animal.locationDetails = function () {

        $('#Lon').show();
        $('#Lat').show();
        $('#Vet').hide();

        $('#ConditionId').change(function () {
            var conditionSelect = document.getElementById("ConditionId");
            var selectedText = conditionSelect.options[conditionSelect.selectedIndex].text;

            if (selectedText == "Homeless") {
                $('#Vet').hide();
                $('#Lon').show();
                $('#Lat').show();
            }
            else if (selectedText == "At vet's office") {
                $('#Lon').hide();
                $('#Lat').hide();
                $('#Vet').show();
            }
            else {
                $('#Lon').hide();
                $('#Lat').hide();
                $('#Vet').hide();
            }
        });
    }
    animal.locationDetails();
}(window.animal = window.animal || {}, jQuery));