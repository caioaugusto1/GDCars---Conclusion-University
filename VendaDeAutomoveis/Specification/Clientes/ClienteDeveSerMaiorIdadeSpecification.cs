using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Validation.Clientes;

namespace VendaDeAutomoveis.Specification.Clientes
{
    public class ClienteDeveSerMaiorIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return MaiorIdadeValidation.Validar(cliente.DataNascimento);
        }
    }
}