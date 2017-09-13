using System;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface ILoginRepository
    {
        void BloquearAcesso(Guid id);

        Login BuscarPorEmail(string email);

        Login AutenticarAcesso(string email, string senha);
    }
}
