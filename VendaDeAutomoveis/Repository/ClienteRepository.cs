using Dapper;
using System;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class ClienteRepository : RepositoryBase<GDC_Clientes>, IClienteRepository
    {
        public ClienteRepository(ContextGDCars context)
            : base(context)
        {
        }

        public GDC_Clientes ObterPorCPF(string cpf)
        {
            var sql = "SELECT * FROM GDC_Clientes where CPF = @cpf ";

            var e = _context.Database.Connection.Query(sql,
                param: new
                {
                    cpf = cpf
                });

            return e.FirstOrDefault();
        }

        public void Atualizar(Guid idEndereco, Guid idCliente)
        {
            var sql = "update GDC_Clientes set IdEndereco = @idEndereco where Id = @Id ";

            var e = _context.Database.Connection.Execute(sql,
                param: new
                {
                    idEndereco = idEndereco,
                    Id = idCliente
                });
        }

        public override void Inserir(GDC_Clientes obj)
        {
            var sql = "Insert into GDC_Clientes (Id, Nome, CPF, RG, Tipo, Email, Data_Nascimento) " +
                "Values(@Id, @Nome, @CPF, @RG, @Tipo, @Email, @Data_Nascimento)";

            var e = _context.Database.Connection.Query<GDC_Clientes>(sql,
                param: new
                {
                    Id = obj.Id,
                    Nome = obj.Nome,
                    CPF = obj.CPF,
                    RG = obj.RG,
                    Tipo = obj.Tipo,
                    Email = obj.Email,
                    Data_Nascimento = obj.Data_Nascimento
                });
        }

        public override void Editar(GDC_Clientes obj)
        {
            var sql = "update GDC_Clientes set Nome = @Nome, RG = @RG, CPF = @CPF, Data_Nascimento = @Data_Nascimento, Email = @Email where Id = @Id ";

            var e = _context.Database.Connection.Query<GDC_Clientes>(sql,
                param: new
                {
                    Id = obj.Id,
                    Nome = obj.Nome,
                    RG = obj.RG,
                    CPF = obj.CPF,
                    Data_Nascimento = obj.Data_Nascimento,
                    Email = obj.Email
                });
        }

        public override GDC_Clientes ObterPorId(Guid id)
        {
            var cliente = base.ObterPorId(id);

            EnderecoRepository end = new EnderecoRepository(this._context);

            if (cliente.IdEndereco.HasValue)
            {
                cliente.GDC_Enderecos = end.ObterPorId(cliente.IdEndereco.Value);
            }

            return cliente;
        }

        public GDC_Clientes ObterPorIdEndereco(Guid id)
        {
            var sql = "SELECT * FROM GDC_Clientes where idEndereco = @id ";

            var e = _context.Database.Connection.Query<GDC_Clientes>(sql,
                param: new
                {
                    id = id
                });

            return e.FirstOrDefault();
        }
    }
}