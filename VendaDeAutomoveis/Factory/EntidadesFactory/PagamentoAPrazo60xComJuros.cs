using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAPrazo60xComJuros : IFormaDePagamento
    {
        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal / 12 * 0.05);
            return resultado;
        } 
    }
}