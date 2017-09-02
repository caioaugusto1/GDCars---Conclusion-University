using System;
using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public abstract class Entity /*: EntityUpload*/
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime Data_Cadastro { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}