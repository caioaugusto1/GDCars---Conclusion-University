using System.Web.Mvc;

namespace VendaDeAutomoveis.Controllers.Base
{
    public class BaseController : Controller
    {
        public ActionResult Error()
        {
            return View("Error", "Base");
        }
    }
}