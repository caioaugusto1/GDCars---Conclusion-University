$(function () {

    $('#parcialEndereco').hide();

    @if (ViewBag.ExibirCampo != null) {
        @:pegarValorEndereco();
    }
});

$('#IdVeiculo').change(function () {
    obterValorVeiculo();
});

$('#Tipo_Entrega').change(function () {
    pegarValorEndereco();
});

$('#IdCliente').change(function () {
    pegarValorEndereco();
    obterInformacoesCliente();
});

$("#btnSalvarEndereco").click(function () {
    $('#modalConfirme').modal();
});

$('#btnSalvarModal').click(function () {
    AtualizarEndereco();
});

function obterValorVeiculo() {
    $.ajax({
        url: '@Url.Action("ObterValorVeiculo")',
        type: "post",
        dataType: "html",
        data:
        {
            idVeiculo: $("#IdVeiculo").val()
        },
        success: function (data) {
            $("#Valor").val(data);
            $("#Valor").text(data);
        }
    });
}

function pegarValorEndereco() {

    if ($("#IdCliente").val() != '' && $("#Tipo_Entrega").val() == 1) {
        $('#parcialEndereco').hide();
    }

    if ($("#IdCliente").val() != '' && $("#Tipo_Entrega").val() == 0) {
        $('#parcialEndereco').show();

        $.ajax({
            url: '@Url.Action("ObterEnderecoCliente")',
            type: "post",
            dataType: "html",
            data: { IdCliente: $("#IdCliente").val() },
            success: function (data) {
                $('#parcialEndereco').html(data);
                //$("#atualizar").click(function () {

                //    AtualizarEndereco()
                //});
            }
        });
    }
}


function AtualizarEndereco() {

    $.ajax({
        url: '@Url.Action("AtualizarEnderecos")',
        type: "post",
        dataType: "html",
        data: {
            IdCliente: $("#IdCliente").val(),
            Endereco: $("#EnderecoNome").val(),
            Bairro: $("#Bairro").val(),
            NumeroDaCasa: $("#Numero").val(),
            CEP: $("#CEP").val(),
            Cidade: $("#Cidade").val(),
            Estado: $("#Estado").val(),
            Complemento: $("#Complemento").val()
        },
        success: function (data) {
            $('#success').modal();
        }
    });
}

function obterInformacoesCliente() {

    $.ajax({
        url: '@Url.Action("ObterInformacoesBasicasCliente")', //Metodo da minha controller
        type: "POST",
        dataType: "html",
        data: { IdCliente: $("#IdCliente").val() },
        success: function (data) {

            $('#PegarFormaDePagamento').html(data.FormasDePagamentos); //div para renderizar
            $('#_PerformancesDisponiveisCliente').html(data.Performances);
        }
    });
}

var msgs = [];
function validForm() {
    msgs = [];
    var campo;
    var isValid = true;

    campo = $("#IdCliente option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#IdCliente').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Cliente.<\b>");
    } else {
        $('#IdCliente').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#IdVeiculo option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#IdVeiculo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Veículo.<\b>");
    } else {
        $('#IdVeiculo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Valor").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Valor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Valor.<\b>");
    } else {
        $('#IdCliente').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#idCustom option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#idCustom').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencha o cliente.");
    } else {
        $('#idCustom').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Tipo_Entrega option:selected").text();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Tipo_Entrega').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Tipo de Entrega.<\b>");
    } else {
        $('#Tipo_Entrega').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Status option:selected").text();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Status').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Status.<\b>");
    } else {
        $('#Status').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    //campo observação
    campo = $('#wysiwyg').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#wysiwyg').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o Modelo do veículo.");
    } else {
        $('#wysiwyg').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    return isValid;
}