namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Perfomances
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Perfomances()
        {
            GDC_Vendas = new HashSet<GDC_Vendas>();
        }

        public Guid Id { get; set; }

        public double ValorTotal { get; set; }

        public Guid IdCliente { get; set; }

        public Guid? IdRoda { get; set; }

        public Guid? IdBanco { get; set; }

        public Guid? IdCor_Veiculo { get; set; }

        public virtual GDC_Bancos GDC_Bancos { get; set; }

        public virtual GDC_Clientes GDC_Clientes { get; set; }

        public virtual GDC_Cor_Veiculos GDC_Cor_Veiculos { get; set; }

        public virtual GDC_Rodas GDC_Rodas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Vendas> GDC_Vendas { get; set; }
    }
}
