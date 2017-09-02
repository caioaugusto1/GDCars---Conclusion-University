using System.Configuration;

namespace VendaDeAutomoveis.DAO.ConnectionContext
{
    public class GDCarsConnectionString
    {
        static public string Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ContextGDCars"].ConnectionString;
                return connectionString;
            }
        }
    }
}