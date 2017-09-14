using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Cor_Veiculo : Entity
    {
        public Estilo Estilo { get; set; }

        public double Valor { get; set; }
    }

    public enum Estilo
    {
        [Display(Name = "Brilhante")]
        Brilhante,
        [Display(Name = "Fosco")]
        Fosco,
        [Display(Name = "Normal")]
        Normal
    }
}