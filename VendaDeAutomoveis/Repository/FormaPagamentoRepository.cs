using Dapper;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class FormaPagamentoRepository : RepositoryBase<FormaDePagamento>, IFormasPagamentosRepository
    {
        public FormaPagamentoRepository(ContextGDCars context)
            : base(context)
        {

        }

        public override IList<FormaDePagamento> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Formas_Pagamentos ";

            return _context.Database.Connection.Query<FormaDePagamento>(sql)
                .OrderBy(c => c.TipoDoCliente)
                .ToList();
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
    }
}
