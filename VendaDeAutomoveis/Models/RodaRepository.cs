using Dapper;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Models
{
    public class RodaRepository : RepositoryBase<GDC_Rodas>, IRodaRepository
    {
        public RodaRepository(ContextGDCars context)
            : base(context)
        {
            
        }

        public override void Inserir(GDC_Rodas obj)
        {
            var sql = "Insert into GDC_Rodas (Id, Modelo, Cor, Aro, Valor, IdUpload) " +
               "Values(@Id, @Modelo, @Cor, @Aro, @Valor, @IdUpload )";

            var e = _context.Database.Connection.Query<GDC_Rodas>(sql,
                param: new
                {
                    Id = obj.Id,
                    Modelo = obj.Modelo,
                    Cor = obj.Cor,
                    Aro = obj.Aro, 
                    Valor = obj.Valor, 
                    IdUpload = obj.IdUpload 
                });
        }
    }
}