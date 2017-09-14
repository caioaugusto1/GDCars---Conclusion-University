using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>
    {
        public ClienteRepository(ContextGDCars context)
            : base(context)
        {
        }   

        public Cliente VerificarCPFExistente(string cpf)
        {
            var sql = "SELECT * FROM GDC_Clientes where CPF = @cpf ";

            var e = _context.Database.Connection.Query(sql,
                param: new
                {
                    cpf = cpf
                });

            return e.FirstOrDefault();
        }

        public override IList<Cliente> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Clientes ";

            return _context.Database.Connection.Query<Cliente>(sql)
                .OrderBy(c => c.Nome)
                .ThenBy(c => c.Tipo)
                .ToList();
        }

        public void Atualizar(Guid idEndereco, Guid idCliente)
        {
            var sql = "update GDC_Clientes set IdEndereco = @idEndereco where Id = @idCliente ";

            var e = _context.Database.Connection.Execute(sql,
                param: new
                {
                    idEndereco = idEndereco,
                    idCliente = idCliente
                });

            SaveChange();
        }

        public void Adicionar(Cliente obj)
        {
            var sql = "Insert into GDC_Clientes (Id, Nome, CPF, RG, Tipo, Email, DataNascimento) " +
                "Values(@IdCliente, @Nome, @CPF, @RG, @Tipo, @Email, @DataNascimento)";

            var e = _context.Database.Connection.Query<Cliente>(sql,
                param: new
                {
                    IdCliente = obj.Id,
                    Nome = obj.Nome,
                    CPF = obj.CPF,
                    RG = obj.RG,
                    Tipo = obj.Tipo,
                    Email = obj.Email,
                    DataNascimento = obj.Data_Nascimento
                });
        }

        public override void Editar(Cliente obj)
        {
            var sql = "update GDC_Clientes set Nome = @Nome, RG = @RG, CPF = @CPF, DataNascimento = @DataNascimento where Id = @IdCliente ";

            var e = _context.Database.Connection.Execute(sql,
                param: new
                {
                    Id = obj.Id,
                    Nome = obj.Nome,
                    RG = obj.RG,
                    CPF = obj.CPF,
                    DataNascimento = obj.Data_Nascimento
                });

            SaveChange();
        }

        public override Cliente ObterPorId(Guid id)
        {
            var sql = "SELECT * FROM GDC_Clientes where Id = @id ";

            return _context.Database.Connection.Query<Cliente>(sql,
                    param: new
                    {
                        Id = id
                    }).FirstOrDefault();

        }
    }
}