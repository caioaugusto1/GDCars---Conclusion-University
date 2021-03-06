﻿
var msgs = [];
function validForm() {
    msgs = [];
    var campo;
    var isValid = true;

    campo = $("#EnderecoNome").val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#EnderecoNome').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher com o <b>Endereço do cliente</b>.");
    } else {
        $('#EnderecoNome').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Numero').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Numero').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Número do Endereço</b>.");
    } else {
        $('#Numero').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#CEP').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#CEP').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>CEP</b>.");
    } else {
        $('#CEP').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Estado').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Estado').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>Estado</b>.");
    } else {
        $('#Estado').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Bairro').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Bairro').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher o <b>bairro</b>.");
    } else {
        $('#Bairro').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    campo = $('#Cidade').val();
    if (!campo && campo.length <= 0) {
        isValid = false;
        $('#Cidade').css({ "background-color": "#f8dbdb", "border-color": "#e77776" });
        msgs.push("É necessário preencher a <b>Cidade</b>.");
    } else {
        $('#Cidade').css({ "background-color": "#fff", "border-color": "#ccc" });
    }

    return isValid;
}