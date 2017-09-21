namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Uploads
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Uploads()
        {
            GDC_Bancos = new HashSet<GDC_Bancos>();
            GDC_Rodas = new HashSet<GDC_Rodas>();
            GDC_Veiculos = new HashSet<GDC_Veiculos>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Nome_Arquivo { get; set; }

        public DateTime Data_Inclusao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Bancos> GDC_Bancos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Rodas> GDC_Rodas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Veiculos> GDC_Veiculos { get; set; }
    }
}
