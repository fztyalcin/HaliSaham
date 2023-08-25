
let sehirler = [];
function SehirleriGetir() {
    Get("Sehir/TumSehirler", (data) => {
                 

        var arr = data;

        $('#selectSehirleriGetir').empty();
        $each(arr, function (i, item) {
            $('#selectSehirleriGetir').append($('<option>', {
                value: item.id
                text: item.ad
            }));
        }
    });
}


$(document).ready(function () {
    SehirleriGetir();
});

