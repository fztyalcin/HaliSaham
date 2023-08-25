function SehirleriGetir() {
    Get("Sehir/TumSehirler", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Şehir Adı</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='SehirSil(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='SehirDuzenle(${arr[i].id},"${arr[i].ad}")'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divSehirler").html(html);
    });
}



function YeniSehir() {

    $("#inputSehirId").val("");

    $("#inputSehirAd").val("");

    $("#sehirModal").modal("show");
}
function SehirKaydet() {
    var sehir = {
        Id: $("#inputSehirId").val(),
        Ad: $("#inputSehirAd").val()
    };
    Post("Sehir/Kaydet", sehir, (data) => {
        SehirleriGetir();

        $("#sehirModal").modal("hide");
    });
}


function SehirSil(id) {
    Delete(`Sehir/Sil?id=${id}`, (data) => {
        SehirleriGetir();
    });
}

function SehirDuzenle(id, ad) {
    Id = id;
    $("#inputSehirAd").val(ad);
    $("#sehirModal").modal("show");

    SehirleriGetir();
}

$(document).ready(function () {
    SehirleriGetir();
});

