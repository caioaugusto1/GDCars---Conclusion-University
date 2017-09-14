using AutoMapper;
using System;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

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
            var domain = Mapper.Map<Endereco, GDC_Enderecos>(endereco); 

            _context.Enderecos.Add(domain);
            SaveChange();
        }

        public Endereco PegarEnderencoPorIdCliente(Guid IdCliente)
        {
            var enderecoViewMoel = Mapper.Map<GDC_Enderecos, Endereco>(_context.Enderecos.Where(e => e.Id == IdCliente).FirstOrDefault());

            return enderecoViewMoel;
        }

        public void EditarEndereco(Endereco endereco)
        {
            var domain = Mapper.Map<Endereco, GDC_Enderecos>(endereco);

            _context.Enderecos.Attach(domain);
            var entry = _context.Entry(endereco);
            entry.State = System.Data.Entity.EntityState.Modified;
            SaveChange();
        }
    }
}