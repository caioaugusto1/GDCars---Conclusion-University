using System;

namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    public class PagamentoAPrazo12xSemJuros : IFormaDePagamento
    {
        public double CalcularDesconto(double ValorTotal)
        {
            throw new NotImplementedException();
        }

        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal / 12);
            return resultado;
        }
    }
}