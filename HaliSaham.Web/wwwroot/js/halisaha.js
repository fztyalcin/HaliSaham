function HaliSahalariGetir() {
    Get("HaliSaha/TumHaliSahalar", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Halı Saha Adı</th><th>Halı Saha Adresi</th><th>Maksimum Kapasitesi</th><th>Halı Sahanın Sahibi</th><th>Halı Sahanın Şehir Plakası</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td><td>${arr[i].adres}</td><td>${arr[i].maksimumKapasite}</td><td>${arr[i].kurumsalMusteriId}</td><td>${arr[i].sehirId}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='HaliSahaSil(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='HaliSahaDuzenle(${arr[i].id},"${arr[i].ad})'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divHaliSahalar").html(html);
    });
}

let selectedHaliSahaId = 0;

function YeniHaliSaha() {

    selectedHaliSahaId = 0;

    $("#inputHaliSahaAd").val("");

    $("#haliSahaModal").modal("show");
}
function HaliSahaKaydet() {
    var haliSaha = {
        Id: selectedHaliSahaId,
        Ad: $("#inputHaliSahaAd").val(),
        Adres: $("#inputHaliSahaAdres").val(),
        MaksimumKapasite: $("#inputHaliSahaMaksimumKapasite").val(),
        KurumsalMusteriId: $("#inputKurumsalMusteriId").val(),
        SehirId: $("#inputHaliSahaSehirId").val(),
    };
    Post("HaliSaha/Kaydet", haliSaha, (data) => { HaliSahalariGetir(); $("#haliSahaModal").modal("hide"); });
}


function HaliSahaSil(id) {
    Delete(`Halisaha/Id?id=${id}`, (data) => {
        HalisahalariGetir();
    });
}

function HaliSahaDuzenle(id, ad) {
    selectedHaliSahaId = id;
    $("#inputHaliSahaAd").val(ad);
    $("#haliSahaModal").modal("show");
}

$(document).ready(function () {
    HaliSahalariGetir();
});
