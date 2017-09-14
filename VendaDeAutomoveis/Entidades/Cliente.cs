using System;
using System.ComponentModel.DataAnnotations;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Cliente : Entity
    {

        [Required(ErrorMessage = "Informe o nome do cliente")]
        [StringLength(30, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o número RG do cliente")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Informe o número de CPF/MF do cliente")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe em qual perfil o cliente se enquadra")]
        public TipoCliente Tipo { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime Data_Nascimento { get; set; }
        
        public Guid? IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }

        //public ValidationResult ValidationResult { get; set; }

        //public bool EhValido()
        //{
        //    ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
        //    return ValidationResult.IsValid;
        //}

        public static Cliente MudarClienteParaVip(Cliente cliente)
        {
            if (cliente.Tipo == TipoCliente.Comum)
                cliente.Tipo = TipoCliente.Vip;

            return cliente;
        }
    }
}