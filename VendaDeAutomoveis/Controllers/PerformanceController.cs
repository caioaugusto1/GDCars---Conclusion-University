using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Enums;
using VendaDeAutomoveis.Models;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.Controllers
{
    public class PerformanceController : Controller
    {
        private PerfomanceRepository _perfoRepository;
        private ClienteRepository _clienteRepository;
        private RodaRepository _rodaRepository;
        private CorVeiculoRepository _corVeiculoRepository;
        private BancoRepository _bancoRepository;

        public PerformanceController(PerfomanceRepository _perfoRepository, ClienteRepository _clienteRepository,
            RodaRepository _rodaRepository, CorVeiculoRepository _corVeiculoRepository, BancoRepository _bancoRepository)
        {
            this._perfoRepository = _perfoRepository;
            this._clienteRepository = _clienteRepository;
            this._rodaRepository = _rodaRepository;
            this._corVeiculoRepository = _corVeiculoRepository;
            this._bancoRepository = _bancoRepository;
        }

        // GET: Performance
        public ActionResult Index()
        {
            var obterPerformances = Mapper.Map<List<GDC_Perfomances>, List<Performance>>(_perfoRepository.ObterTodos().ToList());

            var perform = new ListarPerformancesViewModel();

            List<ListarPerformancesViewModel> perfViewModel = new List<ListarPerformancesViewModel>();

            foreach (var itemPerfor in obterPerformances)
            {
                perform.Cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(itemPerfor.IdCliente));
                perform.Roda = Mapper.Map<Roda>(_rodaRepository.ObterPorId(itemPerfor.IdRoda));
                perform.Banco = Mapper.Map<Banco>(_bancoRepository.ObterPorId(itemPerfor.IdBanco));
                perform.Cor = Mapper.Map<Cor_Veiculo>(_corVeiculoRepository.ObterPorId(itemPerfor.IdCor));

                perfViewModel.Add(perform);
            }

            return View(perfViewModel);
        }

        [HttpGet]
        public ActionResult Passo1CadastroRoda()
        {
            ViewBag.Cliente = _clienteRepository.ObterTodos();

            return View();
        }

        [HttpPost]
        public ActionResult Passo1CadastroRoda(Roda roda)
        {
            var idPerformance = Guid.NewGuid();

            _rodaRepository.Inserir(Mapper.Map<GDC_Rodas>(roda));
            _perfoRepository.InserirPasso1Roda(idPerformance, roda.IdCliente, roda.Id, roda.Valor);
            
            return RedirectToAction("Passo2CadastroCor", idPerformance);
        }

        [HttpGet]
        public ActionResult Passo2CadastroCor(Guid idPerformance)
        {
            ViewBag.IdPerformance = idPerformance;

            return View("Passo2CadastroCor", idPerformance);
        }

        [HttpPost]
        public ActionResult Passo2CadastroCor(Cor_Veiculo corVeiculo)
        {
            _corVeiculoRepository.Inserir(Mapper.Map<GDC_Cor_Veiculos>(corVeiculo));
            _perfoRepository.InserirPasso2Cor(corVeiculo.IdPerformance, corVeiculo.Id);

            return View("Passo3CadastroCor");
        }

        [HttpGet]
        public ActionResult Passo3CadastroCor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Passo3CadastroCor(Banco banco)
        {
            _bancoRepository.Inserir(Mapper.Map<GDC_Bancos>(banco));
            _perfoRepository.InserirPasso2Cor(banco.IdPerformance, banco.Id);

            return View();
        }
    }
}