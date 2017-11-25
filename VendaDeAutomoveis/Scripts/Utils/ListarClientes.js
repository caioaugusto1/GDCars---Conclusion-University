function confirmarDelete(id, clienteNome)
{
    $('#modalDelete').modal();

    $('#textoExclusao').html('Você tem certeza que deseja excluir esse Cliente: ' + clienteNome);

    $('#idObj').val(id);
}

$(function () {
    $('#confirmarDelete').click(function () {

        $.ajax({
            url: 'Excluir/Cliente',
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
        });
        $('#modalDelete').modal("toggle");
    });
});

 