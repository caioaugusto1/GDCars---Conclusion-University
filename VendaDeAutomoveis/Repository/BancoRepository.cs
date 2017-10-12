using Dapper;
using System;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.Repository
{
    public class BancoRepository : RepositoryBase<GDC_Bancos>
    {
        public BancoRepository(ContextGDCars context)
            : base(context)
        {

        }

        public override void Inserir(GDC_Bancos obj)
        {
            var sql = "Insert into GDC_Bancos (Id, Modelo, Multimidia, Cor, Valor) " +
             "Values(@Id, @Modelo, @Multimidia, @Cor, @Valor)";

            var e = _context.Database.Connection.Query<GDC_Bancos>(sql,
                param: new
                {
                    Id = obj.Id,
                    Modelo = obj.Modelo,
                    Multimidia = Convert.ToByte(obj.Multimidia),
                    Cor = obj.Cor,
                    Valor = obj.Valor
                });
        }
    }
}