using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    public class ClienteController : Controller
    {
        private ClienteRepository _clienteRepository;
        private VendaRepository _vendaRepository;
        private EnderecoRepository _enderecoRepository;

        public ClienteController(ClienteRepository _clienteRepository, VendaRepository _vendaRepository, EnderecoRepository _enderecoRepository)
        {
            this._clienteRepository = _clienteRepository;
            this._vendaRepository = _vendaRepository;
            this._enderecoRepository = _enderecoRepository;
        }

        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IList<GDC_Clientes>, IList<Cliente>>(_clienteRepository.ObterTodos());

            return View(clienteViewModel);
        }

        public ActionResult FormularioCadastro()
        {
            return View();
        }

        public ActionResult AdicionarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepository.Inserir(_enderecoRepository.ObterPorId(endereco.Id));
                _clienteRepository.Atualizar(endereco.Id, endereco.IdCliente);
            }

            return RedirectToAction("Index");
        }

        public ActionResult AdicionarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var cpfExistente = _clienteRepository.VerificarCPFExistente(cliente.CPF);

                if (cpfExistente == null)
                {
                    cliente.Tipo = TipoCliente.Comum;

                    var clienteToDomain = Mapper.Map<Cliente, GDC_Clientes>(cliente);

                    _clienteRepository.Inserir(clienteToDomain);
                    ViewBag.IdCliente = cliente.Id;

                    return View("CadastrarEndereco");
                }
                else
                {
                    ModelState.AddModelError("CPF", "O CPF já existe no sistema!");
                    return View("FormularioCadastro", cliente);
                }
            }
            else
            {
                return View("FormularioCadastro", cliente);
            }
        }

        public ActionResult EditarCliente(Guid id)
        {
            var cliente = _clienteRepository.ObterPorId(id);

            //if (cliente == null)
            //    return Content("Erro");

            return View(cliente);
        }

        public ActionResult EditarClientes(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Editar(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditarCliente", cliente);
            }
        }
    }
}