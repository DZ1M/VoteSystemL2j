$(document).ready(function () {

    $("#iniciar").click(function () {
        $("#vote-1").show();
        $("#iniciar").hide();
    });
    $(".validar").click(function () {
        if (confirm("Tem certeza que deseja receber neste personagem?")) {
            $.ajax({
                url: "/Vote/Validar?charId=" + $("#char").val(),
                method: "get",
                type: "json",
                success: function (data) {
                    alert(data);
                    location.reload();
                }
            });
        }
    });
});

function clickou(value, last) {
    let newValue = parseInt(value) + 1;
    console.log('valor ' + value + ' last: ' + last + 'newValue: ' + newValue);
    if (parseInt(value) !== parseInt(last)) {
        $("#vote-" + newValue).show();
        console.log($("#vote-" + newValue));
    }
    else {
        $("#last").show();
    }
}