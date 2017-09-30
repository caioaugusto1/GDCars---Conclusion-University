using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Enums
{
    public class EnumsExtensions
    {
        public enum TipoCliente
        {
            Ambos,
            Vip,
            Comum
        }

        public enum CorBanco
        {
            [Display(Name = "Branco")]
            Branco,
            [Display(Name = "Caramelo")]
            Caramelo,
            [Display(Name = "Cinza")]
            Cinza,
            [Display(Name = "Preto")]
            Preta
        }

        public enum ModeloBanco
        {
            [Display(Name = "Couro")]
            Couro,
            [Display(Name = "Pano")]
            Pano
        }

        public enum EstiloCorVeiculo
        {
            [Display(Name = "Brilhante")]
            Brilhante,
            [Display(Name = "Fosco")]
            Fosco,
            [Display(Name = "Normal")]
            Normal
        }

        public enum ModelosDePagamento
        {
            //Todos os clientes
            [Display(Name = "À Vista")]
            PagamentoAVista = 1,
            //Não vips 3% ao mês
            [Display(Name = "Prazo 12x com Juros")]
            PagamentoAPrazo12xComJuros = 2,
            //Vips
            [Display(Name = "Prazo 12x sem Juros")]
            PagamentoAPrazo12xSemJuros = 3,
            //Não vips 5% ao mes
            [Display(Name = "Prazo 60x com Juros")]
            PagamentoAPrazo60xComJuros = 4,
            //Vips
            [Display(Name = "Prazo 60x sem Juros")]
            PagamentoAPrazo60xSemJuros = 5
        }

        public enum CorRoda
        {
            [Display(Name = "Cinza")]
            Cinza,
            [Display(Name = "Cromada")]
            Cromada,
            [Display(Name = "Fosco")]
            Fosco,
            [Display(Name = "Preta")]
            Preta,
        }

        public enum TipoVeiculo
        {
            Esportivo,
            Hatch,
            Sedã,
            Picape,
            Perua,
        }

        public enum StatusVenda
        {
            [Display(Name = "Pedido Efetuado")]
            PedidoEfetuado,
            [Display(Name = "Pedido Entregue")]
            Entregue,
            [Display(Name = "Aguardando Liberação")]
            AguardandoLiberacao
        }

        public enum EntregaVenda
        {
            Domiciliar,
            Loja
        }
    }
}