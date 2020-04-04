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
    if (value !== last) {
        $("#vote-" + value + 1).show();
        console.log($("#vote-" + value + 1));
    }
    else {
        $("#last").show();
    }
}