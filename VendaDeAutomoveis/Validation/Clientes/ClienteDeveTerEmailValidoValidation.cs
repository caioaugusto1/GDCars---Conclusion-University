using System;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Specification;

namespace VendaDeAutomoveis.Validation.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return EmailValidation.Validar(entity.Email);
        }
    }
}