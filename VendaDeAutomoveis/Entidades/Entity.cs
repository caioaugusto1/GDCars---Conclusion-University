using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeAutomoveis.Entidades
{
    public abstract class Entity /*: EntityUpload*/
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

    }
}