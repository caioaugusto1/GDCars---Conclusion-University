using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

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
        public int Ano { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade de Portas")]
        public int QuantidadeDePortas { get; set; }

        [Required(ErrorMessage = "Informe o Preço do Veiculo")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Informe o Tipo do Veiculo")]
        public TipoVeiculo Tipo { get; set; }

        public Guid? IdUpload { get; set; }

        public virtual Upload Upload { get; set; }

        //public List<Veiculo> ListarAros()
        //{
        //    return new List<Veiculo>
        //    {
        //        new Veiculo  { Id = IdCli }
        //    }
        //}
    }
}