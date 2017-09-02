using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Adapters
{
    public static class VeiculoAdapter
    {
        public static Veiculo ToDomain(this GDC_Veiculos dbVeiculos)
        {
            if (dbVeiculos == null) return null;

            var guid = Guid.NewGuid();

            return new Veiculo
            {
                Id = Guid.Parse(dbVeiculos.Id),
                Fabricante = dbVeiculos.Fabricante,
                ModeloVeiculo = dbVeiculos.Modelo,
                Ano = dbVeiculos.Ano,
                Valor = dbVeiculos.Valor,
                TipoVeiculo = (VeiculoTipo)char.Parse(dbVeiculos.Tipo)
                //IdUpload = Guid.Parse(dbVeiculos.IdUpload)
            };
        }

        public static GDC_Veiculos ToDbEntity(this Veiculo domain)
        {
            if (domain == null)
                return null;

            return new GDC_Veiculos
            {
                Id = domain.Id.ToString(),
                Fabricante = domain.Fabricante,
                Modelo = domain.ModeloVeiculo,
                Ano = DateTime.Now,
                Valor = Convert.ToDecimal(domain.Valor),
                Tipo = domain.TipoVeiculo.ToString()
            };
        }

        public static IEnumerable<GDC_Veiculos> ToDbEntityList(IEnumerable<Veiculo> domain)
        {
            if (domain == null)
                return null;

            return domain.Select(d => ToDbEntity(d)).Where(d => d != null).ToList();
        }
    }
}