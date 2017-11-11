using System.Collections.Generic;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Models
{
    public class ListarVendasViewModel
    {
        public List<Venda> Vendas { get; set; }

        public List<Cliente> Clientes { get; set; }

        public List<Veiculo> Veiculos { get; set; }

        public List<FormaDePagamento> FormasDePagamentos { get; set; }

        public List<Performance> Customs { get; set; }

    }
}