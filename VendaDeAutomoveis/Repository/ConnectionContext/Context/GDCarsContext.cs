using System.Data.Entity;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Repository
{
    public class ContextGDCars : DbContext
    {
        public ContextGDCars()
            : base ("ContextGDCars")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasOptional(e => e.Endereco)
                .WithMany().WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<FormaDePagamento> FormasPagamentos { get; set; }
        public virtual DbSet<Roda> Rodas { get; set; }
        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<Cor_Veiculo> Cores { get; set; }
        public virtual DbSet<Performance> Perfomances { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Upload> Uploads { get; set; }
    }
}