using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Adapters;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class VeiculoRepository : RepositoryBase<GDC_Veiculos>, IRepository<Veiculo>
    {
        public VeiculoRepository(GDCarsContext context)
            : base(context)
        {
        }

        public void Adicionar(Veiculo obj)
        {
            _context.Veiculos.Add(obj.ToDbEntity());
            SaveChange();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Editar(Veiculo obj)
        {
            _context.Veiculos.Attach(obj.ToDbEntity());
            var entry = _context.Entry(obj);
            entry.State = System.Data.Entity.EntityState.Modified;
            SaveChange();
        }

        public void Excluir(Guid id)
        {
            var veiculo = ObterPorId(id);
            _context.Veiculos.Remove(veiculo.ToDbEntity());
            SaveChange();
        }

        public void Excluir(Func<Veiculo, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Veiculo> Obter(Func<Veiculo, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Veiculo ObterPorId(Guid id)
        {
            var veiculo = _context.Veiculos.Where(b => b.Id == id.ToString()).FirstOrDefault();
            return veiculo.ToDomain();
        }

        public IList<Veiculo> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Veiculos ";

            return _context.Database.Connection.Query<Veiculo>(sql)
                .OrderBy(c => c.Data_Cadastro)
                .ThenBy(c => c.ModeloVeiculo)
                .ToList();
        }
    }
}