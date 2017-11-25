namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    internal class PagamentoAPrazo12xComJuros : IFormaDePagamento
    {
        double resultado;

        public double CalcularDesconto(double ValorTotal)
        {
            resultado = (ValorTotal / 12 - 0.03);
            return resultado;
        }

        public double CalcularValorParcela(double ValorTotal)
        {
            resultado = (ValorTotal / 12);
            return resultado;
        }

        public double CalculaValor(double ValorTotal)
        {
            resultado = (ValorTotal * 0.03);
            return resultado;
        }


    }
}