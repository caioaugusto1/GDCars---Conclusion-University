using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Entidades
{
    public class FormaDePagamento
    {
        public FormaDePagamento()
        {
            IdFormaDePagamento = Guid.NewGuid();
        }

        [Key]
        public Guid IdFormaDePagamento { get; set; }
        public string ModeloFormaDePagamento { get; set; }
        public string TipoDoCliente { get; set; }
    }

    public enum ModelosDePagamento
    {
        PagamentoAVista = 1,
        PagamentoAPrazo12xComJuros = 2,
        PagamentoAPrazo12xSemJuros = 3,
        PagamentoAPrazo60xComJuros = 4,
        PagamentoAPrazo60xSemJuros = 5
    }
}