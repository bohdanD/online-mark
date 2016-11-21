

$("#group").ready(function () {
    $("#group").show();
})

function onShowClick() {
    if ($("#show").is(":checked")) {
        $("#group").show(1000);
    }
    else {
        $("#group").hide(1000);
    }
}