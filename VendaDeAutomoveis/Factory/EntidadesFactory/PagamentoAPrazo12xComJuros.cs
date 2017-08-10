using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAPrazo12xComJuros : IFormaDePagamento
    {
        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal / 12 *  0.03);
            return resultado;
        }
    }
}