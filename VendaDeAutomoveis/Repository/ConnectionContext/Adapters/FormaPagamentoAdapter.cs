using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Adapters
{
    public static class FormaPagamentoAdapter
    {
        public static FormaDePagamento ToDomain(this GDC_Formas_Pagamentos dbFormaP)
        {
            if (dbFormaP == null) return null;

            var guid = Guid.NewGuid();

            return new FormaDePagamento
            {
                IdFormaDePagamento = Guid.Parse(dbFormaP.Id),
                ModeloFormaDePagamento = dbFormaP.Modelo,
                TipoDoCliente = dbFormaP.Tipo_Cliente
            };
        }

        public static GDC_Formas_Pagamentos ToDbEntity(this FormaDePagamento domain)
        {
            if (domain == null)
                return null;

            return new GDC_Formas_Pagamentos
            {
                Id = domain.IdFormaDePagamento.ToString(),
                Modelo = domain.ModeloFormaDePagamento,
                Tipo_Cliente = domain.TipoDoCliente
            };
        }

        public static IEnumerable<GDC_Formas_Pagamentos> ToDbEntityList(IEnumerable<FormaDePagamento> domain)
        {
            if (domain == null)
                return null;

            return domain.Select(d => ToDbEntity(d)).Where(d => d != null).ToList();
        }
    }
}