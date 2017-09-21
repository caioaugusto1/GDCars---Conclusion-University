namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<GDC_Clientes>
    {
        GDC_Clientes VerificarCPFExistente(string cpf);
    }
}