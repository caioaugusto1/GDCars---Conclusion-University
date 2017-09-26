using Dapper;
using System;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

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

        public void InserirPasso1Roda(Guid id, Guid idCliente, Guid idRoda, double ValorTotal)
        {
            var sql = "Insert into GDC_Perfomances (Id, IdCliente, IdRoda, ValorTotal ) " +
             "Values(@Id, @IdCliente, @IdRoda, @ValorTotal)";

            var e = _context.Database.Connection.Query<GDC_Perfomances>(sql,
                param: new
                {
                    Id = id,
                    IdCliente = idCliente,
                    IdRoda = idRoda,
                    ValorTotal = ValorTotal
                });
        }

        public void InserirPasso2Cor(Guid id, Guid idCorVeiculo)
        {
            var sql = "update GDC_Perfomances set IdCor_Veiculo = @idCorVeiculo" +
             " where Id = id";

            var e = _context.Database.Connection.Query<GDC_Perfomances>(sql,
                param: new
                {
                    Id = id,
                    IdCor_Veiculo = idCorVeiculo
                });
        }

        public void InserPasso3Banco(Guid id, Guid idBanco)
        {
            var sql = "update GDC_Perfomances set IdBanco = @idBanco" +
            " where Id = id";

            var e = _context.Database.Connection.Query<GDC_Perfomances>(sql,
                param: new
                {
                    Id = id,
                    IdBanco = idBanco
                });
        }
    }
}