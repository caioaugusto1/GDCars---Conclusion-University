namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GDCarsContextDiagrama : DbContext
    {
        public GDCarsContextDiagrama()
            : base("name=GDCarsContextDiagrama")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<GDC_Bancos> GDC_Bancos { get; set; }
        public virtual DbSet<GDC_Clientes> GDC_Clientes { get; set; }
        public virtual DbSet<GDC_Cor_Veiculos> GDC_Cor_Veiculos { get; set; }
        public virtual DbSet<GDC_Enderecos> GDC_Enderecos { get; set; }
        public virtual DbSet<GDC_Formas_Pagamentos> GDC_Formas_Pagamentos { get; set; }
        public virtual DbSet<GDC_Logins> GDC_Logins { get; set; }
        public virtual DbSet<GDC_Perfomances> GDC_Perfomances { get; set; }
        public virtual DbSet<GDC_Rodas> GDC_Rodas { get; set; }
        public virtual DbSet<GDC_Uploads> GDC_Uploads { get; set; }
        public virtual DbSet<GDC_Veiculos> GDC_Veiculos { get; set; }
        public virtual DbSet<GDC_Vendas> GDC_Vendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GDC_Bancos>()
                .Property(e => e.Modelo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Bancos>()
                .Property(e => e.Cor)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Bancos>()
                .Property(e => e.Valor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GDC_Bancos>()
                .HasMany(e => e.GDC_Perfomances)
                .WithOptional(e => e.GDC_Bancos)
                .HasForeignKey(e => e.IdBanco);

            modelBuilder.Entity<GDC_Clientes>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Clientes>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Clientes>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Clientes>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Clientes>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Clientes>()
                .HasMany(e => e.GDC_Perfomances)
                .WithRequired(e => e.GDC_Clientes)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<GDC_Clientes>()
                .HasMany(e => e.GDC_Vendas)
                .WithRequired(e => e.GDC_Clientes)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GDC_Cor_Veiculos>()
                .Property(e => e.Estilo)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Cor_Veiculos>()
                .HasMany(e => e.GDC_Perfomances)
                .WithOptional(e => e.GDC_Cor_Veiculos)
                .HasForeignKey(e => e.IdCor_Veiculo);

            modelBuilder.Entity<GDC_Enderecos>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Enderecos>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Enderecos>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Enderecos>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Enderecos>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Enderecos>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Enderecos>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Enderecos>()
                .HasMany(e => e.GDC_Clientes)
                .WithOptional(e => e.GDC_Enderecos)
                .HasForeignKey(e => e.IdEndereco);

            modelBuilder.Entity<GDC_Formas_Pagamentos>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Formas_Pagamentos>()
                .Property(e => e.Tipo_Cliente)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Formas_Pagamentos>()
                .HasMany(e => e.GDC_Vendas)
                .WithRequired(e => e.GDC_Formas_Pagamentos)
                .HasForeignKey(e => e.IdFormaPagamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GDC_Logins>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Logins>()
                .Property(e => e.SobreNome)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Logins>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Logins>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Logins>()
                .Property(e => e.Confirmar_Senha)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Perfomances>()
                .HasMany(e => e.GDC_Vendas)
                .WithOptional(e => e.GDC_Perfomances)
                .HasForeignKey(e => e.IdPerformance);

            modelBuilder.Entity<GDC_Rodas>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Rodas>()
                .Property(e => e.Cor)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Rodas>()
                .HasMany(e => e.GDC_Perfomances)
                .WithOptional(e => e.GDC_Rodas)
                .HasForeignKey(e => e.IdRoda);

            modelBuilder.Entity<GDC_Uploads>()
                .Property(e => e.Nome_Arquivo)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Uploads>()
                .HasMany(e => e.GDC_Bancos)
                .WithRequired(e => e.GDC_Uploads)
                .HasForeignKey(e => e.IdUpload)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GDC_Uploads>()
                .HasMany(e => e.GDC_Rodas)
                .WithOptional(e => e.GDC_Uploads)
                .HasForeignKey(e => e.IdUpload);

            modelBuilder.Entity<GDC_Uploads>()
                .HasMany(e => e.GDC_Veiculos)
                .WithOptional(e => e.GDC_Uploads)
                .HasForeignKey(e => e.IdUpload);

            modelBuilder.Entity<GDC_Veiculos>()
                .Property(e => e.Fabricante)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Veiculos>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Veiculos>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Veiculos>()
                .HasMany(e => e.GDC_Vendas)
                .WithRequired(e => e.GDC_Veiculos)
                .HasForeignKey(e => e.IdVeiculo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GDC_Vendas>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Vendas>()
                .Property(e => e.Tipo_Entrega)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GDC_Vendas>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
