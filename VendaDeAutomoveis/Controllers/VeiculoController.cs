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

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    public class VeiculoController : Controller
    {
        private VeiculoRepository veiculoRepository;

        public VeiculoController(VeiculoRepository veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
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

            //veiculo.IdUpload = Guid.Parse("5a998169-09e9-4016-bc7d-d86d87ee9926");
            if (ModelState.IsValid)
            {
                veiculoRepository.Adicionar(veiculo);
                return RedirectToAction("Index");
            }
            else
            {
                return View("FormularioCadastro", veiculo);
            }
        }

        public ActionResult EditarProduto(Guid id)
        {
            var veiculo = veiculoRepository.ObterPorId(id);
            return View(veiculo);
        }

        public ActionResult EditarProdutos(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculoRepository.Editar(veiculo);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditarProduto", veiculo);
            }
        }

        public ActionResult Excluir(Guid id)
        {
            veiculoRepository.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            IList<Veiculo> veiculos = veiculoRepository.ObterTodos();

            return View(veiculos);
        }

        public ActionResult Teste()
        {
            return View();
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
    }
}