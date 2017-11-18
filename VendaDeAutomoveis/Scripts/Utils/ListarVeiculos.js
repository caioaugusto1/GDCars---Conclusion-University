function confirmarDelete(id)
{
    $('#modalDelete').modal();

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
