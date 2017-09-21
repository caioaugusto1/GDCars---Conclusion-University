namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Veiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Veiculos()
        {
            GDC_Vendas = new HashSet<GDC_Vendas>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Fabricante { get; set; }

        [Required]
        [StringLength(20)]
        public string Modelo { get; set; }

        public int Ano { get; set; }

        public double Valor { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        public Guid? IdUpload { get; set; }

        public virtual GDC_Uploads GDC_Uploads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Vendas> GDC_Vendas { get; set; }
    }
}
