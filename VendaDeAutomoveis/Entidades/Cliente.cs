using System;
using System.ComponentModel.DataAnnotations;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Cliente : Entity
    {

        [Required(ErrorMessage = "Informe o nome do cliente")]
        [StringLength(60, MinimumLength = 3)]
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

        [ScaffoldColumn(false)]
        public virtual Venda Venda { get; set; }

        [ScaffoldColumn(false)]
        public virtual Performance Custom { get; set; }

        public static Cliente MudarClienteParaVip(Cliente cliente)
        {
            if (cliente.Tipo == TipoCliente.Comum)
                cliente.Tipo = TipoCliente.Vip;

            return cliente;
        }

        public static bool ValidarIdadeMinima21Anos(Cliente cliente)
        {
            if (cliente.Data_Nascimento.AddYears(21) < DateTime.Now)
                return true;
            else
                return false;
        }
    }
}