using System;
using System.Configuration;
using System.IO;
using System.Web;
using VendaDeAutomoveis.Entidades;


namespace VendaDeAutomoveis.Factory.Base.Upload
{
    public class UploadArquivoFactory
    {
        public static bool Upload(HttpPostedFileBase file, string nomeArquivo)
        {
            try
            {
                var caminhoDiretorio = ConfigurationManager.AppSettings["caminhoRepositorioDeArmazenamento"].ToString();//Config fora do sistema (Web config)

                string nomeA = string.Empty;

                Guid arquivoGuid;
                arquivoGuid = Guid.NewGuid();

                HttpPostedFileBase arquivoMomento = file;
                nomeA = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    var nomeArquivoCarregado = Path.GetFileName(file.FileName);

                    bool existenciaDiretorio = System.IO.Directory.Exists(caminhoDiretorio);
                    if (!existenciaDiretorio)
                    {
                        System.IO.Directory.CreateDirectory(caminhoDiretorio);
                    }
                    var caminhoArquivo = string.Empty;
                    var extensao = System.IO.Path.GetExtension(nomeA);

                    caminhoArquivo = string.Format("{0}\\{1}", caminhoDiretorio, arquivoGuid + ".png");

                    file.SaveAs(caminhoArquivo);

                    //string recebendoDetalhes = arquivo.Detalhes;

                    //arquivo.Detalhes = "<br/>" + "<ol/>" + " - " + nomeArquivoCarregado + recebendoDetalhes;
                }

                //arquivo.Data = DateTime.Now;

                //uploadArquivoDAO.AdicionarArquivo(arquivo);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}