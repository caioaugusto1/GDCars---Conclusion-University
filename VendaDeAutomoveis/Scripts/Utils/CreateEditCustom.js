var msgs = [];
function validForm() {
    msgs = [];
    var campo;
    var isValid = true;

    campo = $("#IdCliente option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#IdCliente').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o nome do <b>Cliente</b>.");
    } else {
        $('#IdCliente').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#RodaModelo').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#RodaModelo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Modelo do Veículo</b>.");
    } else {
        $('#RodaModelo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Aro').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Aro').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Tamanho do Aro</b>.");
    } else {
        $('#Aro').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#RodaValor').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#RodaValor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Valor da Roda</b>.");
    } else {
        $('#RodaValor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Estilo").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Estilo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário escolher o <b>Estilo</b>.");
    } else {
        $('#Estilo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#CorRoda").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#CorRoda').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário escolher a <b>Cor da Roda</b>.");
    } else {
        $('#CorRoda').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#CorValor').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#CorValor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Valor da Cor</b>.");
    } else {
        $('#CorValor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#ModeloBanco option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#ModeloBanco').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher um <b>Modelo de Banco</b>.");
    } else {
        $('#ModeloBanco').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#CorBanco option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#CorBanco').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher a <b>Cor do Banco</b>.");
    } else {
        $('#CorBanco').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#BancoValor').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#BancoValor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Valor do Banco</b>.");
    } else {
        $('#BancoValor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    return isValid;
}