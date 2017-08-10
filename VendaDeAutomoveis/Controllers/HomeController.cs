using System.Web.Mvc;
using VendaDeAutomoveis.Filters;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}