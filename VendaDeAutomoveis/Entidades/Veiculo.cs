using System;
using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Veiculo : Entity
    {
        //[Key]
        //[Required(ErrorMessage = "O campo ID do Veiculo é obrigatório")]
        //public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Fabricante")]
        [StringLength(30, MinimumLength = 3)]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Informe o  Nome do Veiculo")]
        [StringLength(30, MinimumLength = 3)]
        public string ModeloVeiculo { get; set; }

        //[Required(ErrorMessage = "Informe o Ano de Fabricação")]
        public DateTime Ano { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade de Portas")]
        public int QuantidadeDePortas { get; set; }

        //[Required(ErrorMessage = "Informe o Preço do Veiculo")]
        //public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe o Tipo do Veiculo")]
        public VeiculoTipo TipoVeiculo { get; set; }
    }

    public enum VeiculoTipo
    {
        Esportivo = 1, Hatch = 2, Sedã = 3, Picape = 4, Perua = 5,
    }
}