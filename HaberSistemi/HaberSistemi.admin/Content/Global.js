function KategoriEkle() {
    var kategori = {};
    kategori.KategoriAdi = $("#kategoriAdi").val();
    kategori.URL = $("#kategoriUrl").val();
    kategori.AktifMi = $("#kategoriAktif").is(":checked");
    kategori.ParentID = $("#ParentID").val();
    $.ajax({
        url: "/Kategori/Ekle",
        data: kategori,
        type: "POST",
        dataType: "json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });

            }
        }
    });
}