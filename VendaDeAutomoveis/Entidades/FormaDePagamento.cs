using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class FormaDePagamento : Entity
    {
        public string Modelo { get; set; }

        public Cliente.TipoCliente Tipo_Cliente { get; set; }
    }

    public enum ModelosDePagamento
    {
        //Todos os clientes
        [Display(Name = "À Vista")]
        PagamentoAVista = 1,
        //Não vips 3% ao mês
        [Display(Name = "Prazo 12x com Juros")]
        PagamentoAPrazo12xComJuros = 2,
        //Vips
        [Display(Name = "Prazo 12x sem Juros")]
        PagamentoAPrazo12xSemJuros = 3,
        //Não vips 5% ao mes
        [Display(Name = "Prazo 60x com Juros")]
        PagamentoAPrazo60xComJuros = 4,
        //Vips
        [Display(Name = "Prazo 60x sem Juros")]
        PagamentoAPrazo60xSemJuros = 5
    }
}