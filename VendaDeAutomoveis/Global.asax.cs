using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using VendaDeAutomoveis.AutoMapper;
using VendaDeAutomoveis.Repository;

namespace VendaDeAutomoveis
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<GDCarsContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
