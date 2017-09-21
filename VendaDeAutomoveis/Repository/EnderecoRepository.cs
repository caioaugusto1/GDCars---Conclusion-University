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
            var enderecos = _context.Enderecos.Where(e => e.IdCliente == idCliente).FirstOrDefault();

            var m = Mapper.Map<GDC_Enderecos>(enderecos);

            return m;
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
    }
}