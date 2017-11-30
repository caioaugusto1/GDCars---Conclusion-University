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

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("administrativo/custom")]
    public class PerformanceController : BaseController
    {
        #region Instâncias de Repositorys

        private PerfomanceRepository _perfoRepository;
        private ClienteRepository _clienteRepository;
        private RodaRepository _rodaRepository;
        private CorVeiculoRepository _corVeiculoRepository;
        private BancoRepository _bancoRepository;

        #endregion

        #region Métodos Construtor

        public PerformanceController(PerfomanceRepository _perfoRepository, ClienteRepository _clienteRepository,
            RodaRepository _rodaRepository, CorVeiculoRepository _corVeiculoRepository, BancoRepository _bancoRepository)
        {
            this._perfoRepository = _perfoRepository;
            this._clienteRepository = _clienteRepository;
            this._rodaRepository = _rodaRepository;
            this._corVeiculoRepository = _corVeiculoRepository;
            this._bancoRepository = _bancoRepository;
        }

        #endregion

        #region Métodos Públicos

        [Route("listar-custom")]
        public ActionResult Index()
        {
            try
            {
                var obterCustomns = Mapper.Map<List<GDC_Perfomances>, List<Performance>>(_perfoRepository.ObterTodos().ToList());

                var custom = new ListarCustomsViewModel();

                List<ListarCustomsViewModel> customViewModel = new List<ListarCustomsViewModel>();

                foreach (var itemCustom in obterCustomns)
                {
                    custom = new ListarCustomsViewModel();

                    custom.Cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(itemCustom.IdCliente));
                    custom.Roda = Mapper.Map<Roda>(_rodaRepository.ObterPorId(itemCustom.IdRoda));
                    custom.Banco = Mapper.Map<Banco>(_bancoRepository.ObterPorId(itemCustom.IdBanco));
                    custom.Cor_Veiculo = Mapper.Map<Cor_Veiculo>(_corVeiculoRepository.ObterPorId(itemCustom.IdCorVeiculo));

                    customViewModel.Add(custom);
                }

                return View(customViewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Base");
            }
        }

        [HttpGet]
        [Route("cadastrar-custom")]
        public ActionResult Create()
        {
            Performance Model = new Performance();

            ViewBag.Cliente = _clienteRepository.ObterTodos();

            return View(Model);
        }

        [HttpPost]
        [Route("detalhes-cadastrar-custom")]
        public ActionResult Create(Performance custom)
        {
            try
            {
                ViewBag.Cliente = _clienteRepository.ObterTodos();

                if (ModelState.IsValid)
                {
                    custom.Id = Guid.NewGuid();
                    custom.IdBanco = custom.Banco.Id;
                    custom.IdRoda = custom.Roda.Id;
                    custom.IdCorVeiculo = custom.Cor_Veiculo.Id;

                    custom.ValorTotal = CalcularCustom(custom);

                    _rodaRepository.Inserir(Mapper.Map<GDC_Rodas>(custom.Roda));
                    _corVeiculoRepository.Inserir(Mapper.Map<GDC_Cor_Veiculos>(custom.Cor_Veiculo));
                    _bancoRepository.Inserir(Mapper.Map<GDC_Bancos>(custom.Banco));

                    _perfoRepository.Inserir(Mapper.Map<GDC_Perfomances>(custom));

                    return RedirectToAction("Index");
                }

                return View(custom);
            }
            catch
            {
                return RedirectToAction("Error", "Base");
            }
        }
        #endregion

        #region Métodos Privados
        private double CalcularCustom(Performance custom)
        {
            decimal valorTotal = 0;

            valorTotal = custom.Banco.Valor;
            valorTotal += custom.Cor_Veiculo.Valor;
            valorTotal += custom.Roda.Valor;

            return Convert.ToDouble(valorTotal);
        }

        #endregion

    }
}