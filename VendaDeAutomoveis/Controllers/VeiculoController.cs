using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendaDeAutomoveis.Controllers.Base;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("administrativo/veiculo")]
    public class VeiculoController : BaseController
    {
        private VeiculoRepository _veiculoRepository;
        private VendaRepository _vendaRepository;

        public VeiculoController(VeiculoRepository _veiculoRepository, VendaRepository _vendaRepository)
        {
            this._veiculoRepository = _veiculoRepository;
            this._vendaRepository = _vendaRepository;
        }

        [Route("listar-veiculo")]
        public ActionResult Index()
        {
            try
            {
                var veiculosViewModel = Mapper.Map<IList<GDC_Veiculos>, IList<Veiculo>>(_veiculoRepository.ObterTodos());

                foreach (Veiculo veiculo in veiculosViewModel)
                {
                    veiculo.Venda = Mapper.Map<Venda>(_vendaRepository.ObterTodos().Where(a => a.IdVeiculo == veiculo.Id).FirstOrDefault());
                }

                return View(veiculosViewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Base");
            }
        }

        [Route("cadastrar")]
        public ActionResult FormularioCadastro()
        {
            return View();
        }

        [Route("cadastrar-veiculo")]
        public ActionResult AdicionarProduto(Veiculo veiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    veiculo.Ano = Convert.ToInt32(DateTime.Now.Year);

                    var toDomain = Mapper.Map<Veiculo, GDC_Veiculos>(veiculo);

                    _veiculoRepository.Inserir(toDomain);
                    return RedirectToAction("listar-veiculo", "administrativo/veiculo");
                }
                else
                {
                    return View("cadastrar-veiculo", "administrativo/veiculo", veiculo);
                }
            }
            catch
            {
                return RedirectToAction("Error", "Base");
            }
        }

        [HttpGet]
        [Route("editar-veiculo/{id:guid}")]
        public ActionResult Editar(Guid id)
        {
            try
            {
                var veiculoViewModel = Mapper.Map<Veiculo>(_veiculoRepository.ObterPorId(id));

                return View(veiculoViewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Base");
            }
        }

        [HttpPost]
        [Route("editar-veiculo/{id:guid}")]
        public ActionResult Editar(Veiculo veiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var veiculoDomain = Mapper.Map<Veiculo, GDC_Veiculos>(veiculo);

                    _veiculoRepository.Editar(veiculoDomain);
                    return RedirectToAction("listar-veiculo", "administrativo/veiculo");
                }
                else
                {
                    return View("editar-veiculo", "administrativo/veiculo", veiculo);
                }
            }
            catch
            {
                return RedirectToAction("Error", "Base");
            }
        }

        #region metodos de imagens
        [Route("excluir-veiculo/{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            try
            {
                _veiculoRepository.Delete(id);

                return RedirectToAction("listar-veiculo", "administrativo/veiculo");
            }
            catch
            {
                return RedirectToAction("Error", "Base");
            }
        }

        public ActionResult SalvarArquivo()
        {
            var fazerUpload = false;

            foreach (string nomeArquivo in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[nomeArquivo];
                //UploadArquivoFactory.Upload(file, nomeArquivo);
            }

            if (fazerUpload)
                return Content("ok");
            else
                return Content("Erro");

        }

        #endregion
    }
}