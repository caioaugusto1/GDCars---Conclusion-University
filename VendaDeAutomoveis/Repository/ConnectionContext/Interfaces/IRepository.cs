using System;
using System.Collections.Generic;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IList<TEntity> ObterTodos();
        
        TEntity ObterPorId(Guid id);
        
        void Editar(TEntity obj);

        void Inserir(TEntity obj);

        void InsertRange(TEntity[] entities);

        void SaveChange();
    }
}