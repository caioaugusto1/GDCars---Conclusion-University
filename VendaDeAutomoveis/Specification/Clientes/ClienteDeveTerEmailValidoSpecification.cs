using System;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Validation.Clientes;

namespace VendaDeAutomoveis.Specification.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return EmailValidation.Validar(entity.Email);
        }
    }
}