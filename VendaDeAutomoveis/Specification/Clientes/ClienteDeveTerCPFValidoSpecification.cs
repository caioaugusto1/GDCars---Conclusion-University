using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Validation.Clientes;

namespace VendaDeAutomoveis.Specification.Clientes
{
    public class ClienteDeveTerCPFValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPFValidation.Validar(cliente.CPF);
        }
    }
}