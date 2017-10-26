using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    public class ClienteController : Controller
    {
        #region Instâncias Repositorys

        private ClienteRepository _clienteRepository;
        private VendaRepository _vendaRepository;
        private EnderecoRepository _enderecoRepository;

        #endregion

        #region Método Construtor

        public ClienteController(ClienteRepository _clienteRepository, VendaRepository _vendaRepository, EnderecoRepository _enderecoRepository)
        {
            this._clienteRepository = _clienteRepository;
            this._vendaRepository = _vendaRepository;
            this._enderecoRepository = _enderecoRepository;
        }

        #endregion

        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());

            return View(clienteViewModel);
        }

        public ActionResult FormularioCadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var temIdadeMinima21 = Cliente.ValidarIdadeMinima21Anos(cliente);

                if (temIdadeMinima21)
                {
                    var cpfExistente = _clienteRepository.ObterPorCPF(cliente.CPF);

                    if (cpfExistente == null)
                    {
                        cliente.Tipo = TipoCliente.Comum;

                        var clienteToDomain = Mapper.Map<Cliente, GDC_Clientes>(cliente);

                        _clienteRepository.Inserir(clienteToDomain);
                        ViewBag.IdCliente = cliente.Id;

                        return RedirectToAction("CadastrarEndereco", new { idCliente = cliente.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("CPF", "O CPF já existe no sistema!");
                        return View("FormularioCadastro", cliente);
                    }
                }
                else
                {
                    ModelState.AddModelError("Data_Nascimento", "Cliente com idade menor que 21 anos!");
                    return View("FormularioCadastro", cliente);
                }
            }
            else
            {
                return View("FormularioCadastro", cliente);
            }
        }

        #region Endereco

        [HttpGet]
        public ActionResult CadastrarEndereco(Guid idCliente)
        {
            var enderecoViewModel = new Endereco();

            enderecoViewModel.IdCliente = idCliente;

            return View(enderecoViewModel);
        }

        [HttpPost]
        public ActionResult AdicionarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                var enderecoDomain = Mapper.Map<GDC_Enderecos>(endereco);

                _enderecoRepository.Inserir(enderecoDomain);
                _clienteRepository.Atualizar(endereco.Id, endereco.IdCliente);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditarEndereco(Guid id)
        {
            var enderecoViewModel = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(id));

            if (enderecoViewModel == null)
                return Content("Erro");

            return View(enderecoViewModel);
        }

        [HttpPost]
        public ActionResult EditarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepository.Editar(Mapper.Map<GDC_Enderecos>(endereco));
                return RedirectToAction("Index");
                //var enderecoViewModel = _enderecoRepository.BuscarPorIdCliente(endereco.Id);

                //return View("CadastrarEndereco", enderecoViewModel);
                ////return RedirectToAction("Index");
            }
            else
            {
                return View("EditarCliente", endereco);
            }
        }

        #endregion

        [HttpGet]
        public ActionResult EditarCliente(Guid id)
        {
            var clienteViewModel = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(id));

            if (clienteViewModel == null)
                return Content("Erro");

            return View(clienteViewModel);
        }

        [HttpPost]
        public ActionResult EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Editar(Mapper.Map<GDC_Clientes>(cliente));

                return RedirectToAction("Details", cliente.Id);
            }
            else
            {
                return View("EditarCliente", cliente);
            }
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var clienteViewModel = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(id));
           
            if(clienteViewModel.IdEndereco.HasValue)
                clienteViewModel.Endereco = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(clienteViewModel.IdEndereco.Value));

            return View(clienteViewModel);
        }
    }
}