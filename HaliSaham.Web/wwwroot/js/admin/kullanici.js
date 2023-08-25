function KullanicilariGetir() {
    Get("Kullanici/TumKullanicilar", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Kullanıcı Adı</th><th>Kullanıcı Soyadı</th><th>Kullanıcı Şifresi</th><th>Kullanıcı E-Posta</th><th>Kullanıcı Telefonu</th><th>Kullanıcı Rol Id</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td><td>${arr[i].soyad}</td><td>${arr[i].sifre}</td><td>${arr[i].ePosta}</td><td>${arr[i].telefon}</td><td>${arr[i].rolId}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='KullaniciSil(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='KullaniciDuzenle(${arr[i].id},"${arr[i].ad})'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divKullanicilar").html(html);
    });
}

let selectedKullaniciId = 0;
let selectedRolId = 3;

function YeniKullanici() {

    selectedKullaniciId = 0;
    selectedRolId = 3


    $("#inputKullaniciAd").val("");

    $("#kullaniciModal").modal("show");
}
    function KullaniciKaydet() {
        var kullanici = {
            Id: selectedKullaniciId,
            Ad: $("#inputKullaniciAd").val(),
            Soyad: $("#inputKullaniciSoyad").val(),
            Sifre: $("#inputKullaniciSifre").val(),
            EPosta: $("#inputKullaniciEPosta").val(),
            Telefon: $("#inputKullaniciTelefon").val(),
            RolId: selectedRolId,
        };
        Post("Kullanici/Kaydet", kullanici, (data) => { KullanicilariGetir(); $("#kullaniciModal").modal("hide"); });
    }


    function KullaniciSil(id) {
        Delete(`Kullanici/Sil?id=${id}`, (data) => {
            KullanicilariGetir();
        });
    }

    function KullaniciDuzenle(id,ad) {
        selectedKullaniciId = id;
        $("#inputKullaniciAd").val(ad);
        $("#kullaniciModal").modal("show");
    }

    $(document).ready(function () {
        KullanicilariGetir();
    });
