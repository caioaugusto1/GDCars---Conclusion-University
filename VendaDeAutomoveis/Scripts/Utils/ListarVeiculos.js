function confirmarDelete(id, veiculoNome)
{
    $('#modalDelete').modal();

    $('#textoExclusao').html('Você tem certeza que deseja excluir esse veículo: ', veiculoNome);

    $('#idObj').val(id);
}

$('#confirmarDelete').click(function () {

    $.ajax({
        url: 'Excluir/Veiculo',
        type: "post",
        dataType: "html",
        data: {
            id: $('#idObj').val(),
        },
        success: function (data) {
            $('#success').modal();
        }, error: function () {
            $('#modalError').modal();
        }
    })
});
 