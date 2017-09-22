using AutoMapper;
using System;
using System.Collections.Generic;
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

        public VendaController(VendaRepository _vendaRepository, ClienteRepository _clienteRepository, VeiculoRepository _veiculoRepository, 
            FormaPagamentoRepository _formaPagamentoRepository, EnderecoRepository _enderecoRepository)
        {
            this._clienteRepository = _clienteRepository;
            this._vendaRepository = _vendaRepository;
            this._veiculoRepository = _veiculoRepository;
            this._formaPagamentoRepository = _formaPagamentoRepository;
            this._enderecoRepository = _enderecoRepository;
        }

        public ActionResult FormularioCadastro()
        {
            ViewBag.Cliente = _clienteRepository.ObterTodos();
            ViewBag.Veiculo = _veiculoRepository.ObterTodos();
            ViewBag.FormaDePagamento = _formaPagamentoRepository.ObterTodos();

            return View();
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
                "IdCliente",
                "Nome"
                );

            //historicoPedido.Clientes = clienteRepository.ObterTodos();

            //var historicoPedidos = Mapper.Map<IList<GDC_Vendas>, IList<Venda>>(vendaRepository.ObterTodos());

            //historicoPedido.Vendas = vendaRepository.BuscarPorCliente(historicoPedido.IdCliente);

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

        public ActionResult PegarPrecoProduto(Guid idVeiculo)
        {
            var veiculo = _veiculoRepository.ObterPorId(idVeiculo);
            return Content(veiculo.Valor.ToString());
        }

        public ActionResult PegarFormaDePagamento(Guid IdCliente)
        {
            var cliente = _clienteRepository.ObterPorId(IdCliente);

            IList<FormaDePagamento> formaPagamentoViewModel = new List<FormaDePagamento>();
            
            if (cliente.Tipo == TipoCliente.Vip.ToString())
                formaPagamentoViewModel = Mapper.Map<IList<GDC_Formas_Pagamentos>, IList<FormaDePagamento>>(_formaPagamentoRepository.ObterListarFormaPagamentoVip());
            else
                formaPagamentoViewModel = Mapper.Map<IList<GDC_Formas_Pagamentos>, IList<FormaDePagamento>>(_formaPagamentoRepository.ObterFormaPagamentoComum());

            return PartialView("_ParcialViewFormaDePagamento", formaPagamentoViewModel);
        }

        public ActionResult PegarEndereco(Guid idCliente)
        {
            var clienteEndereco = _enderecoRepository.BuscarPorIdCliente(idCliente);
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