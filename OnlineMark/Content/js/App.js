

$("#group").ready(function () {
    $("#group").show();
})

function onShowClick() {
    if ($("#show").is(":checked")) {
        $("#group").show(1000);
    }
    else {
        $("#Group").val("");
        $("#group").hide(1000);
    }
}

function getValues() {
    var allTableElements = $(".table").find("input");
    var res = [];
    var obj = {
        id : null,
        value: null,
        description : null
    };
    jQuery.each(allTableElements, function (i, val) {
        var id = $(val)[0].id;
        obj.id = id.split('_')[1];
        if (id.split('_')[0] == 'Value') {
            obj.value = $(val).val();
        } else {
            obj.description = $(val).val();
            res.push(obj);
            obj = {
                id: null,
                value: null,
                description: null
            }
        }

    });
    return res;
}

function saveChanges() {
    var values =  getValues();

    $.ajax({
        type: "POST",
        url: "/Course/SaveChanges",
        data: JSON.stringify(values),
        success: function (result) {
            alert(result.Result);
        },
        error: function (jqXHR, exception) {
            alert('Error message.' + exception);
        },
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        traditional: true
    });

}