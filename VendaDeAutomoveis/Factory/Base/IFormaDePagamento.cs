using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaDeAutomoveis.Factory
{
    public interface IFormaDePagamento
    {
        double CalculaValor(double ValorTotal);
    }
}
