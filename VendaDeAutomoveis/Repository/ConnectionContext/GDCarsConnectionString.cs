using System.Configuration;

namespace VendaDeAutomoveis.DAO.ConnectionContext
{
    public class GDCarsConnectionString
    {
        static public string Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["GDCarsContext"].ConnectionString;
                return connectionString;
            }
        }
    }
}