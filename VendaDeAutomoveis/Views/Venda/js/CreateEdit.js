$(function () {
    $('#parcialEndereco').hide();
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

$("#atualizar").click(function () {
    $('#modalConfirme').modal();
});

$('#btnConfirmarAlteracoes').click(function () {
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
            alert("Endereço Alterado");
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