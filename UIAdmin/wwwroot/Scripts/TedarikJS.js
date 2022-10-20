function VaryantDelete(id) {
    $.ajax({
        type: "POST",
        url: "/PartialView/VDelete",
        data: '{id:"' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('.VListe').load('/PartialView/Varyant');
        },
        failure: function (response) {

        }
    });
    return keyValue;
}

