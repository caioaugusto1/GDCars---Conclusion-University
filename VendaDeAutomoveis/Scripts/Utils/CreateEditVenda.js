$(function () {
    $('#parcialEndereco').hide();
});

$('#IdVeiculo').change(function () {
    if ($('#IdVeiculo').val() == "") {
        $('#Valor').val('0');
    } else {
        obterValorVeiculo();
    }
});

$('#Tipo_Entrega').change(function () {

    if ($('#Tipo_Entrega').val() == "0") {
        $('#parcialEndereco').show();
    } else {
        $('#parcialEndereco').hide();
    }
});

$('#IdCliente').change(function () {
    obterInformacoesCliente();
});

$("#btnSalvarEndereco").click(function () {
    $('#modalConfirme').modal();
});

$('#btnSalvarEndereco').click(function () {
    AtualizarEndereco();
});

function obterValorVeiculo() {
    $.ajax({
        url: 'ObterValorVeiculo',
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

function AtualizarEndereco() {

    $.ajax({
        url: 'AtualizarEnderecos',
        type: "post",
        dataType: "html",
        data: {
            IdCliente: $("#IdCliente").val(),
            Endereco: $("#enderecoNome").val(),
            Bairro: $("#bairro").val(),
            NumeroDaCasa: $("#numero").val(),
            CEP: $("#cep").val(),
            Cidade: $("#cidade").val(),
            Estado: $("#estado").val(),
            Complemento: $("#complemento").val()
        },
        success: function (data) {
            $('#success').modal();
        }
    });
}

function obterInformacoesCliente() {

    $.ajax({
        url: 'ObterInformacoesBasicasCliente',
        type: "POST",
        dataType: "json",
        data: { IdCliente: $("#IdCliente").val() },
        success: function (data) {
            var attrFormaPagamento = $('#formaPagamento');

            $(attrFormaPagamento).find('option').remove();
            $(attrFormaPagamento).append('<option>Formas de Pagamentos</option>');

            $.each(data.formasDePagamento, function (index, item) { // item is now an object containing properties ID and Text
                $(attrFormaPagamento).append('<option value="' + item.Id + '">' + item.Modelo + '</option>');
            });

            var attrCustoms = $('#customs');
            $(attrCustoms).find('option').remove();
            $(attrCustoms).append('<option>Customizações</option>');

            $.each(data.customs, function (index, item) { // item is now an object containing properties ID and Text
                $(attrCustoms).append('<option value="' + item.Id + '">' + item.ValorTotal + '</option>');
            });

            $('#enderecoNome').val(data.endereco.EnderecoNome);
            $('#numero').val(data.endereco.Numero);
            $('#complemento').val(data.endereco.Complemento);
            $('#bairro').val(data.endereco.Bairro);
            $('#cep').val(data.endereco.CEP);
            $('#cidade').val(data.endereco.Cidade);
            $('#estado').val(data.endereco.Estado);
        }
    });
};


var msgs = [];
function validForm() {
    msgs = [];
    var campo;
    var isValid = true;

    campo = $("#IdCliente option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#IdCliente').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Cliente</b>.");
    } else {
        $('#IdCliente').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#IdVeiculo option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#IdVeiculo').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Veículo</b>.");
    } else {
        $('#IdVeiculo').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Valor").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Valor').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Valor</b>.");
    } else {
        $('#IdCliente').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#customs option:selected").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#customs').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencha o cliente.");
    } else {
        $('#customs').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Tipo_Entrega option:selected").text();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Tipo_Entrega').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Tipo de Entrega</b>.");
    } else {
        $('#Tipo_Entrega').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $("#Status option:selected").text();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Status').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Status</b>.");
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