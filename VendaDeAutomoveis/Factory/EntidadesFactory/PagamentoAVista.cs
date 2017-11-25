using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAVista : IFormaDePagamento
    {
        public double CalcularDesconto(double ValorTotal)
        {
            double resultado = (ValorTotal - 0.06);
            return resultado;
        }

        public double CalcularValorParcela(double ValorTotal)
        {
            throw new NotImplementedException();
        }

        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal);
            return resultado;
        }
    }
}