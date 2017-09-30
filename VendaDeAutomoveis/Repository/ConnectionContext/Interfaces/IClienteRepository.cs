namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<GDC_Clientes>
    {
        GDC_Clientes ObterPorCPF(string cpf);
    }
}