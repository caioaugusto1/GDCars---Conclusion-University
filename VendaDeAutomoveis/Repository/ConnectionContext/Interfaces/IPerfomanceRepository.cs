using System;
using System.Collections.Generic;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IPerfomanceRepository : IRepositoryBase<GDC_Perfomances>
    {
        IList<GDC_Perfomances> ObterPorIdCliente(Guid idCliente);
    }
}
