using AutoMapper;
using Dapper;
using System;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class EnderecoRepository : RepositoryBase<GDC_Enderecos>, IEnderecoRepository
    {
        public EnderecoRepository(ContextGDCars context)
            : base(context)
        {
        }

        public GDC_Enderecos BuscarPorIdCliente(Guid idCliente)
        {
            var sql = "SELECT * FROM GDC_Enderecos where IdCliente = @idCliente ";

            return _context.Database.Connection.Query<GDC_Enderecos>(sql,
                param: new
                {
                    idCliente = idCliente
                }).FirstOrDefault();
        }

        public override void Inserir(GDC_Enderecos obj)
        {
            var sql = "Insert into GDC_Enderecos (Id, Endereco, Numero, Complemento, Cep, Bairro, Estado, Cidade) " +
                "Values(@Id, @Endereco, @Numero, @Complemento, @Cep, @Bairro, @Estado, @Cidade)";

            var e = _context.Database.Connection.Query<GDC_Enderecos>(sql,
                param: new
                {
                    Id = obj.Id,
                    Endereco = obj.Endereco,
                    Numero = obj.Numero,
                    Complemento = obj.Complemento,
                    CEP = obj.CEP,
                    Bairro = obj.Bairro,
                    Estado = obj.Estado,
                    Cidade = obj.Cidade
                });
        }

        public override void Editar(GDC_Enderecos obj)
        {
            var sql = "update GDC_Enderecos set Endereco = @Endereco, Numero = @Numero, Complemento = @Complemento, " +
                "CEP = @CEP, Bairro = @Bairro, Estado = @Estado, Cidade = @Cidade where Id = @Id ";

            var e = _context.Database.Connection.Query<GDC_Enderecos>(sql,
                param: new
                {
                    Id = obj.Id,
                    Endereco = obj.Endereco,
                    Numero = obj.Numero,
                    Complemento = obj.Complemento,
                    CEP = obj.CEP,
                    Bairro = obj.Bairro,
                    Estado = obj.Estado,
                    Cidade = obj.Cidade,
                });
        }
    }
}