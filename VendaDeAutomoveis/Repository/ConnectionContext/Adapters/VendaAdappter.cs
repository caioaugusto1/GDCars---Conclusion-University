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
                Id = Guid.Parse(dbVeiculos.Id.ToString()),
                Valor = dbVeiculos.Valor,
                DataCompra = DateTime.Now,
                TipoEntrega = (Entrega)char.Parse(dbVeiculos.Tipo_Entrega),
                //Status = status
                //TermoAutorizacao = termoautorizacao
                IdCliente = Guid.Parse(dbVeiculos.IdCliente.ToString()),
                IdProduto = Guid.Parse(dbVeiculos.IdVeiculo.ToString()),
                IdFormaDePagamento = Guid.Parse(dbVeiculos.IdFormaPagamento.ToString()),
                IdPerfomance = Guid.Parse(dbVeiculos.IdPerformance.ToString())
            };
        }

        public static GDC_Vendas ToDbEntity(this Venda domain)
        {
            if (domain == null)
                return null;

            return new GDC_Vendas
            {
                Id = domain.Id,
                Valor = Convert.ToDecimal(domain.Valor),
                Tipo_Entrega = domain.TipoEntrega.ToString(),
                //Status = status
                //TermoAutorizacao = termoautorizacao
                IdCliente = domain.IdCliente,
                IdVeiculo = domain.IdProduto,
                IdFormaPagamento = domain.IdFormaDePagamento,
                IdPerformance = domain.IdPerfomance
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