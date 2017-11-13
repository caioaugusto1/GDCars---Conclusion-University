using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VendaDeAutomoveis.Controllers.Base;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Models;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;
using static VendaDeAutomoveis.Entidades.Cliente;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("administrativo-vendas")]
    public class VendaController : BaseController
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

        [Route("listar-vendas")]
        public ActionResult Index()
        {
            try
            {
                var vendaViewModel = new ListarVendasViewModel();
                List<ListarVendasViewModel> vendasViewModel = new List<ListarVendasViewModel>();

                var vendas = Mapper.Map<List<Venda>>(_vendaRepository.ObterTodos());

                vendas.ForEach(ven =>
                {
                    vendaViewModel = new ListarVendasViewModel();

                    vendaViewModel.Vendas = ven;
                    vendaViewModel.Clientes = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(ven.IdCliente));
                    vendaViewModel.Veiculos = Mapper.Map<Veiculo>(_veiculoRepository.ObterPorId(ven.IdVeiculo));

                    vendasViewModel.Add(vendaViewModel);
                });

                return View(vendasViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Base");
            }
            
        }

        [HttpGet]
        [Route("cadastrar-venda")]
        public ActionResult Create()
        {
            CadastrarVendaViewModel vendaViewModel = new CadastrarVendaViewModel();

            vendaViewModel.Clientes = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());
            vendaViewModel.FormasDePagamentos = new List<FormaDePagamento>();
            vendaViewModel.Veiculos = Mapper.Map<IList<GDC_Veiculos>, IList<Veiculo>>(_veiculoRepository.ObterTodos());
            vendaViewModel.Performance = Mapper.Map<IList<GDC_Perfomances>, IList<Performance>>(_perfomanceRepository.ObterTodos());
            vendaViewModel.Endereco = new Endereco();

            return View(vendaViewModel);
        }

        [HttpPost]
        public ActionResult Create(CadastrarVendaViewModel cadVenda)
        {
            if (cadVenda.Tipo_Entrega != EntregaVenda.Domiciliar && cadVenda.Tipo_Entrega != EntregaVenda.Loja)
            {
                ModelState.AddModelError("TipoEntrega", "Escolha um tipo de Entrega!");
                return View("Create", cadVenda);
            }

            if (ModelState.IsValid)
            {
                if (cadVenda.Tipo_Entrega == EntregaVenda.Domiciliar)
                {
                    if (cadVenda.Endereco == null || !string.IsNullOrWhiteSpace(cadVenda.Endereco.Numero) || !string.IsNullOrWhiteSpace(cadVenda.Endereco.Estado)
                        || !string.IsNullOrWhiteSpace(cadVenda.Endereco.Cidade) || !string.IsNullOrWhiteSpace(cadVenda.Endereco.CEP))
                    {
                        ModelState.AddModelError("TipoEntrega", " Para concluir a compra informe seu endereço na tela de clientes");
                        ViewBag.ExibirCampo = true;
                        return View("Create", cadVenda);
                    }
                }

                cadVenda.Venda = Mapper.Map<Venda>(cadVenda);

                cadVenda.Venda.Veiculo = Mapper.Map<Veiculo>(_veiculoRepository.ObterPorId(cadVenda.IdVeiculo));
                cadVenda.Venda.FormaDePagamento = Mapper.Map<FormaDePagamento>(_formaPagamentoRepository.ObterPorId(cadVenda.IdFormaDePagamento));

                cadVenda.Venda = Venda.CalcularVeiculoEsportivo(cadVenda.Venda);
                cadVenda.Venda = Venda.CalcularPagamento(cadVenda.Venda);

                return RedirectToAction("DetailsConfirmar", cadVenda);
            }
            else
            {
                cadVenda.Clientes = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());
                cadVenda.FormasDePagamentos = Mapper.Map<IList<FormaDePagamento>>(_formaPagamentoRepository.ObterTodos());
                cadVenda.Veiculos = Mapper.Map<IList<GDC_Veiculos>, IList<Veiculo>>(_veiculoRepository.ObterTodos());
                cadVenda.Performance = Mapper.Map<IList<GDC_Perfomances>, IList<Performance>>(_perfomanceRepository.ObterTodos());
                cadVenda.Endereco = new Endereco();

                return View("Create", cadVenda);
            }
        }

        [HttpGet]
        public ActionResult DetailsConfirmar(CadastrarVendaViewModel cadVenda)
        {
            DetailsDeleteVendaViewModel detailsDeleteVendaViewModel = new DetailsDeleteVendaViewModel();

            detailsDeleteVendaViewModel.Venda = cadVenda.Venda;
            detailsDeleteVendaViewModel.Cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(cadVenda.IdCliente));
            detailsDeleteVendaViewModel.Performance = Mapper.Map<Performance>(_perfomanceRepository.ObterPorId(cadVenda.IdPerformance));
            detailsDeleteVendaViewModel.Roda = Mapper.Map<Roda>(_rodaRepository.ObterPorId(detailsDeleteVendaViewModel.Performance.IdRoda));
            detailsDeleteVendaViewModel.Banco = Mapper.Map<Banco>(_bancoRepository.ObterPorId(detailsDeleteVendaViewModel.Performance.IdBanco));
            detailsDeleteVendaViewModel.Cor_Veiculo = Mapper.Map<Cor_Veiculo>(_corRepository.ObterPorId(detailsDeleteVendaViewModel.Performance.IdCorVeiculo));
            detailsDeleteVendaViewModel.Veiculo = Mapper.Map<Veiculo>(_veiculoRepository.ObterPorId(cadVenda.IdVeiculo));
            detailsDeleteVendaViewModel.Endereco = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(cadVenda.IdEndereco));
            detailsDeleteVendaViewModel.FormaDePagamento = Mapper.Map<FormaDePagamento>(_formaPagamentoRepository.ObterPorId(cadVenda.IdFormaDePagamento));
            
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

            MudarClienteComunParaVip(cadVenda.Cliente);
            
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
                //var calcularGastoCliente = _vendaRepository.GastosPorCliente(cliente.Id);

                var calcularGastoCliente = _vendaRepository.ObterPorId(cliente.Id);

                if (calcularGastoCliente.Valor >= 200000)
                    MudarClienteParaVip(cliente);

                _clienteRepository.Editar(Mapper.Map<GDC_Clientes>(cliente));
            }
        }

        [HttpPost]
        [Route("ObterInformacoesBasicasCliente")]
        public JsonResult ObterInformacoesBasicasCliente(Guid idCliente)
        {
            var vendaViewModel = new CadastrarVendaViewModel();

            vendaViewModel.Performance = Mapper.Map<IList<Performance>>(_perfomanceRepository.ObterPorIdCliente(idCliente));

            var cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(idCliente));

            if (cliente.Tipo.ToString() == TipoCliente.Vip.ToString())
                vendaViewModel.FormasDePagamentos = Mapper.Map<IList<FormaDePagamento>>(_formaPagamentoRepository.ObterListarFormaPagamentoVip());
            else
                vendaViewModel.FormasDePagamentos = Mapper.Map<IList<FormaDePagamento>>(_formaPagamentoRepository.ObterFormaPagamentoComum());

            if (cliente.Endereco == null)
                cliente.Endereco = new Endereco();

            return Json(new { formasDePagamento = vendaViewModel.FormasDePagamentos, customs = vendaViewModel.Performance, endereco = cliente.Endereco });
        }

        [HttpPost]
        [Route("ObterValorVeiculo")]
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

        [HttpPost]
        [Route("ObterEnderecoCliente")]
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