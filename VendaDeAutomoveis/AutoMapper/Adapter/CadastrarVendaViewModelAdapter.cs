using System;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Models;

namespace VendaDeAutomoveis.AutoMapper.Adapter
{
    public static class CadastrarVendaViewModelAdapter
    {
        public static CadastrarVendaViewModel ToDomain(this Venda dbVendas)
        {
            if (dbVendas == null) return null;
            
            return new CadastrarVendaViewModel
            {
                IdCliente = Guid.Parse(dbVendas.IdCliente.ToString()),
                IdVeiculo = Guid.Parse(dbVendas.IdVeiculo.ToString()),
                IdFormaDePagamento = Guid.Parse(dbVendas.IdFormaDePagamento.ToString()),
                IdPerformance = Guid.Parse(dbVendas.IdPerfomance.ToString()),
                IdVenda = Guid.Parse(dbVendas.Id.ToString()),
                Valor = (double)dbVendas.Valor,
                Tipo_Entrega = Enums.EnumsExtensions.EntregaVenda.Loja,
                Status = Enums.EnumsExtensions.StatusVenda.Efetuado,
                Observacoes = "seiquela"
            };
        }

        public static Venda ToDbEntity(this CadastrarVendaViewModel domain)
        {
            if (domain == null)
                return null;
            
            return new Venda
            {
               
            };
        }
    }
}