using System;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    public class PagamentoAPrazo12xSemJuros : IFormaDePagamento
    {
        double resultado;

        public double CalcularDesconto(double ValorTotal)
        {
            resultado = (ValorTotal / 12 - 0.02);
            return resultado;
        }

        public double CalcularValorParcela(double ValorTotal)
        {
            resultado = (ValorTotal / 12);
            return resultado;
        }

        public double CalculaValor(double ValorTotal)
        {
            resultado = (ValorTotal / 12);
            return resultado;
        }
    }
}