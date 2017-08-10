using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IVendasRepository : IRepository<Venda>
    {
        IList<Venda> BuscarPorCliente(Guid? id);

        decimal GastosPorCliente(Guid id);
    }
}
