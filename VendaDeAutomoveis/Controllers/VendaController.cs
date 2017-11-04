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
        #region Instâncias Repositorys

        private ClienteRepository _clienteRepository;
        private VendaRepository _vendaRepository;
        private VeiculoRepository _veiculoRepository;
        private FormaPagamentoRepository _formaPagamentoRepository;
        private EnderecoRepository _enderecoRepository;
        private PerfomanceRepository _perfomanceRepository;
        private RodaRepository _rodaRepository;
        private BancoRepository _bancoRepository;
        private CorVeiculoRepository _corRepository;

        #endregion

        #region Método Construtor

        public VendaController(VendaRepository _vendaRepository, ClienteRepository _clienteRepository, VeiculoRepository _veiculoRepository,
            FormaPagamentoRepository _formaPagamentoRepository, EnderecoRepository _enderecoRepository, PerfomanceRepository _perfomanceRepository,
            RodaRepository _rodaRepository, BancoRepository _bancoRepository, CorVeiculoRepository _corRepository)
        {
            this._clienteRepository = _clienteRepository;
            this._vendaRepository = _vendaRepository;
            this._veiculoRepository = _veiculoRepository;
            this._formaPagamentoRepository = _formaPagamentoRepository;
            this._enderecoRepository = _enderecoRepository;
            this._perfomanceRepository = _perfomanceRepository;
            this._rodaRepository = _rodaRepository;
            this._bancoRepository = _bancoRepository;
            this._corRepository = _corRepository;
        }

        #endregion

        public ActionResult Index()
        {
            var vendaViewModel = Mapper.Map<IList<GDC_Vendas>, IList<Venda>>(_vendaRepository.ObterTodos());

            return View(vendaViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CadastrarVendaViewModel vendaViewModel = new CadastrarVendaViewModel();

            vendaViewModel.Clientes = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());
            vendaViewModel.FormasDePagamentos = Mapper.Map<IList<GDC_Formas_Pagamentos>, IList<FormaDePagamento>>(_formaPagamentoRepository.ObterTodos());
            vendaViewModel.Veiculos = Mapper.Map<IList<GDC_Veiculos>, IList<Veiculo>>(_veiculoRepository.ObterTodos());
            vendaViewModel.Performance = Mapper.Map<IList<GDC_Perfomances>, IList<Performance>>(_perfomanceRepository.ObterTodos());
            vendaViewModel.Endereco = new Endereco();

            return View(vendaViewModel);
        }

        [HttpPost]
        public ActionResult Create(CadastrarVendaViewModel cadVenda)
        {
            cadVenda.IdPerformance = Guid.Parse("07374954-2C92-4712-BF99-2AAE9B6552F7");

            if (cadVenda.Tipo_Entrega != EntregaVenda.Domiciliar && cadVenda.Tipo_Entrega != EntregaVenda.Loja)
            {
                ModelState.AddModelError("TipoEntrega", "Escolha um tipo de Entrega!");
                return View("Create", cadVenda);
            }

            if (ModelState.IsValid)
            {
                if (cadVenda.Tipo_Entrega == EntregaVenda.Domiciliar)
                {
                    if (cadVenda.Endereco == null || cadVenda.Endereco.Numero == null || cadVenda.Endereco.Estado == null
                        || cadVenda.Endereco.Cidade == null || cadVenda.Endereco.CEP == null)
                    {
                        ModelState.AddModelError("TipoEntrega", " Para concluir a compra informe seu endereço na tela de clientes");
                        ViewBag.ExibirCampo = true;
                        return View("Create", cadVenda);
                    }
                }

                cadVenda.Venda = Mapper.Map<Venda>(cadVenda);
                
                cadVenda.Venda = CalcularVeiculoEsportivo(cadVenda.Venda);
                cadVenda.Venda = CalcularPagamento(cadVenda.Venda);

                return RedirectToAction("DetailsConfirmar", cadVenda );
            }
            else
            {
                return View("Create", cadVenda);
            }

            #region Coments
            //ViewBag.Cliente = _clienteRepository.ObterTodos();
            //ViewBag.Veiculo = _veiculoRepository.ObterTodos();

            //var venda = new Venda()
            //{
            //    IdCliente = cadVenda.IdCliente,
            //    IdVeiculo = cadVenda.IdVeiculo,
            //    IdFormaDePagamento = cadVenda.IdFormaDePagamento,
            //    IdPerfomance = cadVenda.IdPerformance,
            //    Valor = cadVenda.Valor,
            //    Tipo_Entrega = cadVenda.Tipo_Entrega,
            //    Status = cadVenda.Status,
            //    Observacoes = cadVenda.Observacoes
            //};

            //if (cadVenda.Tipo_Entrega != EntregaVenda.Domiciliar && cadVenda.Tipo_Entrega != EntregaVenda.Loja)
            //{
            //    ModelState.AddModelError("TipoEntrega", "Escolha um tipo de Entrega!");
            //    return View("Create", cadVenda);
            //}

            //if (ModelState.IsValid)
            //{
            //    var formaDePagamento = Mapper.Map<GDC_Formas_Pagamentos, FormaDePagamento>(_formaPagamentoRepository.ObterPorId(cadVenda.IdFormaDePagamento));

            //    var cliente = Mapper.Map<GDC_Clientes, Cliente>(_clienteRepository.ObterPorId(cadVenda.IdCliente));

            //    var vendaToDomain = Mapper.Map<Venda, GDC_Vendas>(venda);

            //    vendaToDomain.IdFormaPagamento = formaDePagamento.Id;
            //    vendaToDomain.IdPerformance = cadVenda.IdPerformance;

            //    if (venda.Tipo_Entrega == EntregaVenda.Domiciliar)
            //    {
            //        if(cliente.Endereco == null || cliente.Endereco.Numero == null || cliente.Endereco.Estado == null 
            //            || cliente.Endereco.Cidade == null || cliente.Endereco.CEP == null)
            //        {

            //            ModelState.AddModelError("TipoEntrega", " Para concluir a compra informe seu endereço na tela de clientes");
            //            ViewBag.Cliente = _clienteRepository.ObterTodos();
            //            ViewBag.Veiculo = _clienteRepository.ObterTodos();
            //            ViewBag.ExibirCampo = true;
            //            return View("Create", cadVenda);
            //        }
            //    }

            //    _vendaRepository.Inserir(vendaToDomain);
            //    MudarClienteComunParaVip(cliente);
            //    //Veiculo veiculo = veiculoRepository.ObterPorId(venda.Id);
            //    AumentarValorVeiculoEsportivo(venda);
            //    CalcularPagamento(venda);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View("Create", cadVenda);
            //}
            #endregion

        }

        [HttpGet]
        public ActionResult DetailsConfirmar(CadastrarVendaViewModel cadVenda)
        {
            cadVenda.IdPerformance = Guid.Parse("07374954-2c92-4712-bf99-2aae9b6552f7");

            DetailsDeleteVendaViewModel detailsDeleteVendaViewModel = new DetailsDeleteVendaViewModel();

            detailsDeleteVendaViewModel.Cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(cadVenda.IdCliente));
            detailsDeleteVendaViewModel.Performance = Mapper.Map<Performance>(_perfomanceRepository.ObterPorId(cadVenda.IdPerformance));
            detailsDeleteVendaViewModel.Roda = Mapper.Map<Roda>(_rodaRepository.ObterPorId(detailsDeleteVendaViewModel.Performance.IdRoda));
            detailsDeleteVendaViewModel.Banco = Mapper.Map<Banco>(_bancoRepository.ObterPorId(detailsDeleteVendaViewModel.Performance.IdBanco));
            detailsDeleteVendaViewModel.Cor_Veiculo = Mapper.Map<Cor_Veiculo>(_corRepository.ObterPorId(detailsDeleteVendaViewModel.Performance.IdCorVeiculo));
            detailsDeleteVendaViewModel.Veiculo = Mapper.Map<Veiculo>(_veiculoRepository.ObterPorId(cadVenda.IdVeiculo));
            detailsDeleteVendaViewModel.Endereco = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(cadVenda.IdEndereco));
            detailsDeleteVendaViewModel.FormaDePagamento = Mapper.Map<FormaDePagamento>(_formaPagamentoRepository.ObterPorId(cadVenda.IdFormaDePagamento));
            detailsDeleteVendaViewModel.Venda = Mapper.Map<Venda>(cadVenda.Venda);

            return View(detailsDeleteVendaViewModel);
        }

        [HttpPost]
        public ActionResult Confirmar(DetailsDeleteVendaViewModel cadVenda)
        {
            var e = new GDC_Vendas()
            {
                IdCliente = cadVenda.Cliente.Id,
                IdVeiculo = cadVenda.Veiculo.Id,
                IdFormaPagamento = cadVenda.FormaDePagamento.Id,
                IdPerformance = cadVenda.Performance.Id,
                Valor = cadVenda.Veiculo.Valor,
                Observacao = cadVenda.Venda.Observacoes,
                Tipo_Entrega = cadVenda.Venda.Tipo_Entrega.ToString(),
                Status = cadVenda.Venda.Status.ToString(),
            };

            _vendaRepository.Inserir(Mapper.Map<GDC_Vendas>(e));
            return View("Index");
           }

        public ActionResult HistoricoPedidos()
        {
            List<HistoricoPedidosModel> historicoPedidoVM = new List<HistoricoPedidosModel>();

            //var list = Mapper.Map<List<GDC_Vendas>, List<Venda>>(_vendaRepository.ObterTodos().ToList());
            //historicoPedidoVM.Clientes = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos().ToList());

            //foreach(var item in list)
            //{
            //    historicoPedidoVM.Add(item);
            //}


            return View(historicoPedidoVM);
        }

        private void MudarClienteComunParaVip(Cliente cliente)
        {
            if (cliente.Tipo == TipoCliente.Comum)
            {
                var calcularGastoCliente = _vendaRepository.GastosPorCliente(cliente.Id);

                if (calcularGastoCliente >= 200000)
                    MudarClienteParaVip(cliente);

                _clienteRepository.Editar(Mapper.Map<GDC_Clientes>(cliente));
            }
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
            return Content(veiculo.Valor.ToString());
        }

        public ActionResult PegarFormaDePagamento(Guid IdCliente)
        {
            var vendaViewModel = new CadastrarVendaViewModel();

            var cliente = _clienteRepository.ObterPorId(IdCliente);

            if (cliente.Tipo == TipoCliente.Vip.ToString())
                vendaViewModel.FormasDePagamentos = Mapper.Map<List<GDC_Formas_Pagamentos>, List<FormaDePagamento>>(_formaPagamentoRepository.ObterListarFormaPagamentoVip().ToList());
            else
                vendaViewModel.FormasDePagamentos = Mapper.Map<List<GDC_Formas_Pagamentos>, List<FormaDePagamento>>(_formaPagamentoRepository.ObterFormaPagamentoComum().ToList());

            return PartialView("_ParcialViewFormaDePagamento", vendaViewModel.FormasDePagamentos);
        }

        public PartialViewResult ObterEnderecoCliente(Guid idCliente)
        {
            var cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(idCliente));

            if (cliente.IdEndereco.HasValue)
                cliente.Endereco = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(cliente.IdEndereco.Value));
            else
                cliente.Endereco = new Endereco();

            return PartialView("_ParcialviewEndereco", cliente.Endereco);
        }

        public ActionResult AtualizarEnderecos(Guid idCliente, string Endereco, string Bairro, string NumeroDaCasa, 
            string CEP, string Cidade, string Estado, string Complemento)
        {
            if (ModelState.IsValid)
            {
                var infoCliente = _clienteRepository.ObterPorId(idCliente);
                
                var newEndereco = new GDC_Enderecos()
                {
                    Endereco = Endereco,
                    Bairro = Bairro,
                    Numero = NumeroDaCasa,
                    CEP = CEP,
                    Cidade = Cidade,
                    Estado = Estado,
                    Complemento = Complemento
                };

                var endereco = new Endereco();

                if (infoCliente.IdEndereco.HasValue)
                {
                    endereco = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(infoCliente.IdEndereco.Value));
                    
                    if (endereco != null)
                    {
                        _enderecoRepository.Editar(newEndereco);
                    }
                }
                else
                {
                    newEndereco.Id = Guid.NewGuid();

                    _enderecoRepository.Inserir(newEndereco);
                    _clienteRepository.Atualizar(newEndereco.Id, idCliente);
                }

                return Content("OK");
            }
            else
            {
                return Content("Campo errado");
            }
        }
    }
}