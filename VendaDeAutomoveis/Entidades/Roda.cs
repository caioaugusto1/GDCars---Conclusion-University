using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Roda : Entity
    {
        public string Modelo { get; set; }

        public CorRoda Cor { get; set; }

        public int Aro { get; set; }
        
        public double Valor { get; set; }
    }

    public enum CorRoda
    {
        [Display(Name = "Cinza")]
        Cinza,
        [Display(Name = "Cromada")]
        Cromada,
        [Display(Name = "Fosco")]
        Fosco,
        [Display(Name = "Preta")]
        Preta,
    }
}