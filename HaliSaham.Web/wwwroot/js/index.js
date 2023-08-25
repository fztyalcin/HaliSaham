let sehirler [];
function SehirleriGetir() {
    var arr = data;
    $('#selectSehirler').empty();
    $.each(arr, function (i, item) {
        $('#selectSehirler').append($('<option>', {
            value: item.id,
            text: item.ad
        }));
    });
}


$(document).ready(function () {
    SehirleriGetir();
    HaliSahalariGetirBySehirId();
});