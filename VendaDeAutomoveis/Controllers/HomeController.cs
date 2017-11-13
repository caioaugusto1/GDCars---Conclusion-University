using System.Web.Mvc;
using VendaDeAutomoveis.Filters;

namespace VendaDeAutomoveis.Controllers
{
    [AutorizacaoFilter]
    [RoutePrefix("pagina-principal-GDCars")]
    public class HomeController : Controller
    {
        // GET: Home
        [Route("inicio")]
        public ActionResult Index() 
        {
            return View();
        }
    }
}