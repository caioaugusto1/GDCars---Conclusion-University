using System.Data.Entity.ModelConfiguration;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.EnderecoNome)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar");

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Complemento)
                .HasMaxLength(5)
                .IsOptional()
                .HasColumnType("varchar");

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("int");

            Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            //HasRequired(c => c.Cliente)
            //    .WithMany()
            //    .Map(c => c.MapKey("IdCliente"));

            ToTable("GDC_Enderecos");

            //http://netcoders.com.br/mapeamento-com-entity-framework-code-first-fluent-api-parte-2/

            //HasRequired(c => c.Cliente)
            //    .WithRequiredPrincipal(a => a.EnderecoNome);

            //1:1 - 1 aluno deve ter apenas 1 usuário
            //HasRequired(x => x.Cliente)
            //  .WithRequiredPrincipal();

            //HasRequired(c => c.Cliente)
            //    .WithMany()
            //    .Map(c => c.MapKey("IdCliente"));

            //this.HasRequired(c => c.Cliente)
            //    .WithMany(c => c.EnderecoNome.Cliente)
            //    .HasForeignKey(c => c.IdCliente)
            //    .WillCascadeOnDelete(false);

        }
    }
}