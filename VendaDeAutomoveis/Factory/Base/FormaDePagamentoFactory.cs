//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using VendaDeAutomoveis.Entidades;
//using VendaDeAutomoveis.Factory.EntidadesFactory;

//namespace VendaDeAutomoveis.Factory
//{
//    public static class FormaDePagamentoFactory
//    {
//        public static IFormaDePagamento ObterFormaDePagamento(ModelosDePagamento TipoDePagamento)
//        {
//            IFormaDePagamento OpcaoDePagamento = null;

//            public double ObterFormaDePagamento(TipoCliente TipoDoCliente)
//        {         
//            IFormaDePagamento OpcaoDePagamento = null;

//                switch (TipoDoCliente == TipoCliente.Comum)
//                {
//                    case FormaPagamento.PagamentoAVista;
//                        OpcaoDePagamento = new PagamentoAVista();
//                        break;

//                    case FormaPagamento.PagamentoAPrazo12xComJuros:
//                        OpcaoDePagamento = new PagamentoAPrazo12xComJuros();
//                        break;

//                    case FormaPagamento.PagamentoAPrazo60xComJuros:
//                        OpcaoDePagamento = new PagamentoAPrazo60xComJuros();
//                        break;
//                }

//            switch(TipoDoCliente == TipoCliente.Vip)
//            {
//                    case FormaPagamento.PagamentoAVista:
//                        OpcaoDePagamento = new PagamentoAVista();
//                        break;
//                    case FormaPagamento.PagamentoAPrazo12xSemJuros:
//                        OpcaoDePagamento = new PagamentoAPrazo12xSemJuros();
//                        break;

//                    case FormaPagamento.PagamentoAPrazo60xSemJuros:
//                        OpcaoDePagamento = new PagamentoAPrazo60xSemJuros();
//                        break;
//            }

//            return OpcaoDePagamento;
//        }
        

//        public static IEnumerable<IFormaDePagamento> PegarFormaDePagamentoClienteVip()
//        {
//            var ListaDeFormaDePagamentosClienteVip = new List<IFormaDePagamento>();
//            ListaDeFormaDePagamentosClienteVip.Add(new PagamentoAVista());
//            ListaDeFormaDePagamentosClienteVip.Add(new PagamentoAPrazo12xComJuros());
//            ListaDeFormaDePagamentosClienteVip.Add(new PagamentoAPrazo60xSemJuros());

//            return ListaDeFormaDePagamentosClienteVip;
//        }

//        public static IEnumerable<IFormaDePagamento> PegarFormaDePagamentoClienteComum()
//        {
//            var ListaDeFormaDePagamentosClienteComum = new List<IFormaDePagamento>();
//            ListaDeFormaDePagamentosClienteComum.Add(new PagamentoAVista());
//            ListaDeFormaDePagamentosClienteComum.Add(new PagamentoAPrazo12xComJuros());
//            ListaDeFormaDePagamentosClienteComum.Add(new PagamentoAPrazo60xComJuros());

//            return ListaDeFormaDePagamentosClienteComum;
//        }
//    }
//}