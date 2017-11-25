namespace VendaDeAutomoveis.Factory
{
    public interface IFormaDePagamento
    {
        double CalculaValor(double ValorTotal);

        double CalcularDesconto(double ValorTotal);

        double CalcularValorParcela(double ValorTotal);
    }
}
