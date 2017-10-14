using Dapper;
using System;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;
using System.Collections.Generic;

namespace VendaDeAutomoveis.Repository
{
    public class PerfomanceRepository : RepositoryBase<GDC_Perfomances>, IPerfomanceRepository
    {
        public PerfomanceRepository(ContextGDCars context)
            : base(context)
        {

        }

        public override void Inserir(GDC_Perfomances obj)
        {
            var sql = "Insert into GDC_Perfomances (Id, IdCliente, IdRoda, IdBanco, IdCor_Veiculo, ValorTotal) " +
              "Values(@Id, @IdCliente, @IdRoda, @IdBanco, @IdCor_Veiculo, @ValorTotal )";

            var e = _context.Database.Connection.Query<GDC_Perfomances>(sql,
                param: new
                {
                    Id = obj.Id,
                    IdCliente = obj.IdCliente,
                    IdRoda = obj.IdRoda,
                    IdBanco = obj.IdBanco,
                    IdCor_Veiculo = obj.IdCor_Veiculo,
                    ValorTotal = obj.ValorTotal
                });
        }

        public override IList<GDC_Perfomances> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Perfomances WHERE IdBanco IS NOT NULL AND IdBanco IS NOT NULL AND IdCor_Veiculo IS NOT NULL ";

            return _context.Database.Connection.Query<GDC_Perfomances>(sql).ToList();
        }

        public IList<GDC_Perfomances> ObterPorIdCliente(Guid idCliente)
        {
            var sql = "SELECT * FROM GDC_Perfomances where IdCliente = @IdCliente ";

            return _context.Database.Connection.Query<GDC_Perfomances>(sql,
                    param: new
                    {
                        IdCliente = idCliente
                    }).ToList();
        }
    }
}