using System;
using System.Collections.Generic;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IVendasRepository : IRepositoryBase<GDC_Vendas>
    {
        IList<GDC_Vendas> BuscarPorCliente(Guid? idCliente);

        double GastosPorCliente(Guid idCliente);
    }
}
