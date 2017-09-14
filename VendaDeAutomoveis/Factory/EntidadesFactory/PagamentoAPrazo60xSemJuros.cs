using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAPrazo60xSemJuros : IFormaDePagamento
    {
        public double CalcularDesconto(double ValorTotal)
        {
            throw new NotImplementedException();
        }

        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal / 60);
            return resultado;
        }
    }
}