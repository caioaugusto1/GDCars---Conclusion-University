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

        public override void Inserir(GDC_Veiculos obj)
        {
            var sql = "Insert into GDC_Veiculos (Id, Fabricante, Modelo, Ano, Valor, Tipo, IdUpload) " +
               "Values(@Id, @Fabricante, @Modelo, @Ano, @Valor, @Tipo, @IdUpload)";

            var e = _context.Database.Connection.Query<GDC_Veiculos>(sql,
                param: new
                {
                    Id = obj.Id,
                    Fabricante = obj.Fabricante,
                    Modelo = obj.Modelo,
                    Ano = obj.Ano,
                    Valor = obj.Valor,
                    Tipo = obj.Tipo,
                    IdUpload = obj.IdUpload
                });
        }

        public override void Editar(GDC_Veiculos obj)
        {
            var sql = "update GDC_Veiculos set Fabricante = @Fabricante, Modelo = @Modelo, Valor = @Valor, Tipo = @Tipo where Id = @Id ";

            var e = _context.Database.Connection.Query<GDC_Veiculos>(sql,
                param: new
                {
                    Id = obj.Id,
                    Fabricante = obj.Fabricante,
                    Modelo = obj.Modelo,
                    Valor = obj.Valor,
                    Tipo = obj.Tipo
                });
        }
    }
}