using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.IdCliente);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("nvarchar");

            Property(c => c.CPF)
                .IsRequired()
                //.HasMaxLength(11)
                .HasColumnType("int")
                //.IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(c => c.RG)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar")
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_RG") { IsUnique = true }));

            Property(c => c.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            Property(c => c.TipoDoCliente)
                .IsRequired()
                .HasColumnType("char");

            //HasOptional(c => c.Endereco)
            //    .WithOptionalDependent(c => c.Cliente);  

            //this.HasOptional(c => c.EnderecoNome)
            //    .WithMany(c => c.Cliente)
            //    .HasForeignKey(c => c.IdEndereco)
            //    .WillCascadeOnDelete(false);

            ToTable("GDC_Clientes");

        }
    }
}