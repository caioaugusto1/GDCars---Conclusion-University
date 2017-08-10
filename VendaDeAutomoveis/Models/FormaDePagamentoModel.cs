using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Models
{
    public class FormaDePagamentoModel
    {
        public int? IdCliente { get; set; }
        public IList<FormaDePagamento> FormaDePagmamento { get; set; }
    }
}