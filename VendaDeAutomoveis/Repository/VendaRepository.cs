using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class VendaRepository : RepositoryBase<GDC_Vendas>, IVendasRepository
    {
        public VendaRepository(ContextGDCars context)
            : base(context)
        {
        }
        
        public double GastosPorCliente(Guid id)
        {
            return _context.Vendas.Where(c => c.Id == id).Sum(c => c.Valor);
        }

        public override GDC_Vendas ObterPorId(Guid id)
        {
            var sql = "SELECT * FROM GDC_Vendas where Id = @id ";
            
            var e = _context.Database.Connection.Query(sql,
                param: new
                {
                    id = id
                });

            return e.FirstOrDefault();
        }

        public override IList<GDC_Vendas> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Vendas ";

            return _context.Database.Connection.Query<GDC_Vendas>(sql)
                .OrderBy(c => c.GDC_Clientes.Nome)
                .ToList();
        }

        public IList<GDC_Vendas> BuscarPorCliente(Guid? idCliente)
        {
            var sql = "SELECT * FROM GDC_Vendas where IdCliente = @idCliente ";

            var e = _context.Database.Connection.Query(sql,
                param: new
                {
                    idCliente = idCliente
                });

            return e.FirstOrDefault();
        }
    }
}