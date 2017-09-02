using System;
using System.ComponentModel.DataAnnotations;

namespace VendaDeAutomoveis.Entidades
{
    public class Venda : Entity
    {
        
        //[Key]
        //[Required]
        //public int IdVenda { get; set; }

        //[Required(ErrorMessage = "Informe o valor do produto")]
        //public decimal Valor { get; set; }

        [Required(ErrorMessage="Informe a data da compra")]
        public DateTime DataCompra { get; set; }

        [Required]
        public Guid IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Informe o Modelo do Produto")]
        public Guid IdProduto { get; set; }
        
        public virtual Veiculo Veiculo { get; set; }

        [Required]
        public Guid IdFormaDePagamento { get; set; }

        public virtual FormaDePagamento FormaDePagamento { get; set; }

        //[Required(ErrorMessage = "Informe o Modelo do Produto")]
        //public int IdUpload { get; set; }

        //public virtual UploadArquivo Upload { get; set; }

        [Required(ErrorMessage = "Informe a Performance")]
        public Guid IdPerfomance { get; set; }

        public virtual Performance Perfomance { get; set; }

        [Required (ErrorMessage = "Informe o tipo de entrega")]
        public Entrega TipoEntrega { get; set; }

        [Required(ErrorMessage = "Informe uma observação sobre o veiculo")]
        public string Observacoes { get; set; }

        public enum Entrega
        {
            Domiciliar = 1, Loja = 2
        }

        public static Venda CalcularPagamento(Venda venda)
        {
            string recebendoObservacao = venda.Observacoes;

            if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAVista.ToString())
            {
                double desconto = 0.06;
                venda.Valor = (venda.Valor - Convert.ToDecimal(desconto)) - venda.Valor;
                venda.Observacoes = recebendoObservacao + " Pagamento à vista";
            }
            else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo12xComJuros.ToString())
            {
                double juros = 0.03;
                venda.Valor = (venda.Valor * Convert.ToDecimal(juros)) + venda.Valor;
                decimal parcela = venda.Valor;
                parcela = parcela / 12;
                venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            }
            else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo12xSemJuros.ToString())
            {
                decimal parcela = venda.Valor;
                parcela = parcela / 60;
                venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            }
            else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo60xComJuros.ToString())
            {
                double juros = 0.03;
                venda.Valor = (venda.Valor * Convert.ToDecimal(juros)) + venda.Valor;
                decimal parcela = venda.Valor;
                parcela = parcela / 12;
                venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            }
            else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo60xSemJuros.ToString())
            {
                decimal parcela = venda.Valor;
                parcela = parcela / 60;
                venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            }
            
            return venda;
        }

        public static Venda CalcularVeiculoEsportivo(Venda venda)
        {
            if (venda.Veiculo.TipoVeiculo == VeiculoTipo.Esportivo)
            {
                string recebendoObservacao = venda.Observacoes;
                venda.Valor = (venda.Valor + 12000);
                venda.Observacoes = recebendoObservacao + " / Veiculo Esportivo : Acréscimo de R$12.000,00 referente ao período de 12 meses de seguro obrigatório";
                //vendaRepository.Editar(venda);
            }

            return venda;
        }
    }
}