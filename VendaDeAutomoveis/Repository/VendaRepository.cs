using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class VendaRepository : RepositoryBase<Venda>, IVendasRepository
    {
        public VendaRepository(ContextGDCars context)
            : base(context)
        {
        }

        public void Adicionar(Venda obj)
        {
            var domain = Mapper.Map<Venda, GDC_Vendas>(obj);
            
            _context.Vendas.Add(domain);
        }

        public IList<Venda> BuscarPorCliente(Guid? idCliente)
        {
            var sql = "SELECT * FROM GDC_Vendas where IdCliente = @idCliente ";

            var e = _context.Database.Connection.Query(sql,
                param: new
                {
                    idCliente = idCliente
                });

            return e.FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Editar(Venda obj)
        {
            var domain = Mapper.Map<Venda, GDC_Vendas>(obj);

            _context.Vendas.Attach(domain);
            var entry = _context.Entry(obj);
            entry.State = System.Data.Entity.EntityState.Modified;
            SaveChange();
        }
        
        public double GastosPorCliente(Guid id)
        {
            return _context.Vendas.Where(c => c.Id == id).Sum(c => c.Valor);
        }

        public override Venda ObterPorId(Guid id)
        {
            var sql = "SELECT * FROM GDC_Vendas where Id = @id ";
            
            var e = _context.Database.Connection.Query(sql,
                param: new
                {
                    id = id
                });

            return e.FirstOrDefault();
        }

        public override IList<Venda> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Vendas ";

            return _context.Database.Connection.Query<Venda>(sql)
                .OrderBy(c => c.Cliente)
                .ToList();
        }
    }
}