using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Factory.EntidadesFactory;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Models;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;
using static VendaDeAutomoveis.Entidades.Cliente;
using static VendaDeAutomoveis.Entidades.Venda;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    public class VendaController : Controller
    {
        private ClienteRepository _clienteRepository;
        private VendaRepository _vendaRepository;
        private VeiculoRepository _veiculoRepository;
        private FormaPagamentoRepository _formaPagamentoRepository;
        private EnderecoRepository _enderecoRepository;
        private PerfomanceRepository _perfomanceRepository;

        public VendaController(VendaRepository _vendaRepository, ClienteRepository _clienteRepository, VeiculoRepository _veiculoRepository,
            FormaPagamentoRepository _formaPagamentoRepository, EnderecoRepository _enderecoRepository, PerfomanceRepository _perfomanceRepository)
        {
            this._clienteRepository = _clienteRepository;
            this._vendaRepository = _vendaRepository;
            this._veiculoRepository = _veiculoRepository;
            this._formaPagamentoRepository = _formaPagamentoRepository;
            this._enderecoRepository = _enderecoRepository;
            this._perfomanceRepository = _perfomanceRepository;
        }

        public ActionResult FormularioCadastro()
        {
            var vendaViewModel = new CadastrarVendaViewModel();

            vendaViewModel.Clientes = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());
            vendaViewModel.FormasDePagamentos = new List<FormaDePagamento>();
            vendaViewModel.Veiculos = Mapper.Map<IList<GDC_Veiculos>, IList<Veiculo>>(_veiculoRepository.ObterTodos());
            vendaViewModel.Performance = new List<Performance>();
            vendaViewModel.Endereco = new Endereco();

            return View(vendaViewModel);
        }

        public ActionResult AdicionarVenda(Venda venda)
        {
            ViewBag.Cliente = _clienteRepository.ObterTodos();
            ViewBag.Veiculo = _veiculoRepository.ObterTodos();

            if (ModelState.IsValid)
            {
                var formaDePagamento = Mapper.Map<GDC_Formas_Pagamentos, FormaDePagamento>(_formaPagamentoRepository.ObterPorId(venda.IdFormaDePagamento));

                var cliente = Mapper.Map<GDC_Clientes, Cliente>(_clienteRepository.ObterPorId(venda.IdCliente));

                var vendaToDomain = Mapper.Map<Venda, GDC_Vendas>(venda);

                if (venda.Tipo_Entrega == 0)
                {
                    ModelState.AddModelError("TipoEntrega", "Escolha um tipo de Entrega!");
                    return View("FormularioCadastro", venda);
                }
                if (venda.Tipo_Entrega == EntregaVenda.Domiciliar && cliente.Endereco == null || venda.Tipo_Entrega == EntregaVenda.Domiciliar && cliente.Endereco.Numero == null
                    || venda.Tipo_Entrega == EntregaVenda.Domiciliar && cliente.Endereco.Estado == null || venda.Tipo_Entrega == EntregaVenda.Domiciliar && cliente.Endereco.Cidade == null
                    || venda.Tipo_Entrega == EntregaVenda.Domiciliar && cliente.Endereco.CEP == null)
                {

                    ModelState.AddModelError("TipoEntrega", " Para concluir a compra informe seu endereço na tela de clientes");
                    ViewBag.Cliente = _clienteRepository.ObterTodos();
                    ViewBag.Veiculo = _clienteRepository.ObterTodos();
                    ViewBag.ExibirCampo = true;
                    return View("FormularioCadastro", venda);
                }

                _vendaRepository.Inserir(vendaToDomain);
                MudarClienteComunParaVip(cliente);
                //Veiculo veiculo = veiculoRepository.ObterPorId(venda.Id);
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
            var vendaViewModel = Mapper.Map<IList<GDC_Vendas>, IList<Venda>>(_vendaRepository.ObterTodos());

            return View(vendaViewModel);
        }

        public ActionResult HistoricoPedidos(HistoricoPedidosModel historicoPedido)
        {
            ViewBag.Clientes = new SelectList(
                _clienteRepository.ObterTodos(),
                "Id",
                "Nome"
                );

            historicoPedido.Clientes = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());
            historicoPedido.Vendas = Mapper.Map<IList<GDC_Vendas>, IList<Venda>>(_vendaRepository.BuscarPorCliente(historicoPedido.IdCliente));

            return View(historicoPedido);
        }

        private void MudarClienteComunParaVip(Cliente cliente)
        {
            if (cliente.Tipo == TipoCliente.Comum)
            {
                var calcularGastoCliente = _vendaRepository.GastosPorCliente(cliente.Id);

                if (calcularGastoCliente >= 200000)
                    MudarClienteParaVip(cliente);

                _clienteRepository.Editar(cliente);
            }
        }

        private double AumentarValorVeiculoEsportivo(Venda venda)
        {
            var objVenda = Mapper.Map<Venda, GDC_Vendas>(CalcularVeiculoEsportivo(venda));

            _vendaRepository.Editar(objVenda);

            return objVenda.Valor;
        }

        private double CalcularPagamento(Venda venda)
        {
            var pgto12ComJuros = new PagamentoAPrazo12xComJuros();

            //var vendaToDomain = Mapper.Map<Venda, GDC_Vendas>(pgto12ComJuros.CalculaValor(venda.Valor));

            //vendaRepository.Editar(vendaToDomain);

            return venda.Valor;
        }

        public JsonResult ObterInformacoesBasicasCliente(Guid idCliente)
        {
            var vendaViewModel = new CadastrarVendaViewModel();

            vendaViewModel.Performance = Mapper.Map<IList<Performance>>(_perfomanceRepository.ObterPorIdCliente(idCliente));

            var cliente = _clienteRepository.ObterPorId(idCliente);

            if (cliente.Tipo == TipoCliente.Vip.ToString())
                vendaViewModel.FormasDePagamentos = Mapper.Map<IList<FormaDePagamento>>(_formaPagamentoRepository.ObterListarFormaPagamentoVip());
            else
                vendaViewModel.FormasDePagamentos = Mapper.Map<IList<FormaDePagamento>>(_formaPagamentoRepository.ObterFormaPagamentoComum());

            return Json(new { FormasPagamentos = vendaViewModel.FormasDePagamentos, Performances = vendaViewModel.Performance });
        }

        public ActionResult ObterValorVeiculo(Guid idVeiculo)
        {
            var veiculo = _veiculoRepository.ObterPorId(idVeiculo);
            //return Json(new { success = true, veiculo.Valor });
            return Content(veiculo.Valor.ToString());
        }

        //public PartialViewResult PegarFormaDePagamento(Guid IdCliente)
        //{
        //    var vendaViewModel = new CadastrarVendaViewModel();

        //    var cliente = _clienteRepository.ObterPorId(IdCliente);

        //    if (cliente.Tipo == TipoCliente.Vip.ToString())
        //        vendaViewModel.FormasDePagamentos = Mapper.Map<List<GDC_Formas_Pagamentos>, List<FormaDePagamento>>(_formaPagamentoRepository.ObterListarFormaPagamentoVip().ToList());
        //    else
        //        vendaViewModel.FormasDePagamentos = Mapper.Map<List<GDC_Formas_Pagamentos>, List<FormaDePagamento>>(_formaPagamentoRepository.ObterFormaPagamentoComum().ToList());

        //    return PartialView("_ParcialViewFormaDePagamento", vendaViewModel.FormasDePagamentos);
        //}

        public ActionResult ObterEnderecoCliente(Guid idCliente)
        {
            var obterCliente = _clienteRepository.ObterPorId(idCliente);

            var clienteEndereco = new Endereco();

            //if (obterCliente.IdEndereco.HasValue)
            //    clienteEndereco = _enderecoRepository.ObterPorId(obterCliente.IdEndereco);
            //else
            //    clienteEndereco = new Endereco();

            //var clienteEndereco = _enderecoRepository.BuscarPorIdCliente(idCliente);
            return PartialView("_ParcialviewEndereco", clienteEndereco);
        }

        public ActionResult AtualizarEnderecos(Guid idCliente, string Endereco, string Bairro, string NumeroDaCasa, string CEP, string Cidade, string Estado, string Complemento)
        {
            if (ModelState.IsValid)
            {
                var endereco = _enderecoRepository.BuscarPorIdCliente(idCliente);
                _enderecoRepository.Editar(endereco);

                return null;
            }
            else
            {
                return Content("Campo errado");
            }
        }
    }
}