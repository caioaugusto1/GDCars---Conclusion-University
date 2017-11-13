using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VendaDeAutomoveis.Controllers.Base;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("administrativo/cliente")]
    public class ClienteController : BaseController
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

        #region Cliente

        [Route("listar-clientes")]
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());

            return View(clienteViewModel);
        }

        [Route("cadastrar-cliente")]
        public ActionResult FormularioCadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarCliente(Cliente cliente)
        {
            try
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

                            return RedirectToAction("detalhes-cliente", new { idCliente = cliente.Id });
                        }
                        else
                        {
                            ModelState.AddModelError("CPF", "O CPF já existe no sistema!");
                            return View("cadastrar-cliente", cliente);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Data_Nascimento", "Cliente com idade menor que 21 anos!");
                        return View("cadastrar-cliente", cliente);
                    }
                }
                else
                {
                    return View("cadastrar-cliente", cliente);
                }
            }
            catch (Exception ex)
            {
                return Error();
            }
           
        }

        [HttpGet]
        [Route("editar-cliente/{id:guid}")]
        public ActionResult EditarCliente(Guid id)
        {
            try
            {
                var clienteViewModel = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(id));

                if (clienteViewModel == null)
                    return Error();

                return View(clienteViewModel);
            }
            catch
            {
                return Error();
            }
           
        }

        [HttpPost]
        [Route("editar-cliente")]
        public ActionResult EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Editar(Mapper.Map<GDC_Clientes>(cliente));

                return RedirectToAction("detalhes-cliente", "administrativo/cliente", new { cliente.Id });
            }
            else
            {
                return View("editar-cliente", "administrativo/cliente", cliente.Id);
            }
        }

        [HttpGet]
        [Route("detalhes-cliente/{id:guid}")]
        public ActionResult Details(Guid id)
        {
            var clienteViewModel = Mapper.Map<Cliente>(_clienteRepository.ObterPorId(id));

            if (clienteViewModel.IdEndereco.HasValue)
                clienteViewModel.Endereco = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(clienteViewModel.IdEndereco.Value));

            return View(clienteViewModel);
        }

        #endregion

        #region Endereco

        [HttpGet]
        [Route("detalhes-cliente/cadastrar-endereco/{id:guid}")]
        public ActionResult CadastrarEndereco(Guid idCliente)
        {
            var enderecoViewModel = new Endereco();

            enderecoViewModel.IdCliente = idCliente;

            return View(enderecoViewModel);
        }

        [HttpPost]
        [Route("detalhes-cliente/cadastrar-endereco")]
        public ActionResult AdicionarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                var enderecoDomain = Mapper.Map<GDC_Enderecos>(endereco);

                _enderecoRepository.Inserir(enderecoDomain);
                _clienteRepository.Atualizar(endereco.Id, endereco.IdCliente);
            }

            return RedirectToAction("listar-clientes", "administrativo/cliente");
        }

        [HttpGet]
        [Route("editar-cliente/endereco/{id:guid}")]
        public ActionResult EditarEndereco(Guid id)
        {
            var enderecoViewModel = Mapper.Map<Endereco>(_enderecoRepository.ObterPorId(id));

            if (enderecoViewModel == null)
                return Content("Erro");

            return View(enderecoViewModel);
        }

        [HttpPost]
        [Route("editar-cliente/endereco")]
        public ActionResult EditarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                var cliente = Mapper.Map<Cliente>(_clienteRepository.ObterPorIdEndereco(endereco.Id));
                _enderecoRepository.Editar(Mapper.Map<GDC_Enderecos>(endereco));
                
                return RedirectToAction("detalhes-cliente", "administrativo/cliente", new { cliente.Id });
            }
            else
            {
                return View("editar-cliente", "administrativo/cliente", endereco);
            }
        }

        #endregion
    }
}