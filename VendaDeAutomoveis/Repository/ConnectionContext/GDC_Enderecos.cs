namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Enderecos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Enderecos()
        {
            GDC_Clientes = new HashSet<GDC_Clientes>();
        }

        public Guid Id { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [StringLength(5)]
        public string Numero { get; set; }

        [Required]
        [StringLength(25)]
        public string Complemento { get; set; }

        [StringLength(9)]
        public string CEP { get; set; }

        [StringLength(30)]
        public string Bairro { get; set; }

        [StringLength(30)]
        public string Estado { get; set; }

        [StringLength(30)]
        public string Cidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Clientes> GDC_Clientes { get; set; }
    }
}
