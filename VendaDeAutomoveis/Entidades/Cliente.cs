using DomainValidation.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using VendaDeAutomoveis.Validation;

namespace VendaDeAutomoveis.Entidades
{
    public class Cliente
    {
        public Cliente()
        {
            IdCliente = Guid.NewGuid();
        }

        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCliente { get; set; }

        //[Required(ErrorMessage = "Informe o nome do cliente")]
        //[StringLength(30, MinimumLength = 3)]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "Informe o número RG do cliente")]
        public string RG { get; set; }

        //[Required(ErrorMessage = "Informe o número de CPF/MF do cliente")]
        public string CPF { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        //[Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        //[Required(ErrorMessage = "Informe em qual perfil o cliente se enquadra")]
        public TipoCliente TipoDoCliente { get; set; }

        public Guid? IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }

        //[Required, EmailAddress]
        public string Email { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public enum TipoCliente
        {
            Vip = 'V',
            Comum = 'C'
        }

        public static Cliente MudarClienteParaVip(Cliente cliente)
        {
            if (cliente.TipoDoCliente == TipoCliente.Comum)
                cliente.TipoDoCliente = TipoCliente.Vip;

            return cliente;
        }
    }
}