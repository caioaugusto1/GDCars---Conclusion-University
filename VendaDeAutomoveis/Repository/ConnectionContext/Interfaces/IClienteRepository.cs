using System;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<GDC_Clientes>
    {
        GDC_Clientes ObterPorCPF(string cpf);

        GDC_Clientes ObterPorIdEndereco(Guid id);
    }
}