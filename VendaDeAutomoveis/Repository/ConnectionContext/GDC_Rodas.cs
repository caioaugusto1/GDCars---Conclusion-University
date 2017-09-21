namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Rodas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Rodas()
        {
            GDC_Perfomances = new HashSet<GDC_Perfomances>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(10)]
        public string Cor { get; set; }

        public int Aro { get; set; }

        public double Valor { get; set; }

        public Guid? IdUpload { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Perfomances> GDC_Perfomances { get; set; }

        public virtual GDC_Uploads GDC_Uploads { get; set; }
    }
}
