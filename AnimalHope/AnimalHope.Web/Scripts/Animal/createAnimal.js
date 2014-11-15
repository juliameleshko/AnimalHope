$(function (animal, $, undefined) {
    animal.locationDetails = function () {
        $('#ConditionId').change(function () {
            var conditionSelect = document.getElementById("ConditionId");
            var selectedText = conditionSelect.options[conditionSelect.selectedIndex].text;

            if (selectedText == "Homeless") {
                $('#Lon').show();
                $('#Lat').show();
            }
            else {
                $('#Lon').hide();
                $('#Lat').hide();
            }
        });
    }
    animal.locationDetails();
}(window.animal = window.animal || {}, jQuery));