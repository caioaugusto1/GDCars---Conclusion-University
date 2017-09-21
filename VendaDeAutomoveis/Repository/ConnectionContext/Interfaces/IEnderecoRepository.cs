using System;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IEnderecoRepository : IRepositoryBase<GDC_Enderecos>
    {
        GDC_Enderecos BuscarPorIdCliente(Guid idCliente);
    }
}
