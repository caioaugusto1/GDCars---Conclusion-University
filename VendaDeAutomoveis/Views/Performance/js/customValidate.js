$('#btnConfirmarAlteracoes').click(function () {
    var isValid = validForm();

    if (isValid == false) {
        saveLead();
    }
    else {
        $('#modalConfirme').modal();
    }

});

var msgs = [];
function validForm() {
    msgs = [];
    var campo;
    var isValid = true;

    campo = $("#IdCliente option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#IdCliente').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencha o cliente.");
    } else {
        $('#IdCliente').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#RodaModelo').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#RodaModelo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o Modelo do veículo.");
    } else {
        $('#RodaModelo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Aro').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Aro').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o Modelo do veículo.");
    } else {
        $('#Aro').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#RodaValor').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#RodaValor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o Modelo do veículo.");
    } else {
        $('#RodaValor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Estilo").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Estilo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário fornecer um e-mail válido!");
    } else {
        $('#Estilo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#CorRoda").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#CorRoda').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário fornecer um e-mail válido!");
    } else {
        $('#CorRoda').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#CorValor').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#CorValor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o Modelo do veículo.");
    } else {
        $('#CorValor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#ModeloBanco option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#ModeloBanco').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencha o cliente.");
    } else {
        $('#ModeloBanco').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#CorBanco option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#CorBanco').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencha o cliente.");
    } else {
        $('#CorBanco').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#BancoValor').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#BancoValor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o Modelo do veículo.");
    } else {
        $('#BancoValor').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    return isValid;
}

function saveLead() {
    var form = document.forms[0];
    if (validForm()) {
        form.submit();
    }
    else {
        var novoHTML = "";
        for (var i = 0; i < msgs.length; i++) {
            var msg = msgs[i];
            novoHTML += msg + "<br />";
        }
        $('#modalConfirme .modal-body').html(novoHTML);
        $('#modalConfirme').modal('show');
        document.body.scrollTop = document.documentElement.scrollTop = 0;
    }
}
