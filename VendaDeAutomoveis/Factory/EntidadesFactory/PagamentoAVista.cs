using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAVista : IFormaDePagamento
    {
        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal);
            return resultado;
        }
    }
}