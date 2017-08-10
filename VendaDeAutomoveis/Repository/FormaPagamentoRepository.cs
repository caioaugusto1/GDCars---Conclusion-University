using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext.Adapters;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository
{
    public class FormaPagamentoRepository : RepositoryBase<GDC_Formas_Pagamentos>, IFormasPagamentosRepository
    {
        public FormaPagamentoRepository(GDCarsContext context)
            : base(context)
        {

        }
    
        public IList<FormaDePagamento> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Formas_Pagamentos ";

            return _context.Database.Connection.Query<FormaDePagamento>(sql)
                .OrderBy(c => c.TipoDoCliente)
                .ToList();
        }

        public IQueryable<FormaDePagamento> Obter(Func<FormaDePagamento, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public FormaDePagamento ObterPorId(string key)
        {
            var pagamento = _context.FormasPagamentos.Where(p => p.Id == key).FirstOrDefault();
            return pagamento.ToDomain();
        }

        public void Atualizar(FormaDePagamento obj)
        {
            _context.FormasPagamentos.Add(obj.ToDbEntity());
            SaveChange();
        }

        public void Adicionar(FormaDePagamento obj)
        {
            obj.IdFormaDePagamento = Guid.NewGuid();

            _context.FormasPagamentos.Add(obj.ToDbEntity());
            SaveChange();
        }

        public void Excluir(Func<FormaDePagamento, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Editar(FormaDePagamento obj)
        {
            throw new NotImplementedException();
        }

        public IList<FormaDePagamento> ObterFormaPagamentoComum()
        {
            var sql = "SELECT * FROM GDC_Formas_Pagamentos where Tipo_Cliente = 'C' and Tipo_Cliente = 'A' ";

            return _context.Database.Connection.Query<FormaDePagamento>(sql)
                .OrderBy(c => c.TipoDoCliente)
                .ToList();
        }

        public IList<FormaDePagamento> ObterListarFormaPagamentoVip()
        {
            var sql = "SELECT * FROM GDC_Formas_Pagamentos where TipoCliente = 'V' and 'A' ";

            return _context.Database.Connection.Query<FormaDePagamento>(sql)
                .OrderBy(c => c.TipoDoCliente)
                .ToList();
        }

        public FormaDePagamento ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
