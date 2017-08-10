using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Adapters
{
    public static class EnderecoAdapter
    {
        public static Endereco ToDomain(this GDC_Enderecos dbEnderecos)
        {
            if (dbEnderecos == null) return null;

            var guid = Guid.NewGuid();

            return new Endereco
            {
                Id = Guid.Parse(dbEnderecos.Id),
                EnderecoNome = dbEnderecos.Endereco,
                Numero = dbEnderecos.Numero,
                Complemento = dbEnderecos.Complemento,
                CEP = dbEnderecos.CEP.ToString(),
                Bairro = dbEnderecos.Bairro,
                Estado = dbEnderecos.Estado,
                Cidade = dbEnderecos.Cidade,
            };
        }

        public static GDC_Enderecos ToDbEntity(this Endereco domain)
        {
            if (domain == null)
                return null;

            return new GDC_Enderecos
            {
                Id = domain.Id.ToString(),
                Endereco = domain.EnderecoNome,
                Numero = domain.Numero,
                Complemento = domain.Complemento,
                Bairro = domain.Bairro,
                Estado = domain.Estado,
                Cidade = domain.Cidade,
            };
        }

        public static IEnumerable<GDC_Enderecos> ToDbEntityList(IEnumerable<Endereco> domain)
        {
            if (domain == null)
                return null;

            return domain.Select(d => ToDbEntity(d)).Where(d => d != null).ToList();
        }
    }
}