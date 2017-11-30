using System;
using System.ComponentModel.DataAnnotations;
using VendaDeAutomoveis.Factory.EntidadesFactory;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Venda : Entity
    {
        [Required(ErrorMessage = "Informe o valor do produto")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Informe uma observação sobre o veiculo")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "Informe o tipo de entrega")]
        public EntregaVenda Tipo_Entrega { get; set; }

        public StatusVenda Status { get; set; }

        //[Required(ErrorMessage="Informe a data da compra")]
        //public DateTime DataCompra { get; set; }

        [Required(ErrorMessage = "Informe o tipo de entrega")]
        public bool Termo_Autorizacao { get; set; }

        [Required]
        public Guid IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        [Required]
        public Guid IdFormaDePagamento { get; set; }

        public virtual FormaDePagamento FormaDePagamento { get; set; }

        [Required(ErrorMessage = "Informe o Modelo do Produto")]
        public Guid IdVeiculo { get; set; }

        public virtual Veiculo Veiculo { get; set; }

        [Required(ErrorMessage = "Informe a Performance")]
        public Guid IdPerfomance { get; set; }

        public virtual Performance Perfomance { get; set; }
        
        [ScaffoldColumn(false)]
        public double? Parcela { get; set; }
        
        public static Venda CalcularPagamento(Venda venda)
        {
            string recebendoObservacao = venda.Observacoes;

            switch (venda.FormaDePagamento.Modelo)
            {
                case "À Vista":
                    PagamentoAVista pagamentoAVista = new PagamentoAVista();
                    venda.Valor += pagamentoAVista.CalcularDesconto(venda.Valor);
                    venda.Observacoes = recebendoObservacao + " Pagamento à vista";
                    break;

                case "Prazo 12x com Juros":
                    PagamentoAPrazo12xComJuros pagamentoAPrazo12XComJuros = new PagamentoAPrazo12xComJuros();
                    venda.Valor += pagamentoAPrazo12XComJuros.CalculaValor(venda.Valor);
                    venda.Parcela = pagamentoAPrazo12XComJuros.CalcularValorParcela(venda.Valor);
                    venda.Observacoes = recebendoObservacao + " Parcelas :" + venda.Parcela.Value.ToString("c") + " /mês";
                    break;

                case "Prazo 12x sem Juros":
                    PagamentoAPrazo12xSemJuros pagamentoAPrazo12XSemJuros = new PagamentoAPrazo12xSemJuros();
                    venda.Valor += pagamentoAPrazo12XSemJuros.CalculaValor(venda.Valor);
                    venda.Parcela = pagamentoAPrazo12XSemJuros.CalcularValorParcela(venda.Valor);
                    venda.Observacoes = recebendoObservacao + " Parcelas :" + venda.Parcela.Value.ToString("c") + " /mês";
                    break;

                case "Prazo 60x com Juros":
                    PagamentoAPrazo60xComJuros pagamentoAPrazo60XComJuros = new PagamentoAPrazo60xComJuros();
                    venda.Valor = pagamentoAPrazo60XComJuros.CalculaValor(venda.Valor);
                    venda.Parcela = pagamentoAPrazo60XComJuros.CalcularValorParcela(venda.Valor);
                    venda.Observacoes = recebendoObservacao + " Parcelas :" + venda.Parcela.Value.ToString("c") + " /mês";
                    break;

                case "Prazo 60x sem Juros":
                    PagamentoAPrazo60xSemJuros pagamentoAPrazo60XSemJuros = new PagamentoAPrazo60xSemJuros();
                    venda.Valor = pagamentoAPrazo60XSemJuros.CalculaValor(venda.Valor);
                    venda.Parcela = pagamentoAPrazo60XSemJuros.CalcularValorParcela(venda.Valor);
                    venda.Observacoes = recebendoObservacao + " Parcelas :" + venda.Parcela.Value.ToString("c") + " /mês";
                    break;

                default:
                    venda.Observacoes = "Por favor, selecione a forma de pagamento";
                    break;
            }
            
            return venda;
        }

        public static Venda CalcularVeiculoEsportivo(Venda venda)
        {
            venda.Valor = venda.Veiculo.Valor;
            venda.Valor += venda.Perfomance.ValorTotal;

            if (venda.Veiculo.Tipo == TipoVeiculo.Esportivo)
            {
                string recebendoObservacao = venda.Observacoes;
                venda.Valor += (venda.Valor + 12000);
                venda.Observacoes = recebendoObservacao + " / Veiculo Esportivo : Acréscimo de R$12.000,00 referente ao período de 12 meses de seguro obrigatório";
            }

            return venda;
        }
    }
}