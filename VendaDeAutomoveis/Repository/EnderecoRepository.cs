using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext.Adapters;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Entidades;
using System;

namespace VendaDeAutomoveis.Repository
{
    public class EnderecoRepository : RepositoryBase<GDC_Enderecos>
    {
        public EnderecoRepository(ContextGDCars context)
            : base(context)
        {
        }

        public void Adicionar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco.ToDbEntity());
            SaveChange();
        }

        public Endereco PegarEnderencoPorIdCliente(Guid IdCliente)
        {
            var endereco = _context.Enderecos.Where(e => e.Id == IdCliente).FirstOrDefault();
            return endereco.ToDomain();
        }

        public void EditarEndereco(Endereco endereco)
        {
            _context.Enderecos.Attach(endereco.ToDbEntity());
            var entry = _context.Entry(endereco);
            entry.State = System.Data.Entity.EntityState.Modified;
            SaveChange();
        }
    }
}