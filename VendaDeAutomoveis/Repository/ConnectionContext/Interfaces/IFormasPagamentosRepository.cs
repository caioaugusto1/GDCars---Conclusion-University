using System.Collections.Generic;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IFormasPagamentosRepository
    {
        IList<FormaDePagamento> ObterFormaPagamentoComum();

        IList<FormaDePagamento> ObterListarFormaPagamentoVip();
    }
}
