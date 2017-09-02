using System;
using System.ComponentModel.DataAnnotations;

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
        //Todos os clientes
        PagamentoAVista = 1,
        //Não vips 3% ao mês
        PagamentoAPrazo12xComJuros = 2,
        //Vips
        PagamentoAPrazo12xSemJuros = 3,
        //Não vips 5% ao mes
        PagamentoAPrazo60xComJuros = 4,
        //Vips
        PagamentoAPrazo60xSemJuros = 5
    }
}