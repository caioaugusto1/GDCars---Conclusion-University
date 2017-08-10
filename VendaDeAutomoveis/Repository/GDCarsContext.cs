using System.Data.Entity;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.Repository
{
    public class GDCarsContext : DbContext
    {
        public GDCarsContext()
            : base ("GDCarsContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<GDC_Clientes> Clientes { get; set; }
        public virtual DbSet<GDC_Veiculos> Veiculos { get; set; }
        public virtual DbSet<GDC_Vendas> Vendas { get; set; }
        public virtual DbSet<GDC_Logins> Logins { get; set; }
        public virtual DbSet<GDC_Formas_Pagamentos> FormasPagamentos { get; set; }
        public virtual DbSet<GDC_Rodas> Rodas { get; set; }
        public virtual DbSet<GDC_Bancos> Bancos { get; set; }
        public virtual DbSet<GDC_Cores_Externa> Cores { get; set; }
        public virtual DbSet<GDC_Perfomances> Perfomances { get; set; }
        public virtual DbSet<GDC_Enderecos> Enderecos { get; set; }
        public virtual DbSet<GDC_Uploads> Uploads { get; set; }
    }
}