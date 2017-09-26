using System;
using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Performance  : Entity
    {
        public double ValorTotal { get; set; }

        [Required]
        public Guid IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        [Required]
        public Guid IdRoda { get; set; }

        public virtual Roda Roda { get; set; }

        [Required]
        public Guid IdBanco { get; set; }

        public virtual Banco Banco { get; set; }

        [Required]
        public Guid IdCor { get; set; }

        public virtual Cor_Veiculo Cor { get; set; }
    }
}