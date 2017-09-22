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
    public class VeiculoController : Controller
    {
        private VeiculoRepository _veiculoRepository;

        public VeiculoController(VeiculoRepository _veiculoRepository)
        {
            this._veiculoRepository = _veiculoRepository;
        }

        public ActionResult Index()
        {
            var veiculosViewModel = Mapper.Map<IList<GDC_Veiculos>, IList<Veiculo>>(_veiculoRepository.ObterTodos());

            return View(veiculosViewModel);
        }

        public ActionResult FormularioCadastro()
        {
            return View();
        }

        public ActionResult AdicionarProduto(Veiculo veiculo)
        {
            foreach (string nomeArquivo in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[nomeArquivo];
                UploadArquivoFactory.Upload(file, nomeArquivo);
            }

            if (veiculo.IdUpload.ToString() == "{00000000-0000-0000-0000-000000000000}")
                veiculo.IdUpload = null;

            if (ModelState.IsValid)
            {
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
                fazerUpload = UploadArquivoFactory.Upload(file, nomeArquivo);
            }

            if (fazerUpload)
                return Content("ok");
            else
                return Content("Erro");

            //var caminhoDiretorio = ConfigurationManager.AppSettings["caminhoRepositorioDeArmazenamento"].ToString();//Config fora do sistema (Web config)

            //string nomeA = string.Empty;

            //Guid arquivoGuid;
            //arquivoGuid = Guid.NewGuid();
            //try
            //{
            //    foreach (string nomeArquivo in Request.Files)
            //    {
            //        HttpPostedFileBase file = Request.Files[nomeArquivo];
            //        nomeA = file.FileName;
            //        if (file != null && file.ContentLength > 0)
            //        {
            //            var nomeArquivoCarregado = Path.GetFileName(file.FileName);

            //            bool existenciaDiretorio = System.IO.Directory.Exists(caminhoDiretorio);
            //            if (!existenciaDiretorio)
            //            {
            //                System.IO.Directory.CreateDirectory(caminhoDiretorio);
            //            }
            //            var caminhoArquivo = string.Empty;
            //            var extensao = System.IO.Path.GetExtension(nomeA);

            //            caminhoArquivo = string.Format("{0}\\{1}", caminhoDiretorio, arquivoGuid + ".png");

            //            file.SaveAs(caminhoArquivo);

            //            string recebendoDetalhes = arquivo.Detalhes;

            //            arquivo.Detalhes = "<br/>" + "<ol/>" + " - " + nomeArquivoCarregado + recebendoDetalhes;
            //        }

            //        arquivo.Data = DateTime.Now;

            //        //uploadArquivoDAO.AdicionarArquivo(arquivo);
            //    }
            //    return Content("Ok");
            //}
            //catch (Exception ex)
            //{
            //    return Json(new { Message = "Erro em Salvar o Arquivo" });
            //}
        }

        #endregion
    }
}