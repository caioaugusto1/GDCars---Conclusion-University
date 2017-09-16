using Dapper;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class LoginRepository : RepositoryBase<GDC_Logins>, ILoginRepository
    {
        public LoginRepository(ContextGDCars context)
            : base(context)
        {
        }

        public GDC_Logins BuscarPorEmail(string email)
        {
            var sql = "SELECT * FROM GDC_Logins where Email = @email ";

            return _context.Database.Connection.Query<GDC_Logins>(sql,
                param: new
                {
                    email = email
                }).FirstOrDefault();
        }

        public GDC_Logins AutenticarAcesso(string email, string senha)
        {
            var sql = "SELECT * FROM GDC_Logins where Email = @email and Senha = @senha ";

            return _context.Database.Connection.Query<GDC_Logins>(sql,
                param: new
                {
                    email = email,
                    senha = senha
                }).FirstOrDefault();

            //return _context.Logins.Where(a => a.Email == email && a.Senha == senha).FirstOrDefault();
        }
    }
}