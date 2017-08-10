using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.DAO
{
    public class VeiculoDAO
    {
        private VendasContext context;

        public VeiculoDAO(VendasContext context)
        {
            this.context = context;
        }
        public void Adiciona(Produtos veiculo)
        {
            context.Veiculos.Add(veiculo);
            context.SaveChanges();
        }
        public IList<Produtos> Lista()
        {
            return context.Veiculos.ToList();
        }
    }
}