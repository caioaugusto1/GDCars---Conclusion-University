function confirmarDelete(id, veiculoNome)
{
    $('#modalDelete').modal();

    $('#textoExclusao').html('Você tem certeza que deseja excluir esse veículo: ' + veiculoNome);

    $('#idObj').val(id);
}

$(function () {
    $('#confirmarDelete').click(function () {
        $('#modalDelete').modal('toggle');
        
        $.ajax({
            url: "/administrativo-veiculo/Excluir-Veiculo",
            type: "POST",
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
});
