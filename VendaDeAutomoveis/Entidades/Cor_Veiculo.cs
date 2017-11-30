using System;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Cor_Veiculo : Entity
    {
        public EstiloCorVeiculo Estilo { get; set; }

        public decimal Valor { get; set; }
    }
}