var msgs = [];
function validForm() {
    msgs = [];
    var campo;
    var isValid = true;

    campo = $("#Fabricante").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Fabricante').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher com o nome do <b>Cliente</b>.");
    } else {
        $('#Fabricante').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#modelo').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#modelo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher com o <b>Modelo do veículo</b>.");
    } else {
        $('#modelo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    //Input ano
    campo = $('#disabledTextInput').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#disabledTextInput').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher com <b>E-mail</b>.");
    } else {
        $('#disabledTextInput').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#qtportas option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#qtportas').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o nome do <b>Cliente</b>.");
    } else {
        $('#qtportas').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Valor').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Valor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher a <b>Data de Nascimento</b>.");
    } else {
        $('#Valor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    return isValid;
}
