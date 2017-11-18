using System;
using System.Collections.Generic;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IRepositoryBase<DBSet> : IDisposable where DBSet : class
    {
        IList<DBSet> ObterTodos();

        DBSet ObterPorId(Guid id);
        
        void Editar(DBSet obj);

        void Inserir(DBSet obj);

        void InsertRange(DBSet[] entities);

        void SaveChange();

        void Delete(Guid id);
    }
}