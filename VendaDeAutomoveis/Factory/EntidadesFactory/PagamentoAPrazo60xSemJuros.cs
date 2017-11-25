using System;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAPrazo60xSemJuros : IFormaDePagamento
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
            double resultado = (ValorTotal / 60);
            return resultado;
        }
    }
}