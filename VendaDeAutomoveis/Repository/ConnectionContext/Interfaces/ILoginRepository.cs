using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        void BloquearAcesso(Guid id);

        bool VerificarEmailExistente(string email);

        Login AutenticarAcesso(string email, string senha);
    }
}
