using System;
using System.Collections.Generic;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IVendasRepository : IRepository<Venda>
    {
        IList<Venda> BuscarPorCliente(Guid? id);

        double GastosPorCliente(Guid id);
    }
}
