using Dapper;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class VeiculoRepository : RepositoryBase<GDC_Veiculos>, IVeiculoRepository
    {
        public VeiculoRepository(ContextGDCars context)
            : base(context)
        {
        }

        public override IList<GDC_Veiculos> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Veiculos ";

            return _context.Database.Connection.Query<GDC_Veiculos>(sql)
                .OrderBy(c => c.Modelo)
                .ToList();
        }
    }
}