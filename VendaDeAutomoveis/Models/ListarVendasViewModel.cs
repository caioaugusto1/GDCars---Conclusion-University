using System.Collections.Generic;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Models
{
    public class ListarVendasViewModel
    {
        public Venda Vendas { get; set; }

        public Cliente Clientes { get; set; }

        public Veiculo Veiculos { get; set; }

        public FormaDePagamento FormasDePagamentos { get; set; }

        public Performance Customs { get; set; }

    }
}