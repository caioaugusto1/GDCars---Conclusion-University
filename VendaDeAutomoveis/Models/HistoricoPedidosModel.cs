using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Models
{
    public class HistoricoPedidosModel
    {
        public Guid IdCliente { get; set; }
        public IList<Venda> Vendas { get; set; }
        public IList<Cliente> Clientes { get; set; }
    }
}