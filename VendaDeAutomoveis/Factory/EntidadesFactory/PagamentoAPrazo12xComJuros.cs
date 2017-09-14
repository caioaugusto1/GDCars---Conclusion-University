using System;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAPrazo12xComJuros : IFormaDePagamento
    {
        public double CalcularDesconto(double ValorTotal)
        {
            double resultado = (ValorTotal / 12 - 0.03);
            return resultado;
        }

        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal / 12 *  0.03);
            return resultado;
        }
    }
}