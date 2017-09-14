using System;
using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Veiculo : Entity
    {

        [Required(ErrorMessage = "Informe o Nome do Fabricante")]
        [StringLength(30, MinimumLength = 3)]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Informe o  Nome do Veiculo")]
        [StringLength(30, MinimumLength = 3)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Informe o Ano de Fabricação")]
        public DateTime Ano { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade de Portas")]
        public int QuantidadeDePortas { get; set; }

        [Required(ErrorMessage = "Informe o Preço do Veiculo")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Informe o Tipo do Veiculo")]
        public Tipo Tipo { get; set; }
    }

    public enum Tipo
    {
        Esportivo, Hatch, Sedã, Picape, Perua,
    }
}