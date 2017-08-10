using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using static VendaDeAutomoveis.Entidades.Venda;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Adapters
{
    public static class VendaAdappter
    {
        public static Venda ToDomain(this GDC_Vendas dbVeiculos)
        {
            if (dbVeiculos == null) return null;

            return new Venda
            {
                Id = Guid.Parse(dbVeiculos.Id),
                Valor = dbVeiculos.Valor,
                DataCompra = DateTime.Now,
                TipoEntrega = (Entrega)char.Parse(dbVeiculos.Tipo_Entrega),
                //Status = status
                //TermoAutorizacao = termoautorizacao
                IdCliente = Guid.Parse(dbVeiculos.IdCliente),
                IdProduto = Guid.Parse(dbVeiculos.IdVeiculo),
                IdFormaDePagamento = Guid.Parse(dbVeiculos.IdFormaPagamento),
                IdPerfomance = Guid.Parse(dbVeiculos.IdPerformance)
            };
        }

        public static GDC_Vendas ToDbEntity(this Venda domain)
        {
            if (domain == null)
                return null;

            return new GDC_Vendas
            {
                Id = domain.Id.ToString(),
                Valor = Convert.ToDecimal(domain.Valor),
                Tipo_Entrega = domain.TipoEntrega.ToString(),
                //Status = status
                //TermoAutorizacao = termoautorizacao
                IdCliente = domain.IdCliente.ToString(),
                IdVeiculo = domain.IdProduto.ToString(),
                IdFormaPagamento = domain.IdFormaDePagamento.ToString(),
                IdPerformance = domain.IdPerfomance.ToString()
            };
        }

        public static IList<GDC_Vendas> ToDbEntityList(IList<Venda> domain)
        {
            if (domain == null)
                return null;

            return domain.Select(d => ToDbEntity(d)).Where(d => d != null).ToList();
        }
    }
}