using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Models
{
    public class DetailsDeleteVendaViewModel
    {
        public Cliente Cliente { get; set; }

        public Endereco Endereco { get; set; }

        public Veiculo Veiculo { get; set; }

        public FormaDePagamento FormaDePagamento { get; set; }

        public Performance Performance { get; set; }

        public Roda Roda { get; set; }

        public Banco Banco { get; set; }

        public Cor_Veiculo Cor_Veiculo { get; set; }

    }
}