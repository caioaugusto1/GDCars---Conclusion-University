namespace VendaDeAutomoveis.Repository.ConnectionContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GDC_Vendas
    {
        public Guid Id { get; set; }

        public double Valor { get; set; }

        [Required]
        [StringLength(500)]
        public string Observacao { get; set; }

        [Required]
        [StringLength(10)]
        public string Tipo_Entrega { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public bool Termo_Autorizacao { get; set; }

        public Guid IdCliente { get; set; }

        public Guid IdFormaPagamento { get; set; }

        public Guid IdVeiculo { get; set; }

        public Guid? IdPerformance { get; set; }

        public virtual GDC_Clientes GDC_Clientes { get; set; }

        public virtual GDC_Formas_Pagamentos GDC_Formas_Pagamentos { get; set; }

        public virtual GDC_Perfomances GDC_Perfomances { get; set; }

        public virtual GDC_Veiculos GDC_Veiculos { get; set; }
    }
}
