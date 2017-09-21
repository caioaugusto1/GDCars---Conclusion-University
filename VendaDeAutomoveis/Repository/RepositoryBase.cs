using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VendaDeAutomoveis.DAO.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class RepositoryBase<DBSet> : IDisposable, IRepositoryBase<DBSet>
        where DBSet : class
    {
        protected readonly ContextGDCars _context;
        
        protected GDCarsContextDiagrama _DbSet = new GDCarsContextDiagrama();

        string connectionString = GDCarsConnectionString.Connection;

        public RepositoryBase(ContextGDCars context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual void Editar(DBSet obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
        
        public virtual void Inserir(DBSet obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _DbSet.Set<DBSet>().Add(obj);
            SaveChange();
        }

        public void InsertRange(DBSet[] entities)
        {
            _DbSet.Set<DBSet>();
        }

        public virtual DBSet ObterPorId(Guid id)
        {
            return _DbSet.Set<DBSet>().Find(id);
        }

        public virtual IList<DBSet> ObterTodos()
        {
            return _DbSet.Set<DBSet>().ToList();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}