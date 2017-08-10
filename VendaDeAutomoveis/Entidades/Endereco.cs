using System;
using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Endereco
    {
        public Endereco()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string EnderecoNome { get; set; }

        [StringLength(6)]
        public string Numero { get; set; }

        [StringLength(10)]
        public string Complemento { get; set; }

        public string CEP { get; set; }

        [StringLength(25)]
        public string Bairro { get; set; }

        [StringLength(20)]
        public string Cidade { get; set; }

        [StringLength(15)]
        public string Estado { get; set; }

        public virtual Cliente Cliente { get; set; }

        //[Required(ErrorMessage = "Informe o Cliente")]
        public Guid IdCliente { get; set; }

    }
}