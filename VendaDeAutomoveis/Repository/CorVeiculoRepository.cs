using Dapper;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class CorVeiculoRepository : RepositoryBase<GDC_Cor_Veiculos>, ICorVeiculoRepository
    {
        public CorVeiculoRepository(ContextGDCars context)
            : base(context)
        {

        }

        public override void Inserir(GDC_Cor_Veiculos obj)
        {
            var sql = "Insert into GDC_Cor_Veiculos (Id, Estilo, Valor) " +
              "Values(@Id, @Estilo, @Valor )";

            var e = _context.Database.Connection.Query<GDC_Cor_Veiculos>(sql,
                param: new
                {
                    Id = obj.Id,
                    Estilo = obj.Estilo,
                    Valor = obj.Valor
                });
        }
    }
}