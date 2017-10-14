

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
    debugger;
    if ($("#IdCliente").val() != '' && $("#Tipo_Entrega").val() == 2) {
        debugger;
        $('#viewParcialEndereco').hide();
    }

    if ($("#IdCliente").val() != '' && $("#Tipo_Entrega").val() == 1) {
        debugger;
        $('#viewParcialEndereco').show();

        $.ajax({
            url: '@Url.Action("ObterEnderecoCliente")',
            type: "post",
            dataType: "html",
            data: { IdCliente: $("#IdCliente").val() },

            success: function (data) {
                $('#viewParcialEndereco').html(data);
                $("#atualizar").click(function () {

                    AtualizarEndereco()
                });
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
            Endereco: $("#Endereco").val(),
            Bairro: $("#Bairro").val(),
            NumeroDaCasa: $("#NumeroDaCasa").val(),
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
            $('#_ParcialViewFormaDePagamento').html(data.FormasPagamentos); //div para renderizar
            $('#_PerformancesDisponiveisCliente').html(data.Performances);
        }
    });
}
