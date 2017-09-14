using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Cor_Veiculo : Entity
    {
        public EstiloCorVeiculo Estilo { get; set; }

        public double Valor { get; set; }
    }
}