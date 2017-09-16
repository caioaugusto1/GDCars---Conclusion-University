using System;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
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
            var enderecos = _context.Enderecos.Where(e => e.Id == idCliente).FirstOrDefault();

            return enderecos;
        }
    }
}