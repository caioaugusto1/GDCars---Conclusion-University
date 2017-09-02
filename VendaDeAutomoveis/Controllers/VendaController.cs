using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Models;
using VendaDeAutomoveis.Repository;
using static VendaDeAutomoveis.Entidades.Cliente;
using static VendaDeAutomoveis.Entidades.Venda;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    public class VendaController : Controller
    {
        private ClienteRepository clienteRepository;
        private VendaRepository vendaRepository;
        private VeiculoRepository veiculoRepository;
        private FormaPagamentoRepository formaPagamentoRepository;
        private EnderecoRepository enderecoRepository;

        public VendaController(VendaRepository vendaRepository, ClienteRepository clienteRepository, VeiculoRepository veiculoRepository, FormaPagamentoRepository formaPagamentoRepository, EnderecoRepository enderecoRepository)
        {
            this.clienteRepository = clienteRepository;
            this.vendaRepository = vendaRepository;
            this.veiculoRepository = veiculoRepository;
            this.formaPagamentoRepository = formaPagamentoRepository;
            this.enderecoRepository = enderecoRepository;
        }

        public ActionResult FormularioCadastro()
        {
            ViewBag.Cliente = clienteRepository.ObterTodos();
            ViewBag.Veiculo = veiculoRepository.ObterTodos();
            ViewBag.FormaDePagamento = formaPagamentoRepository.ObterTodos();
            return View();
        }
        public ActionResult AdicionarVenda(Venda venda)
        {
            ViewBag.Cliente = clienteRepository.ObterTodos();
            ViewBag.Veiculo = veiculoRepository.ObterTodos();

            if (ModelState.IsValid)
            {
                FormaDePagamento formaDePagamento = formaPagamentoRepository.ObterPorId(venda.IdFormaDePagamento);
                Cliente cliente = clienteRepository.ObterPorId(venda.IdCliente);

                if (venda.TipoEntrega == 0)
                {
                    ModelState.AddModelError("TipoEntrega", "Escolha um tipo de Entrega!");
                    return View("FormularioCadastro", venda);
                }
                if (venda.TipoEntrega == Entrega.Domiciliar && cliente.Endereco == null || venda.TipoEntrega == Entrega.Domiciliar && cliente.Endereco.Numero == null
                    || venda.TipoEntrega == Entrega.Domiciliar && cliente.Endereco.Estado == null || venda.TipoEntrega == Entrega.Domiciliar && cliente.Endereco.Cidade == null
                    || venda.TipoEntrega == Entrega.Domiciliar && cliente.Endereco.CEP == null)
                {

                    ModelState.AddModelError("TipoEntrega", " Para concluir a compra informe seu endereço na tela de clientes");
                    ViewBag.Cliente = clienteRepository.ObterTodos();
                    ViewBag.Veiculo = clienteRepository.ObterTodos();
                    ViewBag.ExibirCampo = true;
                    return View("FormularioCadastro", venda);
                }

                vendaRepository.Adicionar(venda);
                MudarClienteComunParaVip(cliente);
                Veiculo veiculo = veiculoRepository.ObterPorId(venda.Id);
                AumentarValorVeiculoEsportivo(venda);
                CalcularPagamento(venda);
                return RedirectToAction("Index");
            }
            else
            {
                return View("FormularioCadastro");
            }
        }

        public ActionResult Index()
        {
            IList<Venda> vendas = vendaRepository.ObterTodos();
            return View(vendas);
        }

        public ActionResult HistoricoPedidos(HistoricoPedidosModel historicoPedido)
        {
            ViewBag.Clientes = new SelectList(
                clienteRepository.ObterTodos(),
                "IdCliente",
                "Nome"
                );

            historicoPedido.Clientes = clienteRepository.ObterTodos();
            historicoPedido.Vendas = vendaRepository.BuscarPorCliente(historicoPedido.IdCliente);

            return View(historicoPedido);
        }

        private void MudarClienteComunParaVip(Cliente cliente)
        {
            if(cliente.TipoDoCliente == TipoCliente.Comum)
            {
                var calcularGastoCliente = vendaRepository.GastosPorCliente(cliente.IdCliente);

                if (calcularGastoCliente >= 200000)
                    MudarClienteParaVip(cliente);
            }
            
            //if (cliente.TipoDoCliente == TipoCliente.Comum && vendaRepository.GastosPorCliente(cliente.IdCliente) >= 200000)
            //{
            //    cliente.TipoDoCliente = TipoCliente.Vip;
            //    clienteRepository.Editar(cliente);
            //}
        }

        private decimal AumentarValorVeiculoEsportivo(Venda venda)
        {
            var objVenda = CalcularVeiculoEsportivo(venda);
            vendaRepository.Editar(objVenda);
            return objVenda.Valor;
            
            //if (venda.Veiculo.TipoVeiculo == VeiculoTipo.Esportivo)
            //{
            //    string recebendoObservacao = venda.Observacoes;
            //    venda.Valor = (venda.Valor + 12000);
            //    venda.Observacoes = recebendoObservacao + " / Veiculo Esportivo : Acréscimo de R$12.000,00 referente ao período de 12 meses de seguro obrigatório";
            //    vendaRepository.Editar(venda);
            //}
            //return venda.Valor;
        }

        private decimal CalcularPagamento(Venda venda)
        {
            var objVenda = CalcularPagamento(venda);
            //string recebendoObservacao = venda.Observacoes;

            //if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAVista.ToString())
            //{
            //    venda.Observacoes = recebendoObservacao + " Financiamento com pagamento à vista";
            //}
            //else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo12xComJuros.ToString())
            //{
            //    decimal parcela = venda.Valor;
            //    parcela = parcela / 12;
            //    venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            //}
            //else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo12xSemJuros.ToString())
            //{
            //    decimal parcela = venda.Valor;
            //    parcela = parcela / 60;
            //    venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            //}
            //else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo60xComJuros.ToString())
            //{
            //    double juros = 0.03;
            //    venda.Valor = (venda.Valor * Convert.ToDecimal(juros)) + venda.Valor;
            //    decimal parcela = venda.Valor;
            //    parcela = parcela / 12;
            //    venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            //}
            //else if (venda.FormaDePagamento.ModeloFormaDePagamento == ModelosDePagamento.PagamentoAPrazo60xSemJuros.ToString())
            //{
            //    double juros = 0.05;
            //    venda.Valor = (venda.Valor * Convert.ToDecimal(juros)) + venda.Valor;
            //    decimal parcela = venda.Valor;
            //    parcela = parcela / 60;
            //    venda.Observacoes = recebendoObservacao + " Parcelas :" + parcela.ToString("c") + " /mês";
            //}
            vendaRepository.Editar(venda);

            return venda.Valor;
        }

        public ActionResult PegarPrecoProduto(Guid id)
        {
            var produto = veiculoRepository.ObterPorId(id);
            return Content(produto.Valor.ToString());
        }

        public ActionResult PegarFormaDePagamento(Guid IdCliente)
        {
            var cliente = clienteRepository.ObterPorId(IdCliente);

            IList<FormaDePagamento> formasPagamentos = new List<FormaDePagamento>();

            if (cliente.TipoDoCliente == TipoCliente.Vip)
                formasPagamentos = formaPagamentoRepository.ObterListarFormaPagamentoVip();
            else
                formasPagamentos = formaPagamentoRepository.ObterFormaPagamentoComum();

            return PartialView("_ParcialViewFormaDePagamento", formasPagamentos);
        }

        public ActionResult PegarEndereco(Guid idCliente)
        {
            var clienteEndereco = enderecoRepository.PegarEnderencoPorIdCliente(idCliente);
            return PartialView("_ParcialviewEndereco", clienteEndereco);
        }

        public ActionResult AtualizarEnderecos(Guid idCliente, string Endereco, string Bairro, string NumeroDaCasa, string CEP, string Cidade, string Estado, string Complemento)
        {

            if (ModelState.IsValid)
            {
                var endereco = enderecoRepository.PegarEnderencoPorIdCliente(idCliente);

                endereco.EnderecoNome = Endereco;
                endereco.Bairro = Bairro;
                endereco.Numero = NumeroDaCasa;
                endereco.CEP = CEP;
                endereco.Cidade = Cidade;
                endereco.Estado = Estado;
                endereco.Complemento = Complemento;

                enderecoRepository.EditarEndereco(endereco);

                return null;
            }
            else
            {
                return Content("Campo errado");
            }
        }
    }
}