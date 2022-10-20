function PreviewImage() {
    if ($("#uploadImage")[0].files.length > 5) {
        swal({
            title: " En Fazla 5 Adet Resim Yükleyebilirsiniz..!", icon: "error",button: "KAPAT",});
        document.getElementById('uploadImage').value = "";
    } else {
        $("#uploadPreview").html("");
        for (var i = 0; i < 6; i++) {
            var oFReader = new FileReader();
            oFReader.readAsDataURL(document.getElementById("uploadImage").files[i]);
            oFReader.onload = function (oFREvent) {
                $("#uploadPreview").append('<img  class= "img-fluid img" style = "width:250px!important;border:solid 0.3mm #e6e6e6;margin:5px;padding:5px;" src="' + oFREvent.target.result + '"/>');
            };
        }
    }
}