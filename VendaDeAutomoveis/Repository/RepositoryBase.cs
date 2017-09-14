using System;
using System.Collections.Generic;
using System.Data.Entity;
using VendaDeAutomoveis.DAO.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly ContextGDCars _context;

        protected readonly DbSet<TEntity> _DbSet;

        string connectionString = GDCarsConnectionString.Connection;

        public RepositoryBase(ContextGDCars context)
        {
            _context = context;
            _DbSet = _context.Set<TEntity>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual void Editar(TEntity obj)
        {
            _DbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        
        public void Inserir(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _DbSet.Add(obj);
            SaveChange();
        }

        public void InsertRange(TEntity[] entities)
        {
            _DbSet.AddRange(entities);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return _DbSet.Find(id);
        }

        public virtual IList<TEntity> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}