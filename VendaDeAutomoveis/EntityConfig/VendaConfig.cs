using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.EntityConfig
{
    public class VendaConfig : EntityTypeConfiguration<Venda>
    {
        public VendaConfig()
        {
            HasKey(v => v.Id);

            Property(v => v.DataCompra)
                .HasColumnType("datetime");

            Property(v => v.TipoEntrega)
                .IsRequired()
                .HasColumnType("char");
            
            Property(c => c.Valor)
                .IsRequired()
                .HasColumnType("decimal");

            Property(c => c.Observacoes)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(500);

            HasRequired(c => c.Cliente)
                .WithMany()
                .Map(c => c.MapKey("IdCliente"));

            HasRequired(c => c.Veiculo)
                .WithMany()
                .Map(c => c.MapKey("IdProduto"));

            HasRequired(c => c.FormaDePagamento)
                .WithMany()
                .Map(c => c.MapKey("IdFormaDePagamento"));

            HasRequired(c => c.FormaDePagamento)
                .WithMany()
                .Map(c => c.MapKey("IdPerfomance"));
        }
    }
}