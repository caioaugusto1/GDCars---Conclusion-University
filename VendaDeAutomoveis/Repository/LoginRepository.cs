﻿using Dapper;
using System;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Adapters;
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
        
        public void Adicionar(Login login)
        {
            login.TipoAcesso = NivelAcesso.Usuario;

            _context.Logins.Add(login.ToDbEntity());
            SaveChange();
        }

        public void BloquearAcesso(Guid id)
        {
            var usuario = _context.Logins.Where(u => u.Id == id).FirstOrDefault();
            usuario.Tipo_Acesso = NivelAcesso.Bloqueado.ToString();
            SaveChange();
        }

        public Login BuscarPorEmail(string email)
        {
            var sql = "SELECT * FROM GDC_Logins where Email = @email ";

            return _context.Database.Connection.Query<Login>(sql,
                param: new
                {
                    email = email
                }).FirstOrDefault();
        }

        public Login AutenticarAcesso(string email, string senha)
        {
            var sql = "SELECT * FROM GDC_Logins where Email = @email and Senha = @senha ";

            return _context.Database.Connection.Query<Login>(sql,
                param: new
                {
                    email = email,
                    senha = senha
                }).FirstOrDefault();
        }
    }
}