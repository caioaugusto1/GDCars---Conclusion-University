using System;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Adapters
{
    public static class LoginAdapter
    {
        public static Login ToDomain(this GDC_Logins dbLogin)
        {
            if (dbLogin == null) return null;

            return new Login
            {
                Id = Guid.Parse(dbLogin.Id),
                Nome = dbLogin.Nome,
                SobreNome = dbLogin.SobreNome,
                Email = dbLogin.Email,
                TipoAcesso = NivelAcesso.Admin,
            };
        }

        public static GDC_Logins ToDbEntity(this Login domain)
        {
            if (domain == null)
                return null;

            return new GDC_Logins
            {
                Id = Convert.ToString(domain.Id),
                Nome = domain.Nome,
                SobreNome = domain.SobreNome,
                Senha = domain.Senha,
                Data_Inclusao = DateTime.Now,
                Email = domain.Email,
                Tipo_Acesso = Convert.ToString(domain.TipoAcesso),
            };
        }
    }
}