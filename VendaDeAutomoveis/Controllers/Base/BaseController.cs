using System.Web.Mvc;

namespace VendaDeAutomoveis.Controllers.Base
{
    [RoutePrefix("administrativo/erro")]
    public class BaseController : Controller
    {
        [Route("ops-erro")]
        public ActionResult Error()
        {
            return View();
        }
    }
}