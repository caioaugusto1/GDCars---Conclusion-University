using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Models
{
    public class ListarPerformancesViewModel
    {
        public ListarPerformancesViewModel()
        {
            Cliente = new Cliente();
            Banco = new Banco();
            Cor = new Cor_Veiculo();
            Roda = new Roda();
        }

        public Cliente Cliente { get; set; }

        public Banco Banco { get; set; }

        public Cor_Veiculo Cor { get; set; }

        public Roda Roda { get; set; }
    }
}