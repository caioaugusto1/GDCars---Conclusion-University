using System;
using System.Collections.Generic;
using VendaDeAutomoveis.Entidades;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Models
{
    public class CadastrarVendaViewModel
    {
        public Guid IdCliente { get; set; }

        public IList<Cliente> Clientes { get; set; }

        public Guid IdVeiculo { get; set; }

        public IList<Veiculo> Veiculos { get; set; }

        //public IList<Venda> Vendas { get; set; }

        public Guid IdFormaDePagamento { get; set; }

        public IList<FormaDePagamento> FormasDePagamentos { get; set; }

        public Guid IdPerformance { get; set; }

        public IList<Performance> Performance { get; set; }

        public Guid IdEndereco { get; set; }

        public Endereco Endereco { get; set; }
    
        public Guid IdVenda { get; set; }

        public Venda Venda { get; set; }

        public double Valor { get; set; }

        public double Parcela { get; set; }

        public EntregaVenda Tipo_Entrega { get; set; }

        public StatusVenda Status { get; set; }

        public string Observacoes { get; set; }
    }
}