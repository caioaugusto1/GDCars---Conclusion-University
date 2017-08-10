namespace VendaDeAutomoveis.Factory.EntidadesFactory
{
    public class PagamentoAPrazo12xSemJuros : IFormaDePagamento
    {
        public double CalculaValor(double ValorTotal)
        {
            double resultado = (ValorTotal / 12);
            return resultado;
        }
    }
}