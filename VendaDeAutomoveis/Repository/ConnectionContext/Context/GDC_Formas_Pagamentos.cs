//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VendaDeAutomoveis.Repository.ConnectionContext.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class GDC_Formas_Pagamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GDC_Formas_Pagamentos()
        {
            this.GDC_Vendas = new HashSet<GDC_Vendas>();
        }
    
        public string Id { get; set; }
        public string Modelo { get; set; }
        public string Tipo_Cliente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GDC_Vendas> GDC_Vendas { get; set; }
    }
}