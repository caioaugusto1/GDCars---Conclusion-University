using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Factory.Base.Upload;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("administrativo/veiculo")]
    public class VeiculoController : Controller
    {
        private VeiculoRepository _veiculoRepository;

        public VeiculoController(VeiculoRepository _veiculoRepository)
        {
            this._veiculoRepository = _veiculoRepository;
        }

        [Route("listar-veiculo")]
        public ActionResult Index()
        {
            var veiculosViewModel = Mapper.Map<IList<GDC_Veiculos>, IList<Veiculo>>(_veiculoRepository.ObterTodos());

            return View(veiculosViewModel);
        }

        [Route("cadastrar-veiculo")]
        public ActionResult FormularioCadastro()
        {
            return View();
        }

        public ActionResult AdicionarProduto(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                foreach (string nomeArquivo in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[nomeArquivo];
                    UploadArquivoFactory.Upload(file, nomeArquivo);
                }

                veiculo.Ano = Convert.ToInt32(DateTime.Now.Year);

                var toDomain = Mapper.Map<Veiculo, GDC_Veiculos>(veiculo);

                _veiculoRepository.Inserir(toDomain);
                return RedirectToAction("Index");
            }
            else
            {
                return View("FormularioCadastro", veiculo);
            }
        }

        [HttpGet]
        [Route("editar-veiculo/{id:guid}")]
        public ActionResult Editar(Guid id)
        {
            var veiculoViewModel = Mapper.Map<Veiculo>(_veiculoRepository.ObterPorId(id));

            return View(veiculoViewModel);
        }

        [HttpPost]
        public ActionResult Editar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                var veiculoDomain = Mapper.Map<Veiculo, GDC_Veiculos>(veiculo);

                _veiculoRepository.Editar(veiculoDomain);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditarProduto", veiculo);
            }
        }

        #region metodos de imagens
        public ActionResult Excluir(Guid id)
        {
            //_veiculoRepository.Excluir(id)

            return RedirectToAction("Index");
        }

        public ActionResult VerImagem()
        {
            //Adicione quantas extensões você desejar!
            //List<String> oListTiposImagens = new List<string>();
            //oListTiposImagens.Add("*.gif");
            //oListTiposImagens.Add("*.png");
            //oListTiposImagens.Add("*.jpg");

            //var ImagemNome = uploadArquivoDAO.pegarNomeImagemPorIdProduto(idProduto);

            var nomecompleto = System.IO.Path.Combine(ConfigurationManager.AppSettings["caminhoRepositorioDeArmazenamento"], "uno" + ".png");

            var arquivoInfo = new FileInfo(nomecompleto);

            //string[] imagens2 = Directory.GetFiles(caminhoDiretorio, "*.png");

            return base.File(nomecompleto, "uno.png");
        }

        public ActionResult SalvarArquivo()
        {
            var fazerUpload = false;

            foreach (string nomeArquivo in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[nomeArquivo];
                UploadArquivoFactory.Upload(file, nomeArquivo);
            }

            if (fazerUpload)
                return Content("ok");
            else
                return Content("Erro");

        }

        #endregion
    }
}