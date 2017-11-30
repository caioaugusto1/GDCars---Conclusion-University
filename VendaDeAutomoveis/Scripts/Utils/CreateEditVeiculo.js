var msgs = [];
function validForm() {
    msgs = [];
    var campo;
    var isValid = true;

    campo = $("#Fabricante").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Fabricante').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o nome da <b>Fabricante</b>.");
    } else {
        $('#Fabricante').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#modelo').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#modelo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o nome do <b>Modelo</b>.");
    } else {
        $('#modelo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    //Input ano
    campo = $('#disabledTextInput').val();
    if (!campo && campo <= 0) {
        isValid = false;
        $('#disabledTextInput').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher com <b>Ano</b>.");
    } else {
        $('#disabledTextInput').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#qtportas option:selected").val();
    if (campo == "Selecione" || campo == "") {
        isValid = false;
        $('#qtportas').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário selecionar a <b>Quantidade de Portas</b>.");
    } else {
        $('#qtportas').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Tipo option:selected").val();
    if (campo == "Selecione" || campo == "") {
        isValid = false;
        $('#Tipo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Tipo</b>.");
    } else {
        $('#Tipo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Valor').val();
    if (!campo && campo <= 0) {
        isValid = false;
        $('#Valor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Valor</b>.");
    } else {
        $('#Valor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    return isValid;
}
