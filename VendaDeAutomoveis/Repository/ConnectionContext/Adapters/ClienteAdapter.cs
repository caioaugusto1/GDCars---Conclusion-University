using System;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using static VendaDeAutomoveis.Entidades.Cliente;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Adapters
{
    public static class ClienteAdapter
    {
        public static Cliente ToDomain(this GDC_Clientes dbClientes)
        {
            if (dbClientes == null)
                return null;

            return new Cliente
            {
                IdCliente = Guid.Parse(dbClientes.Id.ToString()),
                Nome = dbClientes.Nome,
                CPF = dbClientes.CPF.ToString(),
                RG = dbClientes.RG,
                Email = dbClientes.Email,
                TipoDoCliente = TipoCliente.Comum,
                IdEndereco = Guid.Parse(dbClientes.IdEndereco.ToString())
            };
        }

        public static GDC_Clientes ToDbEntity(this Cliente domain)
        {
            if (domain == null)
                return null;

            if (domain.IdEndereco.ToString() != "{00000000-0000-0000-0000-000000000000}")
                domain.IdEndereco = null;

            return new GDC_Clientes
            {
                Id = domain.IdCliente,
                Nome = domain.Nome,
                CPF = domain.CPF,
                RG = domain.RG,
                Email = domain.Email,
                Tipo = Convert.ToString(TipoCliente.Comum),
                IdEndereco = domain.IdEndereco,
            };
        }
    }
}