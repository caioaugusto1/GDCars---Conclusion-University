namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Bancos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Bancos()
        {
            GDC_Perfomances = new HashSet<GDC_Perfomances>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(1)]
        public string Modelo { get; set; }

        public bool Multimidia { get; set; }

        [Required]
        [StringLength(10)]
        public string Cor { get; set; }

        public decimal Valor { get; set; }

        public Guid? IdUpload { get; set; }

        public virtual GDC_Uploads GDC_Uploads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Perfomances> GDC_Perfomances { get; set; }
    }
}
