namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Formas_Pagamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Formas_Pagamentos()
        {
            GDC_Vendas = new HashSet<GDC_Vendas>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(10)]
        public string Tipo_Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Vendas> GDC_Vendas { get; set; }
    }
}
