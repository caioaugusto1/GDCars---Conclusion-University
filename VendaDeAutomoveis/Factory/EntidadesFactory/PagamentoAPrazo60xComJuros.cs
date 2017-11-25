using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAPrazo60xComJuros : IFormaDePagamento
    {
        double resultado;

        public double CalcularDesconto(double ValorTotal)
        {
            throw new NotImplementedException();
        }

        public double CalcularValorParcela(double ValorTotal)
        {
            resultado = (ValorTotal / 60);
            return resultado;
        }

        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal * 0.05);
            return resultado;
        } 
    }
}