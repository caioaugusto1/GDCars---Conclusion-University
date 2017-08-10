using System;
using System.Collections.Generic;
using System.Linq;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IList<TEntity> ObterTodos();
        //IQueryable<TEntity> Obter(Func<TEntity, bool> predicate);
        TEntity ObterPorId(Guid id);
        void Adicionar(TEntity obj);
        //void Excluir(Func<TEntity, bool> predicate);
        void Editar(TEntity obj);
    }
}