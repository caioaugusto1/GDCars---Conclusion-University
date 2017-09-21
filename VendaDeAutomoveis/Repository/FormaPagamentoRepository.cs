using Dapper;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Repository.ConnectionContext;
using VendaDeAutomoveis.Repository.ConnectionContext.Interfaces;

namespace VendaDeAutomoveis.Repository
{
    public class FormaPagamentoRepository : RepositoryBase<GDC_Formas_Pagamentos>, IFormasPagamentosRepository
    {
        public FormaPagamentoRepository(ContextGDCars context)
            : base(context)
        {

        }

        public override IList<GDC_Formas_Pagamentos> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Formas_Pagamentos ";

            return _context.Database.Connection.Query<GDC_Formas_Pagamentos>(sql)
                .OrderBy(c => c.Tipo_Cliente)
                .ToList();
        }

        public IList<GDC_Formas_Pagamentos> ObterFormaPagamentoComum()
        {
            var sql = "SELECT * FROM GDC_Formas_Pagamentos where Tipo_Cliente = 'Comum' ";

            return _context.Database.Connection.Query<GDC_Formas_Pagamentos>(sql)
                .OrderBy(c => c.Tipo_Cliente)
                .ToList();
        }

        public IList<GDC_Formas_Pagamentos> ObterListarFormaPagamentoVip()
        {
            var sql = "SELECT * FROM GDC_Formas_Pagamentos where TipoCliente = 'Vip' ";

            return _context.Database.Connection.Query<GDC_Formas_Pagamentos>(sql)
                .OrderBy(c => c.Tipo_Cliente)
                .ToList();
        }
    }
}
