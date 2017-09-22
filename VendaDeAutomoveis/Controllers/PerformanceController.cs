using System.Web.Mvc;

namespace VendaDeAutomoveis.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Performance
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Passo1CadastroRoda()
        {
            return View();
        }

        public ActionResult Passo2CadastroCor()
        {
            return View();
        }
    }
}