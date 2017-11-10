
$('#btnCadastrar').click(function () {
    var isValid = validForm();

    if (isValid == false) {
        saveLead();
    }
    else {
        formSubmit();
    }
});

$('#btnSalvarModal').click(function () {
    var isValid = validForm();

    if (isValid == false) {
        saveLead();
    }
    else {
        formSubmit();
    }
});

function formSubmit()
{
    $('#form').submit();
};


function validarCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;

    strCPF = strCPF.replace(/[^\d]+/g, '');

    if (strCPF == "00000000000" ||
        strCPF == "11111111111" ||
        strCPF == "22222222222" ||
        strCPF == "33333333333" ||
        strCPF == "44444444444" ||
        strCPF == "55555555555" ||
        strCPF == "66666666666" ||
        strCPF == "77777777777" ||
        strCPF == "88888888888" ||
        strCPF == "99999999999") return false;

    for (i = 1; i <= 9; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);

    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))
        Resto = 0;

    if (Resto != parseInt(strCPF.substring(9, 10)))
        return false;

    Soma = 0;
    for (i = 1; i <= 10; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);

    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))
        Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11)))
        return false;

    return true;
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@@\"]+(\.[^<>()[\]\\.,;:\s@@\"]+)*)|(\".+\"))@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
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
        $('#modalError .modal-body').html(novoHTML);
        $('#modalError').modal('show');
        document.body.scrollTop = document.documentElement.scrollTop = 0;
    }
}