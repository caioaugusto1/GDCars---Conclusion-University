using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Performance  : Entity
    {
        [Required]
        public int IdRoda { get; set; }

        public virtual Roda Roda { get; set; }
        [Required]
        public int IdBanco { get; set; }

        public virtual Banco Banco { get; set; }
        [Required]
        public int IdCor { get; set; }

        public virtual Cor Cor { get; set; }
    }
}