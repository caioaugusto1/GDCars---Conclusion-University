using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    public class ClienteController : Controller
    {
        private ClienteRepository clienteRepository;
        private VendaRepository vendaRepository;
        private EnderecoRepository enderecoRepository;

        public ClienteController(ClienteRepository clienteRepository, VendaRepository vendaRepository, EnderecoRepository enderecoRepository)
        {
            this.clienteRepository = clienteRepository;
            this.vendaRepository = vendaRepository;
            this.enderecoRepository = enderecoRepository;
        }

        public ActionResult Index()
        {
            IList<Cliente> clientes = clienteRepository.ObterTodos();
            return View(clientes);
        }

        public ActionResult FormularioCadastro()
        {
            return View();
        }

        public ActionResult AdicionarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                enderecoRepository.Adicionar(endereco);
                clienteRepository.Atualizar(endereco.Id, endereco.IdCliente);
            }

            return RedirectToAction("Index");
        }

        public ActionResult AdicionarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var cpfExistente = clienteRepository.VerificarCPFExistente(cliente.CPF);

                if (cpfExistente == null)
                {
                    clienteRepository.Adicionar(cliente);
                    ViewBag.IdCliente = cliente.IdCliente;

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
            var cliente = clienteRepository.ObterPorId(id);

            //if (cliente == null)
            //    return Content("Erro");

            return View(cliente);
        }

        public ActionResult EditarClientes(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Editar(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditarCliente", cliente);
            }
        }
    }
}