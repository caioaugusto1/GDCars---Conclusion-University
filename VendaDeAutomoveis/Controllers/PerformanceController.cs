using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Models;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.Controllers
{
    public class PerformanceController : Controller
    {

        #region Instâncias de Repositorys

        private PerfomanceRepository _perfoRepository;
        private ClienteRepository _clienteRepository;
        private RodaRepository _rodaRepository;
        private CorVeiculoRepository _corVeiculoRepository;
        private BancoRepository _bancoRepository;

        #endregion


        #region Métoo Construtor

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

        // GET: Performance
        public ActionResult Index()
        {
            var obterCustomns = Mapper.Map<IList<GDC_Perfomances>, IList<Performance>>(_perfoRepository.ObterTodos());

            var custom = new ListarPerformancesViewModel();

            List<ListarPerformancesViewModel> customViewModel = new List<ListarPerformancesViewModel>();

            foreach (var itemCustom in obterCustomns)
            {
                custom.Cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(itemCustom.IdCliente));
                custom.Roda = Mapper.Map<Roda>(_rodaRepository.ObterPorId(itemCustom.IdRoda));
                custom.Banco = Mapper.Map<Banco>(_bancoRepository.ObterPorId(itemCustom.IdBanco));
                custom.Cor_Veiculo = Mapper.Map<Cor_Veiculo>(_corVeiculoRepository.ObterPorId(itemCustom.IdCorVeiculo));

                customViewModel.Add(custom);
            }

            return View(customViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Performance Model = new Performance();

            ViewBag.Cliente = _clienteRepository.ObterTodos();
            ViewData["GetAros"] = Roda.GetAros();

            return View(Model);
        }

        [HttpPost]
        public ActionResult Create(Performance custom)
        {
            if (ModelState.IsValid)
            {
                custom.Id = Guid.NewGuid();

                _rodaRepository.Inserir(Mapper.Map<GDC_Rodas>(custom.Roda));
                _corVeiculoRepository.Inserir(Mapper.Map<GDC_Cor_Veiculos>(custom.Cor_Veiculo));
                _bancoRepository.Inserir(Mapper.Map<GDC_Bancos>(custom.Banco));

                _perfoRepository.Inserir(Mapper.Map<GDC_Perfomances>(custom));

                return View();

            }

            ViewBag.Cliente = _clienteRepository.ObterTodos();
            
            return View(custom);
        }
    }
}