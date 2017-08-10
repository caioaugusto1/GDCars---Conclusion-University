using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.EntityConfig
{
    public class FormaPagamentoConfig : EntityTypeConfiguration<FormaDePagamento>
    {
        public FormaPagamentoConfig()
        {
            HasKey(f => f.IdFormaDePagamento);

            Property(f => f.ModeloFormaDePagamento)
               .HasColumnType("varchar")
               .HasMaxLength(30);

            ToTable("GDC_Formas_Pagamento");

        }
    }
}