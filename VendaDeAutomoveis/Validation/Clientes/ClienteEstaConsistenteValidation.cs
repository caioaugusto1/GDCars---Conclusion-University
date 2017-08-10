using DomainValidation.Validation;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Specification.Clientes;

namespace VendaDeAutomoveis.Validation
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            //var CPFCliente = new ClienteDeveTerCPFValidoSpecification();
            //Add("CPFCliente", new Rule<Cliente>(ISpecification<Cliente> CPFCliente, "Cliente informou CPF inválido"));

            //var emailCliente = new ClienteDeveTerEmailValidoSpecification();
            //Add("EmailCliente", new Rule<Cliente>(emailCliente, "Cliente informou E-mail inválido"));

            //var maiorIdade = new ClienteDeveSerMaiorIdadeSpecification();
            //Add("maiorIdade", new Rule<Cliente>(maiorIdade, "Cliente deve ser maior que 21 anos"));
        }
    }
}